using MVC_Sepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sepet.Controllers
{
    public class CartController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = Session["cart"] as Cart;
            return View(cart);
          
        }
    }
}