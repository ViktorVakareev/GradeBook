using System;

namespace GradeBook.src
{
    public class Statistics
    {
        public double Average     // property
        {
            get
            {
                return Sum / Count;
            }
        }

        public double High;     // fields
        public double Low;
        public double Sum;
        public int Count;
        public char Letter
        {
            get
            {  // pattern matching switch
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'Á';                        
                    case var d when d >= 80:
                        return 'B';                        
                    case var d when d >= 70:
                        return 'C';                       
                    case var d when d >= 60:
                        return 'D';                        
                    default:
                        return 'F';                       
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }
        public void Add(double number)
        {
            Sum += number;
            Count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
    }
}
