using System;
using System.Collections.Generic;
using System.Text;

namespace GradebookApp
{
    public class Gradebook
    {
        //Class variable list to store grades
        private readonly List<double> grades = new(); //Calls constructor for a blank list

        //Add single grade
        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100." );
            grades.Add(grade);
        }

        //Overload method: add multiple grades at once
        public void AddGrade(IEnumerable<double> grades)
        {
            foreach (var g in grades)
                AddGrade(g);
            
        }

        //Get average method

        //Get highest grade method

        //Get lowest grade method

        //Get count method

        //Clear all grades method
    }
}
