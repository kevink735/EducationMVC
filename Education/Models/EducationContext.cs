using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Education.Models
{
    public class EducationContext : DbContext
    {
        public DbSet<student> students { get; set; }
        public DbSet<countrytable> countrytables { get; set; }
        public DbSet<coursetable> coursetables { get; set; }
        //when using DTO you need to set as List
        public List<StudentDTO> StudentDTOs { get; set; }
        public DbSet<teacher> teachertable { get; set; }
         public DbSet<empsalary> salarytable { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        //when using DTO you need to set as List
       // public List<ApplicantDTO> ApplicantDTOs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<statetable> statetables { get; set; }

       // public System.Data.Entity.DbSet<Education.Models.Applicant> Applicants { get; set; }
    }
}


