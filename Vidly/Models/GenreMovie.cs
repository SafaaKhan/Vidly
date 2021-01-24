using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenreMovie
    {
        public byte GenreMovieId { set; get; }

        [Required]
        [StringLength(255)]
        public string Name { set; get; }
    }
}