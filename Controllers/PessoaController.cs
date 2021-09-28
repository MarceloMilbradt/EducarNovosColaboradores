using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using NovosColaboradores.Entity;
using NovosColaboradores.Repository;
using System.Net;

namespace NovosColaboradores.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository repository = new PessoaRepository();
        public ActionResult Index()
        {
            var sessionFactory = RepositorioBase<Pessoa>.CreateSessionFactory();
            IList<Pessoa> pessoas = new List<Pessoa>();
            using (var session = sessionFactory.OpenSession())
            {

                pessoas = session.QueryOver<Pessoa>().OrderBy(p => p.pessoa_id).Desc.List().Take(100).ToList();

            }
            return View(pessoas);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var sessionFactory = RepositorioBase<Pessoa>.CreateSessionFactory();
            IList<Endereco> enderecos = new List<Endereco>();
            using (var session = sessionFactory.OpenSession())
            {

                enderecos = session.CreateSQLQuery("select e.* from endereco e where e.cidade_id = 4281").AddEntity(typeof(Endereco)).List<Endereco>();

            }
            ViewBag.endereco_id = new SelectList(enderecos, "endereco_id", "logradouro");

            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "endereco_id")] Pessoa pessoa, int endereco_id)
        {
            var sessionFactory = RepositorioBase<Pessoa>.CreateSessionFactory();
            ModelState["endereco_id"].Errors.Clear();
            if (ModelState.IsValid)
            {
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        pessoa.endereco_id = new Endereco { endereco_id = endereco_id };
                        session.Save(pessoa);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            IList<Endereco> enderecos = new List<Endereco>();
            using (var session = sessionFactory.OpenSession())
            {

                enderecos = session.CreateSQLQuery("select e.* from endereco e where e.cidade_id = 4281").AddEntity(typeof(Endereco)).List<Endereco>();

            }
            ViewBag.endereco_id = new SelectList(enderecos, "endereco_id", "logradouro");
            return View(pessoa);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var session = RepositorioBase<Pessoa>.CreateSessionFactory().OpenSession())
            {
                Pessoa pessoa;
                pessoa = session.Get<Pessoa>(id);


                IList<Endereco> enderecos = session.CreateSQLQuery("select e.* from endereco e where e.cidade_id = 4281").AddEntity(typeof(Endereco)).List<Endereco>();
                ViewBag.endereco_id = new SelectList(enderecos, "endereco_id", "logradouro", pessoa.endereco_id.endereco_id);

                return View(pessoa);
            }
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "endereco_id")] Pessoa pessoa, int endereco_id)
        {
            var sessionFactory = RepositorioBase<Pessoa>.CreateSessionFactory();
            ModelState["endereco_id"].Errors.Clear();
            if (ModelState.IsValid)
            {
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        pessoa.endereco_id = new Endereco { endereco_id = endereco_id };
                        session.Save(pessoa);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            IList<Endereco> enderecos = new List<Endereco>();
            using (var session = sessionFactory.OpenSession())
            {

                enderecos = session.CreateSQLQuery("select e.* from endereco e where e.cidade_id = 4281").AddEntity(typeof(Endereco)).List<Endereco>();

            }
            ViewBag.endereco_id = new SelectList(enderecos, "endereco_id", "logradouro", pessoa.endereco_id.endereco_id);
            return View(pessoa);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            using (var session = RepositorioBase<Pessoa>.CreateSessionFactory().OpenSession())
            {
                Pessoa pessoa;
                pessoa = session.Get<Pessoa>(id);

                return View(pessoa);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var session = RepositorioBase<Pessoa>.CreateSessionFactory().OpenSession())
            {
                Pessoa pessoa;
                pessoa = session.Get<Pessoa>(id);
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(pessoa);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
        }

        public JsonResult ListPessoas(int limit = 100)
        {
            var sessionFactory = RepositorioBase<Pessoa>.CreateSessionFactory();
            IList<dynamic> pessoas = new List<dynamic>();
            try
            {
                using (var session = sessionFactory.OpenSession())
                {

                    pessoas = session.CreateSQLQuery("select * from pessoa limit :limit").SetParameter("limit", limit).DynamicList();
                    return Json(JsonConvert.SerializeObject(pessoas), JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}