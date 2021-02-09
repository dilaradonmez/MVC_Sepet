using MVC_Sepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sepet.Controllers
{
    public class HomeController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View(db.Products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddToCart(int id)//
        {
            Product eklenecek = db.Products.Find(id);

            #region Karar Yapısı
            //Cart c = null;

            //if (Session["cart"] == null)
            //{
            //    c = new Cart();
            //}
            //else
            //{
            //    c = Session["cart"] as Cart;
            //} 
            #endregion


            //Ternary If => Tek satırda koşuldan dönen değeri bir değişken içerisine aktarmak istediğimizde kullanırız.
            Cart c = Session["cart"] == null ? new Cart():Session["cart"] as Cart;

            CartItem cartItem = new CartItem();
            cartItem.ID = eklenecek.ProductID;
            cartItem.UnitPrice = eklenecek.UnitPrice;
            cartItem.Name = eklenecek.ProductName;

            c.AddItem(cartItem);
            Session["cart"] = c;



            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            Product silinecek = db.Products.Find(id);

            Cart c = Session["cart"] == null ? new Cart() : Session["cart"] as Cart;

            CartItem cartItem = new CartItem();
            cartItem.ID = silinecek.ProductID;

            c.DeleteItem(cartItem);
            Session["cart"] = c;

            return RedirectToAction("Index", "Cart");
        }
    }
}