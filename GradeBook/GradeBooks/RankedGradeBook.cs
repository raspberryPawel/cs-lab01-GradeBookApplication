using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;
using System.Diagnostics;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {

            Name = name;
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int countAllNotes = 0;
            int countBetterNotes = 0;

            Students.ForEach(delegate (Student student) {
                student.Grades.ForEach(delegate (double grade)
                {
                    countAllNotes++;
                    if (averageGrade > grade)
                    {
                        countBetterNotes++;
                    }
                });
            });

            double twentyPercentOfStudents = 0.2 * countAllNotes;

            if (countBetterNotes >= 4 * twentyPercentOfStudents)
                return 'A';
            else if (countBetterNotes >= 3 * twentyPercentOfStudents)
                return 'B';
            else if (countBetterNotes >= 2 * twentyPercentOfStudents)
                return 'C';
            else if (countBetterNotes >= twentyPercentOfStudents)
                return 'D';
            else
                return 'F';
        }
    }
}

/*
 * 
  if (Students.Count > 0)
            {
                throw new InvalidOperationException();
            }
            int countGrades = 0;
            Students.ForEach(delegate (Student student) {
                student.Grades.ForEach(delegate (double grade)
                {
                    if (grade > 0)
                    {
                        countGrades++;
                    }
                });
            });
           

            double twentyPercentOfStudents = 0.2 * Students.Count;
            int countNotes = 0;

            Students.ForEach(delegate(Student student){
                Console.WriteLine(student);
                student.Grades.ForEach(delegate (double grade)
                {
                    if (averageGrade > grade) {
                        countNotes++;
                    }
                });
            });

*/