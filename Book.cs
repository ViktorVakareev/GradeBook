namespace GradeBook.src
{
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);   // abstract method - body in derived classes

        public abstract Statistics GetStatistics();
        
    }
}
