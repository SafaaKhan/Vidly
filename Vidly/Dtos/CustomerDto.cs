using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "The customer's name is required")]
        [StringLength(255)]
        public string Name { set; get; }

        //[Min18YearsOldIfAMermber]
        public DateTime? Birthdate { set; get; }

        public bool isSubscribedToNewsLetter { set; get; }

        public byte MembershipTypeID { set; get; }

        public MembershipTypeDto MembershipType { set; get; }
    }
}