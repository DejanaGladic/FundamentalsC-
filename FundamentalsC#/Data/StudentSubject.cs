using System.Diagnostics;

namespace FundamentalsC_.Data
{
    public class StudentSubject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public List<int> Grades { get; set; }

        public StudentSubject(Student student, Subject subject) {
            Student = student;
            Subject = subject;
            Grades = new List<int>();
        }

        public override string ToString()
        {
            string grades = "";
            for (int i = 0; i < Grades.Count(); i++)
            {
                if (i == Grades.Count() - 1) {
                    grades += Grades[i];
                    break;
                }

                grades += Grades[i] + ", ";
            }
            return Student+" "+Subject+" ["+grades+"]";
        }

    }
}
