using NHibernate;
using NovosColaboradores.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovosColaboradores.Repository
{
    public class PessoaRepository : RepositorioBase<Pessoa>
    {
        private ISession Session;
        public PessoaRepository() { }
        public PessoaRepository(ISession session)  { this.Session = session; }


        public IList<Endereco> GetEnderecos(int cidade_id, ISession session) {
            string sql = "select e.* from endereco e where e.cidade_id = :cidade";

            return session.CreateSQLQuery(sql).AddEntity(typeof(Endereco)).SetParameter("cidade",cidade_id).List<Endereco>();
        }


    }
}