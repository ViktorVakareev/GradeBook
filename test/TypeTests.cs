using System;
using Xunit;
using GradeBook;
using GradeBook.src;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        // DELEGATE
        public delegate string WriteLogDelegate(string logMessage);
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessageToUpperCase;    // we assign an initial value
            
            log += ReturnMessageToUpperCase;    // log = new WriteLogDelegate(ReturnMessage);
            log += IncrementCount;
            var result = log("Hello!");

            Assert.Equal(3, count);
            Assert.Equal("hello!", result);
        }
        // write method that matches Delegate return type and parameter type
        string ReturnMessageToUpperCase(string message) 
        {
            count++;
            return message.ToUpper();
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void StringBehavesLikeValueTypes()   //Strings are immutable
        {
            string name = "Scott";
            MakeUpperCase(name);
            var upperName = MakeUpperCase(name);
            Assert.Equal("SCOTT", upperName);
            Assert.Equal("Scott", name);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();  // returns a new string 
        }

        [Fact]
        public void ValueTypesCanPassByReference()
        {
            var x = GetInt();
            SetInt(ref x);


            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }
        [Fact]
        public void ValueTypesPassByValue()
        {
            var x = GetInt();
            

            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ReturnDifferentObject()
        {

            InMemoryBook book1 = GetBook("Book1");
            InMemoryBook book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            InMemoryBook book1 = GetBook("Book1");
            InMemoryBook book2 = book1;

            Assert.Same(book1, book2);

        }
        [Fact]
        public void SettingNameFromReference()
        {

            InMemoryBook book1 = GetBook("Book1");
            SetName(book1, "New Book");

            Assert.Equal("New Book", book1.Name);

        }
        [Fact]
        public void CSharpIsPassByValue()   // pass by VALUE - Default behaviour
        {
            InMemoryBook book1 = GetBook("Book1");
            GetBookSetName(book1, "New Book");

            Assert.Equal("Book1", book1.Name);

        }
        [Fact]
        public void CSharpCanPassByReference()    // pass by REFERENCE - exclusive behaviour
        {
            InMemoryBook book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New Book");

            Assert.Equal("New Book", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
