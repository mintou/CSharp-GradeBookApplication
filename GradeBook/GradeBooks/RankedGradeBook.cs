using System;
using System.Collections.Generic;
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
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            List<double> grades = new List<double>();
            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();

            double GradeRank = 0;
            for(int i = 0; i< grades.Count; i++)
            {
                if (averageGrade > grades[i])
                {
                    GradeRank = ((i + 1)/grades.Count*100);
                }
            }

            if (GradeRank >= 80)
                return 'A';
            else if (GradeRank >= 60)
                return 'B';
            else if (GradeRank >= 40)
                return 'C';
            else if (GradeRank >= 20)
                return 'D';
            else
                return 'F';

        }

    }
}
