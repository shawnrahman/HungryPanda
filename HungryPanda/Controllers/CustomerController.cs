using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using HungryPanda.Models;
using HungryPanda.ViewModels;

namespace HungryPanda.Controllers
{
    public class CustomerController : Controller
    {
        private MyDbContext _context;
        public CustomerController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        //Dashboard functions..............................................................
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult customer_profile()
        {
            Customer customer = (Customer)Session["user"];

            return View(customer);
        }
        //Show current customer profile 
        [HttpGet]
        public ActionResult edit_customer_profile()
        {
            Customer customer = (Customer)Session["user"];

            return View(customer);
        }

        [HttpPost]
        public ActionResult edit_customer_profile([Bind(Include = "Name,Email,Address,Phone")] Customer customer)
        {


            Customer customerUpdate = (Customer)Session["user"];

            customerUpdate.Name = customer.Name;
            customerUpdate.Email = customer.Email;
            customerUpdate.Address = customer.Address;
            customerUpdate.Phone = customer.Phone;
            Session["user"] = customerUpdate;
            _context.Entry(customerUpdate).State = EntityState.Modified;
            _context.SaveChanges();


            ViewBag.message = "Profile Changed";
            return View(customerUpdate);
        }
        //Show change password
        [HttpGet]
        public ActionResult change_password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult change_password([Bind(Include = "Password")] Customer customer)
        {
            Customer customerUpdate = (Customer)Session["user"];


            if (Request["currentPassword"] == customerUpdate.Password)
            {
                if (customer.Password == Request["confirmPassword"])
                {
                    customerUpdate.Password = customer.Password;

                    _context.Entry(customerUpdate).State = EntityState.Modified;
                    _context.SaveChanges();
                     ViewBag.message = "Password Changed";
                    return View();



                }
                else
                {
                    ViewBag.message = "New Password and Confirm Password do not match";
                    return View();
                    

                }


            }
            else
            {
                ViewBag.message = "Password incorret";
                return View();
            }





        }

        //Show Orders of the customer

        public ActionResult orders_customer()
        {
            Customer customer = (Customer)Session["user"];

            IEnumerable<Order> orders = _context.Orders.Where(o => o.CustomerId == customer.Id);
            IEnumerable<OrderedMenuItems> orderedMenuItems = _context.OrderedMenuItems;
            IEnumerable<ResturantOwner> resturantOwners = _context.ResturantOwners;
            IEnumerable<ResturantMenu> resturantMenu = _context.ResturantMenus;

            var resturants = from order in orders
                             join orderedMenuItem in orderedMenuItems on order.Id equals orderedMenuItem.OrderId
                             join resturantMenus in resturantMenu on orderedMenuItem.Id equals resturantMenus.Id
                             join resturantOwner in resturantOwners on resturantMenus.Id equals resturantOwner.Id
                             select resturantOwner;




            CustomerOrdersViewModels viewModel = new CustomerOrdersViewModels();
            viewModel.Orders = orders;
            viewModel.OrderedMenuItems = orderedMenuItems;
            viewModel.ResturantOwner = resturants;
            return View(viewModel);
        }

























        // GET: Customer
        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult RegisterNewCustomer()
        //{
        //    var email = Request.Form["email"];
        //    return Content(email);
        //}


        [HttpPost]
        public ActionResult Register([Bind(Include = "Name,DOB,Gender,Email,Address,Password,Phone,Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
 
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Content("SUccess");
            }

            return Content("Faliure");
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
