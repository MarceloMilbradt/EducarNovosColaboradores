using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Transform;
using NovosColaboradores.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace NovosColaboradores.Repository
{
    public class RepositorioBase<T>
                where T : class
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().Database(

                PostgreSQLConfiguration.Standard.ConnectionString(c => c
                //Connection String 
                .Host("svdev").Port(5432).Database("educarNovosColaboradores").Username("postgres").Password("Servidor.")

                ).ShowSql().Driver<NpgsqlDriver>().Dialect<PostgreSQL81Dialect>()

                ).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pessoa>())
                .BuildSessionFactory();
        }

        private ISessionFactory SessionFactory = CreateSessionFactory();

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public T Incluir(T entidade)
        {
            try
            {
                using (ISession session = OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(entidade);
                        transaction.Commit();
                    }
                }
                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public T Alterar(T entidade)
        {
            try
            {
                using (ISession session = OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(entidade);
                        transaction.Commit();
                    }

                }

                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public void Excluir(T entidade)
        {
            try
            {
                using (ISession session = OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(entidade);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public T Incluir(T entidade, ISession session)
        {
            try
            {
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(entidade);
                        transaction.Commit();
                    }

                    return entidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public T Alterar(T entidade, ISession session)
        {
            try
            {

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entidade);
                    transaction.Commit();
                }



                return entidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public void Excluir(T entidade, ISession session)
        {
            try
            {

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entidade);
                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
    }

    public static class NhTransformers
    {
        public static readonly IResultTransformer ExpandoObject;

        static NhTransformers()
        {
            ExpandoObject = new ExpandoObjectResultSetTransformer();
        }

        private class ExpandoObjectResultSetTransformer : IResultTransformer
        {
            public IList TransformList(IList collection)
            {
                return collection;
            }

            public object TransformTuple(object[] tuple, string[] aliases)
            {
                var expando = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)expando;
                for (int i = 0; i < tuple.Length; i++)
                {
                    string alias = aliases[i];
                    if (alias != null)
                    {
                        dictionary[alias] = tuple[i];
                    }
                }
                return expando;
            }
        }
    }

    public static class NHibernateExtensions
    {
        public static IList<dynamic> DynamicList(this IQuery query)
        {
            return query.SetResultTransformer(NhTransformers.ExpandoObject)
                        .List<dynamic>();
        }
    }
}