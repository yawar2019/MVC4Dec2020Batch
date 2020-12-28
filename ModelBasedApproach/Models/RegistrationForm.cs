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
        [Required(ErrorMessage ="Employee Name Cannot be Empty")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Password Cannot be Empty")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Pwd and CPwd Not Matching")]
        public string ConfirmPwd { get; set; }
        [Range(18,50,ErrorMessage ="18-50 is Allowed")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email Id format")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Address is Required")]
        [StringLength(20,ErrorMessage ="Address Should 20 Characters Long")]
        public string Address { get; set; }

    }
}