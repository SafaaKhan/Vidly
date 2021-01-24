using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

       /* [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetNewRentals()
        {
            var rentals= _context.Rentals.Include(m=>m.customer).Include(m=>m.movie);
            return Ok(rentals);
        }*/

        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movieIds have been given.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid Customer Id.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movieIds are invalid");

            foreach(var movie in movies)
            {
                if (movie.NumberOfAvailability == 0)
                    return BadRequest("Movie is not available.");
                //movie id is not valid

                movie.NumberOfAvailability--;

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}