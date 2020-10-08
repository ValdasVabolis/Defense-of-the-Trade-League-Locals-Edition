using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Support_Your_Locals.Models {
    public class UserLoginModel {

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
    }
}
