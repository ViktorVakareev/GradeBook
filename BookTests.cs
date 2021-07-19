using System;
using Xunit;
using GradeBook;

namespace GradeBook_Tests
{
    public class BookTests
    {
        Book book = new Book("Test book");

        [Fact]
        public void Test1()
        {
            // arrange
            book.AddGrade(80.1);
            book.AddGrade(88.1);
            book.AddGrade(90.1);
            // act
            var result = book.ShowStatistics();
            // assert
            Assert.Equal(86.1, result.Average, 1);
            Assert.Equal(90.1, result.High);
            Assert.Equal(80.1, result.Low);
           
        }
    }
}
