using ProjetoRotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoRotas.Controllers
{
    public class USUT085CLIVLTController : Controller
    {
        // GET: USUT085CLIVLT
        private USUT085CLIVLT_DAO repositorio = new USUT085CLIVLT_DAO();

        public ActionResult Index()
        {
            var transacao = repositorio.ListarTodos();
            return View("Index", transacao);
            
        }

        public JsonResult BuscaCidade()
        {
            List<string> listaItens = new List<string>();
            listaItens = repositorio.BuscarEndereco();
            return this.Json(new { listaItens }, JsonRequestBehavior.AllowGet);

        }

        // GET: USUT085CLIVLT/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: USUT085CLIVLT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USUT085CLIVLT/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: USUT085CLIVLT/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: USUT085CLIVLT/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: USUT085CLIVLT/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: USUT085CLIVLT/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
