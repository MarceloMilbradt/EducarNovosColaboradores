using NovosColaboradores.Entity;
using NovosColaboradores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovosColaboradores.Controllers
{
    public class MatriculaController : Controller
    {
        private MatriculaRepository repository = new MatriculaRepository();
        public ActionResult Index()
        {
            var sessionFactory = RepositorioBase<Matricula>.CreateSessionFactory();
            IList<Matricula> matriculas = new List<Matricula>();
            using (var session = sessionFactory.OpenSession())
            {
                matriculas = session.QueryOver<Matricula>().OrderBy(m => m.matricula_id).Desc.List().Take(100).ToList();
            }
            return View(matriculas);
        }
    }
}
