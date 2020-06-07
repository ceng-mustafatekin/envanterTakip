﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace envanterTakip.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        envanterDBEntities obj = new envanterDBEntities();
        // GET: PurchaseInvoice
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var data = (from x in obj.suppliers select new { x.sup_id, x.sup_name }).ToList();
            ViewBag.suppList = new SelectList(data, "sup_id", "sup_name");
            return View();
        }
    }
}