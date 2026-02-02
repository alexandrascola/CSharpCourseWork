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
        public double GetAverage()
        {
            if (grades.Count == 0) return 0;
            double total = 0;
            foreach (var g in grades)
                total += g;
            return total / grades.Count;
        }
    
        //Get highest grade method
        public double GetHighest() => grades.Count == 0 ? 0 : grades.Max();

        //Get lowest grade method
        public double GetLowest() => grades.Count == 0 ? 0 : grades.Min();

        //Get count method
        public int GetCount() => grades.Count;

        //Clear all grades method
        public void Clear() => grades.Clear();
    }
}
