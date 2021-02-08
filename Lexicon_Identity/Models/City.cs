using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Identity.Models
{
    public class City//student
    {
        [Key]

        public int City_Id { get; set; }
        public string City_Name { get; set; }

        public int Country_Id { get; set; }

        public Country Country { get; set; }

        public AppUser _AppUser { get; set; }
    }

}
