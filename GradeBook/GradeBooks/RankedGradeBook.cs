using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {

            Name = name;
            Type = GradeBookType.Ranked;
            Students = new List<Student>();
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5) {
                throw new InvalidOperationException();
            }

            double twentyPercentOfStudents = 0.2 * Students.Count;
            
            if (averageGrade >= 90)
                return 'A';
            else if (averageGrade >= 80)
                return 'B';
            else if (averageGrade >= 70)
                return 'C';
            else if (averageGrade >= 60)
                return 'D';
            else
                return 'F';
        }
    }
}
