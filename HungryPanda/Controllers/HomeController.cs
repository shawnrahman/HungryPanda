using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HungryPanda.Models;
using HungryPanda.ViewModels;

namespace HungryPanda.Controllers
{  
    public class HomeController : Controller
    {
        private MyDbContext _context;
        public HomeController()
        {
             _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            IEnumerable<City> cities = _context.Cities;
            IEnumerable<Area> areas = _context.Areas;

            CityAndAreaViewModel viewModel = new CityAndAreaViewModel();
            viewModel.Cities = cities;
            viewModel.Areas = areas;


            return View(viewModel);
        }


        //THis loads the areas based on the City using Ajax
        public ActionResult LoadAreas(int cityId)
        {
            IEnumerable<Area> areas = _context.Areas;
            var a = areas.Where(s => s.CityId == cityId).Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return Json(a, JsonRequestBehavior.AllowGet);
        }



        //post request goes.Displays all the resturants based on city and area
        [HttpPost]
        public ActionResult ResturantList()
        {

            var areaid = Int32.Parse(Request.Form["area"]);

            IEnumerable<ResturantOwner> resturants = _context.ResturantOwners;
            resturants = resturants.Where(c => c.AreaId == areaid);

            ResturantListViewModel viewModel = new ResturantListViewModel();
            viewModel.ResturantOwners = resturants;


            return View(viewModel);
        }


        [HttpGet]
        public ActionResult ResturantMenu(int resturantId)
        {



            IEnumerable<ResturantMenu> resturantMenu = _context.ResturantMenus;
            IEnumerable<ResturantMenuCategory> resturantMenuCategory = _context.ResturantMenuCategories;



            resturantMenu = resturantMenu.Where(c => c.ResturantOwnerId == resturantId);

            ResturantMenuViewModel viewModel = new ResturantMenuViewModel();
            viewModel.ResturantMenu = resturantMenu;
            viewModel.ResturantMenuCategories = resturantMenuCategory;

            return View(viewModel);
        }

    }
}