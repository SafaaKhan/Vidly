using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="The customer's name is required")]
        [StringLength(255)]
        public string Name { set; get; }

        [Display(Name ="Date of Birth")]
        [Min18YearsOldIfAMermber]
        public DateTime? Birthdate { set; get; }

        public bool isSubscribedToNewsLetter { set; get; }

        
        public MembershipType MembershipType { set; get; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { set; get; }
    }
}