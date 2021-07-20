using GradeBook.src;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new InMemoryBook("Victor's book");
            IBook book = new DiskBook("Victor's DiskBook");

            // 3. we handle the GradeAdded event
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The name of the constant is {InMemoryBook.CATEGORY}");
            //Console.WriteLine($"The name of the readonly is {book.category}");
            Console.WriteLine($"The name of the book is {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The average letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)    // grade not in range
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)   // input is invalid, cannot be parsed correctly
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
