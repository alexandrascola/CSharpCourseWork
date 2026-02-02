using System;
using System.Collections.Generic;
using System.Text;

namespace Gradebook.Tests
{
    public class GradebookTests
    {
        //Succesfully add valid grade
        [Fact]
        public void AddGrade_AddsValidGrade()
        { 
            var book = new Gradebook();
            book.AddGrade(90);
            Assert.Equal(1, book.GetCount());
        }
        //Reject invalid grade
        [Fact]
        public void AddGrade_RejectsInvalidGrade()
        {
            var book = new Gradebook();
            Assert.Throws<ArgumentOutOfRangeException>( () => book.AddGrade(150));
        }

        //Get correct average
        [Fact]
        public void GetAverage_ReturnsCorrectAverage()
        {
            var book = new Gradebook();
            book.AddGrade(new List<double> { 80, 90, 100 });
            Assert.Equal(90, book.GetAverage(), 2);
        }

        //Validate highest and lowest grades
        [Fact]
        public void GetHighestAndLowest_WorksCorrectly()
        {
            var book = new Gradebook();
            book.AddGrade(new List<double> { 70, 85, 95 });
            Assert.Equal(95, book.GetHighest());
            Assert.Equal(70, book.GetLowest());
        }
    }
}
