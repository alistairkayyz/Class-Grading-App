using System;
using System.Collections.Generic;
using System.Text;

namespace Grading_System
{
    class StudentGrades
    {
        // declare a 2D array to store the student grades
        private int[,] Grades;

        // declare 1D array to store students averages
        private double[] StudentAverages;

        // declare 1D array to store students symbols
        private char[] StudentSymbols;

        // declare 1D array to store asteriks
        private int[] distribution = new int[11];

        private int min;
        private int max;

        private double classAverage;

        public StudentGrades(int rows, int cols)
        {
            Grades = new int[rows, cols];
            StudentAverages = new double[rows];
            StudentSymbols = new char[rows];
        }

        // set array Grades
        public void setGrades()
        {
            // rows for each student
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                Console.WriteLine("\nEnter the grades of student {0}", (i + 1));

                // columns for each grade
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    while (true)
                    {
                        Console.Write("Grade {0}: ", (j + 1));

                        // temporary variable
                        int grade = Convert.ToInt32(Console.ReadLine());

                        // validate the grade before storing it in an array
                        if (ValidateGrades(grade))
                        {
                            Grades[i, j] = grade;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Make sure grade is between 0 & 100");
                            continue;
                        }
                    }
                }
            }
        }

        public void setStudentSymbols()
        {
            // determine the symbol
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                if (StudentAverages[i] >= 0 && StudentAverages[i] <= 59)
                    StudentSymbols[i] = 'F';

                else if (StudentAverages[i] >= 60 && StudentAverages[i] <= 69)
                    StudentSymbols[i] = 'D';

                else if (StudentAverages[i] >= 70 && StudentAverages[i] <= 79)
                    StudentSymbols[i] = 'C';

                else if (StudentAverages[i] >= 80 && StudentAverages[i] <= 89)
                    StudentSymbols[i] = 'B';

                else if (StudentAverages[i] >= 90 && StudentAverages[i] <= 100)
                    StudentSymbols[i] = 'A';
            }
        }

        public void setOverallClassAverage()
        {
            // overall class average            
            double totalAverages = 0;

            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                totalAverages += StudentAverages[i];
            }

            classAverage = totalAverages / Grades.GetLength(0);
        }

        public void setDistribution()
        {
            // store the grades distribution in a distribution array
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                // columns for each grade
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    // for each grade, increment the appropriate frequency
                    ++distribution[Grades[i, j] / 10];
                }
            }
        }

        public void Display()
        {       
            // print the header text for the grades
            Console.WriteLine("\n-------------- Student Grades --------------");
            Console.Write("\t");
            for (int i = 0; i <= Grades.GetLength(1); i++)
            {
                if (i != Grades.GetLength(1))
                    Console.Write("\tTest {0}", (i + 1));
                else
                    Console.WriteLine("\tAverage");
            }
            // display the grades
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                Console.Write("Student {0}", (i + 1));

                // columns for each grade
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    Console.Write("\t{0}", Grades[i, j]);
                }

                Console.WriteLine("\t{0}", StudentAverages[i]);
            }
            // display symbols
            Console.WriteLine("\n----------- Student Symbols -----------");
            Console.WriteLine("\nStudent \tSymbol");
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                Console.WriteLine("Student {0} \t{1}", (i + 1), StudentSymbols[i]);
            }

            // display class average
            Console.WriteLine("\nThe class average is: {0}", classAverage);

            // display min value
            Console.WriteLine("\nLowest Grade: {0}", getMin());

            // display max value
            Console.WriteLine("Highest Grade: {0}", getMax());            

            // display the grades distribution5
            Console.WriteLine("\nOverall Class Distribution:");
            for (int count = 0; count < distribution.Length; count++)
            {
                if (count == 10)
                    Console.Write("100:\t");
                else
                    Console.Write("{0}-{1}:\t", count * 10, count * 10 + 9);

                for (int stars = 0; stars < distribution[count]; stars++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }

        public void setStudentAverages()
        {
            // calculate the averages of each student
            // rows for each student
            int totalGrades;
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                totalGrades = 0;
                // columns for each grade
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    totalGrades += Grades[i, j];
                }

                StudentAverages[i] = totalGrades / Grades.GetLength(1);
            }
        }

        // set maximum grade
        public void setMax()
        {
            max = Grades[0, 0];
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    if (max < Grades[i, j])
                    {
                        max = Grades[i, j];
                    }
                }
            }
        }

        // get maximum grade
        public int getMax()
        {
            return max;
        }

        // set minimum grade
        public void setMin()
        {
            min = Grades[0, 0];
            for (int i = 0; i < Grades.GetLength(0); i++)
            {
                for (int j = 0; j < Grades.GetLength(1); j++)
                {
                    if (min > Grades[i, j])
                    {
                        min = Grades[i, j];
                    }
                }
            }
        }

        // get minimum grade
        public int getMin()
        {
            return min;
        }

        // validate the grades
        private bool ValidateGrades(int input)
        {
            if (input >= 0 && input <= 100)
                return true;
            else
                return false;
        }
    }
}
