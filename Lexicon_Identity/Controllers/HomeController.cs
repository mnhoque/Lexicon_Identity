using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lexicon_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Lexicon_Identity.Data;

namespace Lexicon_Identity.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;
        //private DbSet<Course> courses;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Enter_City()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter_City(string cName,int ctryId)
        {
            if (cName != null && ctryId !=0)
            {
                var City= new City();
                City.City_Name = cName;
                City.Country_Id = ctryId;
                db.Cities.Add(City);

                db.SaveChanges();
            }
            return View();
            
        }

        public IActionResult Enter_Country()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter_Country(string Ctry_Name)
        {
            if (Ctry_Name != null)
            {
                var Country = new Country();
                Country.Country_Name = Ctry_Name;
                db.Countries.Add(Country);
                
                db.SaveChanges();
            }
            return View();
        }

        List<Country> Countries = new List<Country>();

        public IActionResult ShowCountries()
        {
            var _countries = db.Countries;
            foreach (var item in _countries)
            {
                Countries.Add(item);
            }
            return View(Countries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
