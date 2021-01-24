using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { set; get; }

        [Required]
        public string Name { set; get; }
        public short SingUpFee { set; get; }
        public byte DurationInMonths { set; get; }
        public byte DiscountRate { set; get; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        
    }
}