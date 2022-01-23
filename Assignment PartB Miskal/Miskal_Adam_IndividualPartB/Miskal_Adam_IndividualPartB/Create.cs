using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace Miskal_Adam_IndividualPartB
{
    internal class Create
    {

        public static void EnrolTrainerToCourse(MISKALSCHOOLEntities db)
        {
            Console.WriteLine("Select a Trainer By his ID");
            Console.WriteLine("");
            View.PrintTrainers(db);
           
            string input = Console.ReadLine();
            int trainerid = ValidateNumber(input);

            while (trainerid > db.Trainers.Count() || trainerid <= 0)
            {
                Console.WriteLine("Wrong Input");
                input = Console.ReadLine();
                trainerid = ValidateNumber(input);
            }
            Console.Clear();

            Console.WriteLine($"To which Course you want this Teacher to teach ? (type the ID)");
            Console.WriteLine("");
            View.PrintCourses(db);

            string input2 = Console.ReadLine();
            int courseid = ValidateNumber(input2);

            while (courseid > db.Courses.Count() || courseid <= 0)
            {
                Console.WriteLine("Wrong Input");
                input2 = Console.ReadLine();
                courseid = ValidateNumber(input2);
            }


            var mathima = db.Courses.FirstOrDefault(x => x.CourseID == courseid);
            var daskalos = db.Trainers.FirstOrDefault(x => x.TrainerID == trainerid);

            mathima.Trainers.Add(daskalos);
            daskalos.Courses.Add(mathima);
            db.SaveChanges();
            Console.Clear();
        }


        public static void EnrolStudentToCourse(MISKALSCHOOLEntities db)
        {
            Console.WriteLine("Select a Student By his ID to Enrol him");
            Console.WriteLine("");
            View.PrintStudents(db);

            string input = Console.ReadLine();
            int studentid = ValidateNumber(input);

            while (studentid > db.Students.Count() || studentid <= 0)
            {
                Console.WriteLine("Wrong Input");
                input = Console.ReadLine();
                studentid = ValidateNumber(input);
            }
            Console.Clear();

            Console.WriteLine($"To which Course you want to enrol this Student (type the ID)");
            Console.WriteLine("");
            View.PrintCourses(db);

            string input2 = Console.ReadLine();
            int courseid = ValidateNumber(input2);

            while (courseid > db.Courses.Count() || courseid <= 0)
            {
                Console.WriteLine("Wrong Input");
                input2 = Console.ReadLine();
                courseid = ValidateNumber(input2);
            }


            var mathima = db.Courses.FirstOrDefault(x => x.CourseID == courseid);
            var mathitis = db.Students.FirstOrDefault(x => x.StudentID == studentid);

            mathima.Students.Add(mathitis);
            mathitis.Courses.Add(mathima);
            db.SaveChanges();
            Console.Clear();
        }






        public static void CreateAssignment(MISKALSCHOOLEntities db)
        {

            Console.WriteLine("Input Assignment's Title");
            
            string title ="";
            do
            {
                title = Console.ReadLine();

            } while (!Validation.StringValidation(title));
            Console.WriteLine("Input Assignment's Discription");
           
            string description = "";
            do
            {
                description = Console.ReadLine();

            } while (!Validation.StringValidation(description));

            Console.WriteLine("Input Assignment's Date of sub (Please use this format : mm/dd/yyyy");
            string sub = Console.ReadLine();
            DateTime subdate = ValidateDateInput(sub);

            Console.WriteLine("Input Assignment's Oral Mark (1-50)");
            string tempmark = Console.ReadLine();
            int oralmark = ValidateNumber(tempmark);

            while (oralmark>50 ||oralmark<1)
            {
                Console.WriteLine("Please input a number 1-50");
               tempmark = Console.ReadLine();
               oralmark = ValidateNumber(tempmark);
            }

            Console.WriteLine("Input Assignment's Total Mark (1-100)");
            string tempmark2 = Console.ReadLine();
            int totalmark = ValidateNumber(tempmark2);

            while (totalmark > 100 || totalmark < 1)
            {
                Console.WriteLine("Please input a number 1-100");
                tempmark2 = Console.ReadLine();
                totalmark = ValidateNumber(tempmark);
            }
            Console.Clear();
            Console.WriteLine("Please Enter the ID of the Course this Assignment belongs to");
            Console.WriteLine("");
            Console.WriteLine();
            View.PrintCourses(db);

            string tempcourse = Console.ReadLine();
            int courseid=ValidateNumber(tempcourse);
            while (courseid > db.Courses.Count() || courseid<=0)
            {
                Console.WriteLine("Wrong Input");
                tempcourse = Console.ReadLine();
                courseid = ValidateNumber(tempcourse);
            }



            Assignment a1 = new Assignment() {  Title= title, Discription = description, SubDateTime = subdate, OralMark = oralmark,TotalMark=totalmark,CourseID=courseid };
            db.Assignments.Add(a1);
            db.SaveChanges();

            Console.Clear();

        }


        public static void CreateCourse(MISKALSCHOOLEntities db)
        {

            Console.WriteLine("Input Course's Title");
            string title = "";
            
            do
            {
                title = Console.ReadLine();

            } while (!Validation.StringValidation(title));
            Console.WriteLine("Input Course's stream");
            string stream = "";
            do
            {
                stream = Console.ReadLine();

            } while (!Validation.StringValidation2(stream));

            Console.WriteLine("Select Course's Type");
            string type="a" ;
            Console.WriteLine("");
            Console.WriteLine(" 1 for Full Time");
            Console.WriteLine(" 2 for Part Time");
            do
            {
                string input=Console.ReadLine();
                switch (input)
                {
                    case "1": type = "Full Time"; break;
                    case "2": type = "Part Time"; break;
                    default: Console.WriteLine("Wrong Input");break;
                }

            } while (type=="a");

            Console.WriteLine("Please Input The Starting Date Using this Format MM/DD/YYYY");
            string tempstartdate = Console.ReadLine();
            DateTime startdate = ValidateDateInput(tempstartdate);

            Console.WriteLine("Please Input The Ending Date Using this Format MM/DD/YYYY");

            string tempenddate;
            DateTime enddate;

            do
            {
                tempenddate = Console.ReadLine();
                enddate = ValidateDateInput(tempenddate);
                if (enddate < startdate)
                {
                    Console.WriteLine("Wrong input Ending Date cant be earlier than Starting Date");
                }
            } while (enddate<startdate);
                
            
            Course c1 = new Course() { Title= title, Stream = stream, Type = type,StartDate=startdate,EndDate=enddate };
            db.Courses.Add(c1);
            db.SaveChanges();

            Console.Clear();

        }

        public static void CreateTrainer(MISKALSCHOOLEntities db)
        {

            Console.WriteLine("Input Trainer's First Name");
            string firstname ="";
            do
            {
                firstname = Console.ReadLine();

            } while (!Validation.StringValidation(firstname));
            Console.WriteLine("Input Trainer's Last Name");
            
            string lastname = "";
            do
            {
                lastname = Console.ReadLine();

            } while (!Validation.StringValidation(lastname));
           
            Console.WriteLine("Input Trainer's Subject");
            string subject = "";
            
            do
            {
                subject = Console.ReadLine();

            } while (!Validation.StringValidation2(subject));

            Trainer t1 = new Trainer() { FirstName = firstname, LastName = lastname, Subject=subject };
            db.Trainers.Add(t1);
            db.SaveChanges();

            Console.Clear();

        }


        public static void CreateStudent(MISKALSCHOOLEntities db)
        {

            Console.WriteLine("Input Student's First Name");
            string firstname = "";
            do
            {
                firstname = Console.ReadLine();

            } while (!Validation.StringValidation(firstname));

            Console.WriteLine("Input Student's Last Name");
            string lastname ="";
            do
            {
                lastname = Console.ReadLine();

            } while (!Validation.StringValidation(lastname));

            Console.WriteLine("Input Student's Date of birth (Please use this format : mm/dd/yyyy");
            string birthdayTemp = Console.ReadLine();
            DateTime birthday = ValidateDateInput(birthdayTemp);

            Console.WriteLine("Input Student's Fees");
            string tempfee = Console.ReadLine();
            int fee = ValidateNumber(tempfee);

            

            Student s1 = new Student() { FirstName = firstname, LastName = lastname, BirthDate = birthday, TuitionFees = fee };
            db.Students.Add(s1);
            db.SaveChanges();

            Console.Clear();

        }

        //===========================VALIDATIONS====================================


        //date Validation
        public static DateTime ValidateDateInput(string date)
        {
            DateTime tempDate;
            while (!DateTime.TryParse(date, out tempDate))
            {

                Console.WriteLine("Input valid date");
                date = Console.ReadLine();

            }
            DateTime endDate = Convert.ToDateTime(date);
            return endDate;
        }


        //number validation
        public static int ValidateNumber(string end)
        {
            int temp;
            while (!int.TryParse(end, out temp))
            {
                Console.WriteLine("Enter Valid number");
                end = Console.ReadLine();
            }
            int number = Convert.ToInt32(end);
            return number;
        }


        public static DateTime ValidateDateInput2(string date)
        {
            DateTime tempDate;
            while (!DateTime.TryParse(date, out tempDate))
            {

                Console.WriteLine("Input valid date");
                date = Console.ReadLine();

            }
            DateTime endDate = Convert.ToDateTime(date);
            return endDate;
        }

        public bool StringValidation(string input)
        {
            Regex rgx = new Regex("/^[A-Za-z]+$/;");

            if (input.Length < 3)
            {
                Console.WriteLine("The input text length can't be less than 3 characters.");
                return false;
            }
            if (input.Length > 20)
            {
                Console.WriteLine("The input text length can't be more than 20 characters.");
                return false;
            }
            if (!rgx.IsMatch(input))
            {
                Console.WriteLine("The input text must contain only latin characters");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("The input text cant be Blank.");
                return false;
            }
            return true;
        }

    }
}
