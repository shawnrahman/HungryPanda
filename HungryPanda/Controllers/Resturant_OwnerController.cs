  using HungryPanda.Models;
using HungryPanda.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HungryPanda.Web.Controllers
{
    public class Resturant_OwnerController : Controller
    {



        private MyDbContext _context;
        public Resturant_OwnerController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }








        // GET: Resturant_owner
        public ActionResult Dashboard()
        {
            ResturantOwner customer = (ResturantOwner)Session["user"];

            return View(customer);
        }

        public ActionResult ResturantOwner_profile()
        {
            ResturantOwner customer = (ResturantOwner)Session["user"];

            return View(customer);
        }

        //get request
        public ActionResult orders_resturantOwner()
        {
            ResturantOwner customer = (ResturantOwner)Session["user"];

            IEnumerable<Order> orders = _context.Orders.Where(o => o.ResturantName == customer.ResturantName);
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

        [HttpPost]
        public ActionResult UpdateOrderStatus()
        {
            var orders = _context.Orders.Where(o => o.Id == Int32.Parse(Request["Id"])).SingleOrDefault();
            orders.OrderStatus = (OrderStatus)Int32.Parse(Request["orderStatus"]);

           _context.Entry(orders).State = EntityState.Modified;
            _context.SaveChanges();
            return View("Dashboard");
        }


        public ActionResult edit_resturantowner_profile()
        {
            ResturantOwner owner = (ResturantOwner)Session["user"];

            return View(owner);
        }
        [HttpPost]
        public ActionResult edit_resturantowner_profile([Bind(Include = "ResturantOwnerName,ResturantName,Email,Address,Phone")] ResturantOwner owner)
        {
            ResturantOwner ownerUpdate = (ResturantOwner)Session["user"];

            ownerUpdate.ResturantOwnerName = owner.ResturantOwnerName;
            ownerUpdate.ResturantName = owner.ResturantName;
            ownerUpdate.Email = owner.Email;
            ownerUpdate.Address = owner.Address;
            ownerUpdate.Phone = owner.Phone;
            Session["user"] = ownerUpdate;
            _context.Entry(ownerUpdate).State = EntityState.Modified;
            _context.SaveChanges();

            ViewBag.message = "Profile Changed";
            return View(owner);
        }

        [HttpGet]
        public ActionResult change_password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult change_password([Bind(Include = "Password")] ResturantOwner resturantOwner)
        {
            ResturantOwner resturantOwnerUpdate = (ResturantOwner)Session["user"];


            if (Request["currentPassword"] == resturantOwnerUpdate.Password)
            {
                if (resturantOwner.Password == Request["confirmPassword"])
                {
                    resturantOwnerUpdate.Password = resturantOwner.Password;

                    _context.Entry(resturantOwnerUpdate).State = EntityState.Modified;
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


        [HttpGet]
        public ActionResult addMenu()
        {
            return View();

        }

    }
}