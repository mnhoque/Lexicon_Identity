using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Identity.Models
{
    public class AppUser:IdentityUser//studentAddress

    {
        //[ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }


        //[ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
