using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBasedApproach.Models
{
    public class EmployeeDepartment
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int? EmpSalary { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }

    }
}