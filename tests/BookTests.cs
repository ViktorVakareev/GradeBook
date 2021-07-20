using System;
using Xunit;
using GradeBook;
using GradeBook.src;

namespace GradeBook.Tests
{
    public class BookTests
    {
        
        [Fact]
        public void TestBookCalculatesAverageGrade()
        {
            InMemoryBook book = new InMemoryBook("Test book");
            // arrange
            book.AddGrade(80.1);
            book.AddGrade(88.1);
            book.AddGrade(90.1);
            // act
            var result = book.GetStatistics();
            // assert
            Assert.Equal(86.1, result.Average, 1);
            Assert.Equal(90.1, result.High);
            Assert.Equal(80.1, result.Low);
            Assert.Equal('B', result.Letter);

        }
    }
}
