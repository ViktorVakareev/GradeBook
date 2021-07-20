using GradeBook.src;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    // we want to declare event though delegate-it has by convention two parameters(object, EventArgs)

    public class InMemoryBook : Book
    {
        public const string CATEGORY = "Science";  // accessed like static member, cannot change through ctor
        public readonly string category = "Other Science";  // can be changed only through ctor

        private List<double> grades;
     
        public override event GradeAddedDelegate GradeAdded; // 1. we add Event

        public InMemoryBook(string name) : base(name)  // we make call to base ctor
        {
            Name = name;
            grades = new List<double>();
        }

        public override Statistics GetStatistics()  // returns object of type Statistics
        {

            var result = new Statistics();         

            foreach (var grade in grades)
            {
                result.Add(grade);   
            }

            return result;
        }
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(100);
                    break;
                case 'B':
                    AddGrade(90);
                    break;
                case 'C':
                    AddGrade(80);
                    break;
                default:
                    AddGrade(0);
                    break;

            }
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs()); // 2. we add Event
                }
            }
            else
            {
                throw new ArgumentException($"Invalid grade {nameof(grade)}");
                //Console.WriteLine("Invalid value");
            }

        }

    }
}
