using HungryPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungryPanda.Controllers
{
    public class AuthenticationController : Controller
    {

        private MyDbContext _context;
        public AuthenticationController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Authentication functions

        public Customer AuthenticateCustomer(string email, string password)
        {
            var customer = (from r in _context.Customers where r.Email == email && r.Password == password select r).SingleOrDefault();
            return customer;
        }

        public Admin AuthenticateAdmin(string email, string password)
        {
            var admin = (from r in _context.Admins where r.Email == email && r.Password == password select r).SingleOrDefault();
            return admin;
        }

        public ResturantOwner AuthenticateResturantOwner(string email, string password)
        {
            var ResturantOwner = (from r in _context.ResturantOwners where r.Email == email && r.Password == password select r).SingleOrDefault();
            return ResturantOwner;
        }
        //...............................




        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login()
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            var customer = AuthenticateCustomer(email, password);
            var admin = AuthenticateAdmin(email, password);
            var resturantOwner = AuthenticateResturantOwner(email, password);




            if (customer != null)
            {
                Session["user"] = customer;
                Session["role"] = "customer";
                return RedirectToAction("Dashboard", "Customer");

            }
            else if (admin != null)
            {
                Session["user"] = admin;
                Session["role"] = "admin";

                return RedirectToAction("Dashboard", "Admins");

            }
            else if (resturantOwner != null)
            {

                Session["user"] = resturantOwner;
                Session["role"] = "resturantOwner";

                return RedirectToAction("Dashboard", "Resturant_Owner");

            }
            else
            {
                ViewBag.messege = "Incorrect User Name or Password";
                return View("Index");
            }











        }


        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["role"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}