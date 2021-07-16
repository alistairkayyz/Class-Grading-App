using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grading_System
{
    class Program
    {
        // validate the array size
        static Boolean ValidateArraySize(int input)
        {
            if (input > 0)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            // variables to set the array size
            int numberOfStudents;
            int numberOfGrades;

            // set the number of students
            while (true)
            {
                Console.Write("How many students do you have? ");
                numberOfStudents = Convert.ToInt32(Console.ReadLine());

                // validate the input
                if (ValidateArraySize(numberOfStudents))
                    break;
                else
                    Console.WriteLine("\nNumber of students cannot be 0!");
            }

            // set the number of grades
            while (true)
            {
                Console.Write("Total number of grades? ");
                numberOfGrades = Convert.ToInt32(Console.ReadLine());

                // validate the input
                if (ValidateArraySize(numberOfGrades))
                    break;
                else
                    Console.WriteLine("\nTotal number of grades cannot be 0!");
            }

            StudentGrades studentGrades = new StudentGrades(numberOfStudents, numberOfGrades);

            studentGrades.setGrades();
            studentGrades.setStudentAverages();
            studentGrades.setOverallClassAverage();
            studentGrades.setStudentSymbols();
            studentGrades.setMin();
            studentGrades.setMax();
            studentGrades.setDistribution();
            studentGrades.Display();            

            Console.ReadKey();
        }
    }
}
