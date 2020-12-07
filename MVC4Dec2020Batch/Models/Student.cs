using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4Dec2020Batch.Models
{
    public class Student
    {
        public int studId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        
    }

    public class StudentFaculty
    {
        public List<Student> st { get; set; }
        public List<Faculty> ft { get; set; }
    }
}