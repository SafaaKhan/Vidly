using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { set; get; }

        [Required]
        public Customer customer{ set; get; }

        [Required]
        public Movie movie{ set; get; }

        public DateTime DateRented{ set; get; }

        //nullable
        public DateTime? DateReturned{ set; get; }
    }
}