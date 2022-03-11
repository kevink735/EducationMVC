using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    [Table("students")]
    public class student
    {
        [Key]
        public int studentid { get; set; }
        [Required(ErrorMessage = "First name can't be blank")]
        [StringLength(10, MinimumLength = 3)]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Last Name can't be blank")]
        public string lastname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public int countryid { get; set; }

    }

    [Table("teacher")]
    public class teacher
    {
        [Key]
        public int teacherid { get; set; }
        [Required(ErrorMessage = "First name can't be blank")]
        [StringLength(10, MinimumLength = 3)]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Last Name can't be blank")]
        public string lastname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public int countryid { get; set; }

    }

    [Table("countrytable")]
    public class countrytable
    {
        [Key]
        public int countryid { get; set; }
        public string countryname { get; set; }


    }
    [Table("coursetable")]
    public class coursetable
    {
        [Key]
        public int courseid { get; set; }
        public string coursename { get; set; }

    }

    [Table("Jobtable")]
    public class Jobs
    {
        [Key]
        public int jobid { get; set; }
        public string jobtype { get; set; }
        public string jobtitle { get; set; }

    }

    [Table("statetable")]
    public class statetable
    {
        [Key]
        public int stateid { get; set; }
        public int countryid { get; set; }
        public string state { get; set; }

    }

    [Table("salarytable")]
    public class empsalary
    {
        [Key]
        public int salaryid { get; set; }
        public int teacherid { get; set; }
        public decimal Teachersalary { get; set; }

    }


    [Table("Applicant")]
    public class Applicant
    {
        [Key]
        public int applicantid { get; set; }
        public string firstname { get; set; }
        [Required(ErrorMessage = "Last Name can't be blank")]
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public int stateid { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public int countryid { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public int jobid { get; set; }
        public string photo { get; set; }
    }

    public class StudentDTO
    {
        [Key]
        public int studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public int countryid { get; set; }
        public string countryname { get; set; }

    }
}