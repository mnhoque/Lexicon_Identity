using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lexicon_Identity.Models
{
    public class Country//student
    {
        [Key]

        public int Country_Id { get; set; }
        public string Country_Name { get; set; }

        public List<City> Cities { get; set; }

        public AppUser _AppUser { get; set; }
    }
}
