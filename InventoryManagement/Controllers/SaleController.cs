using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities1 db = new Inventory_managementEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(int id, Sale sale)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            s.Sale_date = sale.Sale_date;
            s.Sale_prod = sale.Sale_prod;
            s.Sale_qnty = sale.Sale_qnty;
            db.SaveChanges();
            return RedirectToAction("Display Sale");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult Delete(int id,Sale s)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

    }
}
    
