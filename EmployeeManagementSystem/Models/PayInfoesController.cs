﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Models
{
    public class PayInfoesController : Controller
    {
        private ZeusDB db = new ZeusDB();

        // GET: PayInfoes
        public ActionResult Index()
        {
            var payInfoes = db.PayInfoes.Include(p => p.EmplyeeInfo);
            return View(payInfoes.ToList());
        }

        // GET: PayInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayInfo payInfo = db.PayInfoes.Find(id);
            if (payInfo == null)
            {
                return HttpNotFound();
            }
            return View(payInfo);
        }

        // GET: PayInfoes/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.EmplyeeInfoes, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: PayInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayStubId,EmployeeID,Month,Pay")] PayInfo payInfo)
        {
            if (ModelState.IsValid)
            {
                db.PayInfoes.Add(payInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.EmplyeeInfoes, "EmployeeID", "EmployeeName", payInfo.EmployeeID);
            return View(payInfo);
        }

        // GET: PayInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayInfo payInfo = db.PayInfoes.Find(id);
            if (payInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.EmplyeeInfoes, "EmployeeID", "EmployeeName", payInfo.EmployeeID);
            return View(payInfo);
        }

        // POST: PayInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayStubId,EmployeeID,Month,Pay")] PayInfo payInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.EmplyeeInfoes, "EmployeeID", "EmployeeName", payInfo.EmployeeID);
            return View(payInfo);
        }

        // GET: PayInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayInfo payInfo = db.PayInfoes.Find(id);
            if (payInfo == null)
            {
                return HttpNotFound();
            }
            return View(payInfo);
        }

        // POST: PayInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayInfo payInfo = db.PayInfoes.Find(id);
            db.PayInfoes.Remove(payInfo);
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
