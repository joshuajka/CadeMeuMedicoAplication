using CadeMeuMedicoAplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedicoAplication.Controllers
{
    public class MedicoController : Controller
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();
        // GET: Medico
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList();
            return View(medicos);
        }

        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View();
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medicos medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Medicos.Add(medico);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
                ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome",medico.IDEspecialidade);
                return View(medico);
            }
            catch
            {
                return View(medico);
            }
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        // POST: Medico/Edit/5
        [HttpPost]
        public ActionResult Edit(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }

        
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
