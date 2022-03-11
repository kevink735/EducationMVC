using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Education.Models;

namespace Education.Dataacess
{
    public class Dataaces
    {

        EducationContext studentcontext = new EducationContext();


        public int AddStudent(student studentmodel)
        {
            int status = 0;
            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {


                    student students = new student();

                    students.firstname = studentmodel.firstname;
                    students.lastname = studentmodel.lastname;
                    students.gender = studentmodel.gender;
                    students.address = studentmodel.address;
                    students.countryid = studentmodel.countryid;
                 //   students.email = studentmodel.email;
                    studentcontext.students.Add(students);
                    studentcontext.SaveChanges();
                    status = 1;

                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return status;

        }

        public int updateStudent(student studentmodel)
        {
            int status = 0;
            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {

                    var stu = studentcontext.students.Where(x => x.studentid == studentmodel.studentid).FirstOrDefault();
                    if (stu != null)
                    {

                        student student = (from s in studentcontext.students where s.studentid == studentmodel.studentid select s).FirstOrDefault();

                        student.firstname = studentmodel.firstname;
                        student.lastname = studentmodel.lastname;
                        student.address = studentmodel.address;
                        student.gender = studentmodel.gender;
                        student.countryid = studentmodel.countryid;
                        studentcontext.SaveChanges();
                        status = 1;
                    }


                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return status;

        }

        public List<countrytable> FillCountry()
        {
            try
            {

                using (EducationContext studentcontext = new EducationContext())
                {
                    var countryList = studentcontext.countrytables.ToList();

                    return countryList;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        public int addteacher(string firstname, string lastname, string gender, string address, int country, decimal sal)
        {
            int status = 0;
            using (EducationContext studentcontext = new EducationContext())
            {
                using (var transaction = studentcontext.Database.BeginTransaction())
                {

                    try
                    {

                        teacher emp = new teacher();
                        emp.firstname = firstname;
                        emp.lastname = lastname;
                        emp.gender = gender;
                        emp.address = address;
                        emp.countryid = country;
                        int id = emp.teacherid;

                        studentcontext.teachertable.Add(emp);
                        studentcontext.SaveChanges();
                        
   

                        empsalary empsal = new empsalary();
                        empsal.teacherid = id;
                        empsal.Teachersalary = sal;
                        int salid = empsal.salaryid;
                        studentcontext.salarytable.Add(empsal);
                        studentcontext.SaveChanges();
                        transaction.Commit();
                        status = 1;


                    }
                 /*   catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;

                    }*/
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        transaction.Rollback();
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }

                return status;
            }
        }

        public List<coursetable> FillCourse()
        {
            using (EducationContext studentcontext = new EducationContext())
            {
                var course = studentcontext.coursetables.ToList();
                return course;
            }


        }

        public List<student> GetAllstudent()
        {
            using (EducationContext studentcontext = new EducationContext())
            {
                var studentrec = studentcontext.students.ToList();
                return studentrec;

            }

        }


        public List<student> GetNostudent()
        {
            int i = 0;
            using (EducationContext studentcontext = new EducationContext())
            {
                var studentrec = studentcontext.students.Where(a => a.studentid == i);
                return studentrec.ToList();

            }

        }

        public int DeleteRecord(int i)
        {
            int x = 0;
            using (EducationContext studentcontext = new EducationContext())
            {
                var del = studentcontext.students.Single(a => a.studentid == i);
                if (del != null)
                {
                    var dele = studentcontext.students.Remove(del);

                    studentcontext.SaveChanges();
                    x = 1;

                }

                return x;
            }
        }

        public List<student> GetStudentDetails(int id)
        {

            using (EducationContext studentcontext = new EducationContext())
            {

                //   var studentrecord = studentcontext.students.Where(a => a.studentid == id).ToList();
                var studentrecord = studentcontext.students.Where(x => x.studentid == id).ToList();
                return studentrecord;

            }

        }


        public List<Applicant> GetApplicantDetails(int id)
        {

            using (EducationContext studentcontext = new EducationContext())
            {
                var applicantrecord = studentcontext.Applicants.Where(x => x.applicantid  == id).ToList();
                return applicantrecord;

            }

        }

   


        public List<student> GetStudentsingle(string searchBy, string search)
        {

            using (EducationContext studentcontext = new EducationContext())
            {


                if (searchBy == "FirstName")
                {

                    var studentrec = studentcontext.students.Where(x => x.firstname == search).ToList();
                    return studentrec;
                }
                else
                {
                    var studentrec = studentcontext.students.Where(x => x.lastname == search).ToList();
                    return studentrec;
                }


            }

        }

        
        public List<StudentDTO> GetStudent(string searchBy, string search)
                {

                    using (EducationContext studentcontext = new EducationContext())
                    {


                        if (searchBy == "FirstName")
                        {
                            var list = (from studentx in studentcontext.students
                                        where studentx.firstname.Contains(search)
                                          join countrytab in studentcontext.countrytables  on studentx.countryid equals countrytab.countryid
                                        select new StudentDTO
                                        {
                                            studentid = studentx.studentid,
                                            firstname = studentx.firstname,
                                            lastname = studentx.lastname,
                                            gender = studentx.gender,
                                            address = studentx.address,
                                            countryid = countrytab.countryid,
                                            countryname = countrytab.countryname

                                        }).OrderBy(a => a.studentid).ToList();
                            return list;
                        }
                        else
                        {
                            var list = (from studentx in studentcontext.students
                                        where studentx.lastname.Contains(search)
                                        join countrytab in studentcontext.countrytables on studentx.countryid equals countrytab.countryid
                                      select new StudentDTO
                                        {
                                            studentid = studentx.studentid,
                                            firstname = studentx.firstname,
                                            lastname = studentx.lastname,
                                            gender = studentx.gender,
                                            address = studentx.address,
                                            countryid = countrytab.countryid,
                                            countryname = countrytab.countryname
                                        }).OrderBy(a => a.studentid).ToList();
                            return list;
                        }

                    }

               }

        public List<Jobs> jobs()
        {
            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {
                    var Joblist = studentcontext.Jobs.ToList();
                    return Joblist;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        public List<Jobs> Filljob()
        {

            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {
                    var Joblist = studentcontext.Jobs.ToList();

                    return Joblist;
                }
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        public List<statetable> Fillstate(int id)
        {
            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {
                    var staterec = studentcontext.statetables.Where(a => a.countryid == id).ToList();

                    return staterec;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


        }

        public int ApplyApplicant(Applicant Applicantmodel)
        {
            int status = 0;
            try
            {
                using (EducationContext applicantcontext = new EducationContext())
                {


                    Applicant Applicants = new Applicant();

                    Applicants.firstname = Applicantmodel.firstname;
                    Applicants.lastname = Applicantmodel.lastname;
                    Applicants.gender = Applicantmodel.gender;
                    Applicants.dob = Applicantmodel.dob;
                    Applicants.address = Applicantmodel.address;
                    Applicants.stateid = Applicantmodel.stateid;
                    Applicants.countryid = Applicantmodel.countryid;
                    Applicants.phone = Applicantmodel.phone;
                    Applicants.email = Applicantmodel.email;
                    applicantcontext.Applicants.Add(Applicants);
                    applicantcontext.SaveChanges();
                    status = 1;

                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return status;

        }

        public int addcourse(string coursename)
        {
            int status = 0;
            using (EducationContext studentcontext = new EducationContext())
            {
                using (var transaction = studentcontext.Database.BeginTransaction())
                {

                    try
                    {
                        coursetable courses = new coursetable();

                        courses.coursename = coursename;
                        studentcontext.coursetables.Add(courses);
                        studentcontext.SaveChanges();
                        int id = courses.courseid;

                        transaction.Commit();
                        status = 1;


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;

                    }

                }

                return status;
            }
        }


        public int AddApplicant(Applicant ApplicantModel , string image)
        {
            int status = 0;
            try
            {
                using (EducationContext studentcontext = new EducationContext())
                {


                    Applicant Applicants = new Applicant();

                    
                    Applicants.firstname = ApplicantModel.firstname;
                    Applicants.lastname = ApplicantModel.lastname;
                    Applicants.gender = ApplicantModel.gender;
                    Applicants.dob = ApplicantModel.dob;
                    Applicants.address = ApplicantModel.address;
                    Applicants.stateid = ApplicantModel.stateid;
                    Applicants.countryid = ApplicantModel.countryid;
                    Applicants.phone = ApplicantModel.phone;
                    Applicants.email = ApplicantModel.email;
                    Applicants.jobid = ApplicantModel.jobid;
                    Applicants.photo = image;
                    
                    studentcontext.Applicants.Add(Applicants);
                    studentcontext.SaveChanges();
                    status = Applicants.applicantid;
                    //status = 1;

                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return status;

        }


/*
        public List<ApplicantDTO> Applicant(int id)
        {
            using (EducationContext studentcontext = new EducationContext())
            {

                var applicant = (from p in studentcontext.ApplicantDTOs
                                 join s in studentcontext.Jobs on p.jobid equals s.jobid
                                 join c in studentcontext.countrytables on p.jobid equals s.jobid
                                   
                               select new JobDescriptionDTO
                               {
                                   descid = p.descid,
                                   Dop = p.Dop,
                                   expdetails = p.expdetails,
                                   positions = p.positions,
                                   qualification = p.qualification,
                                   jobid = s.jobid,
                                   jobtitle = s.jobtitle,
                                   jobtype = s.jobtype

                               }
                                 ).Where(a => a.jobid == id).ToList();
                return jondesc;


            }


        }
        */
    }

}
