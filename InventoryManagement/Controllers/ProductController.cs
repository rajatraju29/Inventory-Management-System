﻿using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities1 db = new Inventory_managementEntities1();
        // GET: Product

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List <Product> list= db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int id,Product pro)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            pr.Product_name = pro.Product_name;
            pr.Product_qnty = pro.Product_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            Product Pro = db.Products.Where(x=>x.id== id).SingleOrDefault();
            return View(Pro);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id,Product pro)
        {
            
            db.Products.Remove(db.Products.Where(x=>x.id==id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }



    }
}