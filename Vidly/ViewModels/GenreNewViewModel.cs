using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class GenreNewViewModel
    {
        public IEnumerable<GenreNew> GenreNew { set; get; }

        public Movie Movie { set; get; }

        public string Title
        {
            get
            {
                if(Movie !=null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }
    }
}