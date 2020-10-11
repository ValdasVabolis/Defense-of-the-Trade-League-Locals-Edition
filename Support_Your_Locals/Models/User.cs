using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Support_Your_Locals.Models
{
    public class User
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        [Key]
        public string Email { get; set; }
    }
}
