using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");

            int studentsPerGrade = (int)Math.Ceiling(Students.Count * .2);
            List<double> grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[studentsPerGrade - 1] <= averageGrade)
                return 'A';
            if (grades[(studentsPerGrade * 2) - 1] <= averageGrade)
                return 'B';
            if (grades[(studentsPerGrade * 3) - 1] <= averageGrade)
                return 'C';
            if (grades[(studentsPerGrade * 4) - 1] <= averageGrade)
                return 'D';

            return 'F';
        }
    }
}
