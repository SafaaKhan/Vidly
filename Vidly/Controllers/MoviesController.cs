using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies/Index
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(m => m.GenreNew).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List", movie);
            
            return View("ReadOnlyList",movie);
           
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreNew).SingleOrDefault(m => m.Id==id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        //New
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.GenreNews.ToList();

            var viewModel = new GenreNewViewModel
            {
                GenreNew = genre
            };
            return View("MovieForm",viewModel);
        }

        //Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
           
            if (!ModelState.IsValid)
            {
                var viewmodel = new GenreNewViewModel { 
                    Movie= movie,
                    GenreNew= _context.GenreNews.ToList()
                 };
                return View("MovieForm", viewmodel);
            }

            if (movie.Id == 0 )
            {
                movie.AddedDate = DateTime.Now;
              //  movie.NumberOfAvailability = Convert.ToByte(movie.NumberInStock);
                _context.Movies.Add(movie);
            }
                
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreNewId = movie.GenreNewId;
                movieInDB.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        //Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new GenreNewViewModel
                    {
                        Movie = movie,
                        GenreNew = _context.GenreNews.ToList()
                    };

            return View("MovieForm", viewModel);
        }

        //check movies in(end users)
         
    }
}