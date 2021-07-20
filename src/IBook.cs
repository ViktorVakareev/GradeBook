namespace GradeBook.src
{
    interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        public event GradeAddedDelegate GradeAdded;
    }
}
