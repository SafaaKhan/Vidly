using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int Id { set; get; }

        [Required]
        [StringLength(255)]
        public string Name { set; get; }

        //[Required]
        public GenreNew GenreNew { set; get; }

        [Display(Name= "Genre")]
        public byte GenreNewId { set; get; }

        [Required]
        [Display(Name = "Date of release")]
        public DateTime ReleaseDate { get; set; }

       
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        public byte NumberOfAvailability { set; get; }
    }
}