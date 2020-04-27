using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elaxes.Models;
using Elaxes.ViewModels;

namespace Elaxes.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/CustomersList
        public ActionResult CustomersList()
        {
            var movies = new List<Movie> { new Movie { Name = "Shrek" }, new Movie { Name = "Ela" } };
            var customers = new List<Customer>
            { new Customer(){Name="Michal",Id=1},
            new Customer(){Name="Maciek",Id=2}
            };

            var viewModel = new RandomMovieViewModel { Customers = customers, Movies = movies };
            return View(viewModel);
        }
    }
}