﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using BO;
using TP_Dojo_V1;
using TP_Dojo_V1.Models;

namespace TP_Dojo_V1.Controllers
{
    public class SamouraisController : Controller
    {
        readonly Context db = new Context();

        // GET: Samourais
        public ActionResult Index()
        {
            ViewBag.Message = "Poings";
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            ViewBag.Message = "Poings";
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM vm = new SamouraiVM();

            vm.Armes = db.Armes.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString()})
                .ToList();
           

            return View(vm);
        }

        // POST: Samourais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = vm.Samourai;

                samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme);

                db.Samourais.Add(samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(SamouraiVM vm)
        {
            Samourai samourai = vm.Samourai;

            samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme);
            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Samourai samourai)
        {
            //Persist en DB les changements récupérés de la vue
            if (ModelState.IsValid)
            {
                var samouraiDb = db.Samourais.Find(samourai.Id);
                samouraiDb.Force = samourai.Force;
                samouraiDb.Nom = samourai.Nom;
                samouraiDb.Arme = samourai.Arme;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samourai);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            ViewBag.Message = "Poings";
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
