using GradeBook.src;
using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt") ;
            writer.WriteLine(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
            writer.Dispose();  // clean-up and free memory and closes file
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            var reader = File.OpenText($"{Name}.txt");
            var line = reader.ReadLine();
            while (line != null) 
            {
                result.Add(double.Parse(line));
                line = reader.ReadLine();                
            }

            reader.Dispose();
            return result;
           
        }
    }
}