using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelBasedApproach.Models
{
    public class RegistrationForm
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage ="")]
        public string EmpName { get; set; }
        public string Password { get; set; }
        public string ConfirmPwd { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }

    }
}