using GradeBook.src;
using System;
using System.Collections.Generic;

namespace GradeBook
{
   public class Book
    {
        private List<double> grades;  //field - only accessible in this class
        private string name;
        public Book(string name)   // Constructor - special method
        {
            this.name = name;
            grades = new List<double>();
        }

       public Statistics ShowStatistics()  // returns object of type Statistics
        {
           
            var result = new Statistics();
            
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        public void AddGrade(double grade)  
        {
            grades.Add(grade);
        }
    }
}
