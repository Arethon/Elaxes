using Elaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elaxes.ViewModels;


namespace Elaxes.Controllers
{
    public class MoviesController : Controller
    {
        // GET: movies/MoviesList
        [Route("movies/MoviesList")]
        public ActionResult MoviesList()
        {
            var movies = new List<Movie> { new Movie { Name = "Shrek" ,Id = 0}, new Movie { Name = "Ela" , Id=1} };
            var customers = new List<Customer>
            { new Customer(){Name="Michal",Id=1},
            new Customer(){Name="Maciek",Id=2}
            };

            var viewModel = new RandomMovieViewModel { Customers = customers, Movies = movies };
            return View(viewModel);
        }

        // GET: movies/MovieDetailed
        [Route("movies/MovieDetailed/{Id:range(0,3)}")]
        public ActionResult MovieDetailed(int Id)
        {
            var movies = new List<Movie> { 
                new Movie { Name = "Shrek", Id = 0}, 
                new Movie { Name = "Ela", Id = 1 },
                new Movie { Name = "Zaplatani", Id = 2 },
                new Movie { Name = "Na noze", Id = 3 }
            };

            var selectedMovie = movies[Id];

           return PartialView(selectedMovie);
        }


        // Edit
        public ActionResult Edit(int movieId)
        {
            return Content("id =" + movieId);
        }

        public ActionResult Index(int? PageIndex, string sortBy)
        {
            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(String.Format("PageIndex={0}& sortby={1}", PageIndex, sortBy));
                    
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return  Content(year + "/" + month);
        }
    }
}