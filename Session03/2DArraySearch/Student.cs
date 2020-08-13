using System;
using System.Collections.Generic;
using System.Text;

namespace _2DArraySearch
{
    public class Student
    {
        public Student(int studentId, string studentName, float percentageMarks)
        {
            StudentId = studentId;
            StudentName = studentName;
            PercentageMarks = percentageMarks;
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public float PercentageMarks { get; set; }
    }
}
