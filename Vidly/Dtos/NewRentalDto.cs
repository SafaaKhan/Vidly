using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class NewRentalDto
    {
        
        public int CustomerId { set; get; }
       
        public List<int> MovieIds { set; get; }
    }
}