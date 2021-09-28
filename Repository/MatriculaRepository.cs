using NHibernate;
using NovosColaboradores.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovosColaboradores.Repository
{
    public class MatriculaRepository : RepositorioBase<Matricula>
    {
        private ISession Session;
        public MatriculaRepository() { }
        public MatriculaRepository(ISession session)  { this.Session = session; }


        public IList<Endereco> getMatriculas(int matricula_id, ISession session) {
            string sql = "select m.* from matricula m where m.matricula_id = :matricula";

            return session.CreateSQLQuery(sql).AddEntity(typeof(Matricula)).SetParameter("Matricula", matricula_id).List<Endereco>();
        }


    }
}