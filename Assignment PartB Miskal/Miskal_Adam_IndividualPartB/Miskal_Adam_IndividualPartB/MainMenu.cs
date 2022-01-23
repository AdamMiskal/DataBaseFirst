using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miskal_Adam_IndividualPartB
{
    class MainMenu
    {
        public static void MainMenu1(MISKALSCHOOLEntities db)
        {
            Console.WriteLine("WELCOME TO MISKAL SCHOOL");
            string input;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose an Option");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" 1 - List of all the Students");
                Console.WriteLine(" 2 - List of all the Trainers");
                Console.WriteLine(" 3 - List of all the Assignments");
                Console.WriteLine(" 4 - List of all the Courses");
                Console.WriteLine(" 5 - All Students per Course");
                Console.WriteLine(" 6 - All Trainers per Course");
                Console.WriteLine(" 7 - All the Assignments per Course");
                Console.WriteLine(" 8 - All the Assignment per Course per Student");
                Console.WriteLine(" 9 - A list of Students that belong to more than one courses");
                Console.WriteLine(" 10 - Create Student");
                Console.WriteLine(" 11 - Create Trainer");
                Console.WriteLine(" 12 - Create Assignment");
                Console.WriteLine(" 13 - Create Course");
                Console.WriteLine(" 14 - Enrol e Student to a Course");
                Console.WriteLine(" 15 - Select Trainer to teach a Course");
                Console.WriteLine(" 16 - Create Assignment per Course per Student");
                input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1": View.PrintStudents(db); ; break;
                    case "2": View.PrintTrainers(db); break;
                    case "3": View.PrintAssignments(db); break;
                    case "4": View.PrintCourses(db); break;
                    case "5": View.PrintStudentPerCourse(db); break;
                    case "6": View.PrintTrainerPerCourse(db); break;
                    case "7": View.PrintAssignmentPerCourse(db); break;
                    case "8": View.PrintAssignmentPerCoursePerStudent(db); break;
                    case "9": View.PrintStudentWithMoreCourses(db); break;
                    case "10": Create.CreateStudent(db); ; break;
                    case "11": Create.CreateTrainer(db); ; break;
                    case "12": Create.CreateAssignment(db); ; break;
                    case "13": Create.CreateCourse(db); ; break;
                    case "14": Create.EnrolStudentToCourse(db); break;
                    case "15": Create.EnrolTrainerToCourse(db); break;
                    case "16": Console.WriteLine(" 16 - Create Assignment per student per course"); ; break;
                    default: Console.WriteLine(""); break;
                }



            } while (input != "E" && input != "e");


        }

    }
}
