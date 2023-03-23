using FundamentalsC_.Data;
using FundamentalsC_.Interfaces;

namespace FundamentalsC_.Repository
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        Database _database = new Database();
        public List<StudentSubject> GetAll()
        {
            return _database.studentSubject;
        }

        public bool IsPresent(Student student, Subject subject)
        {
            return _database.studentSubject.Any(studentSubject =>
                 studentSubject.Student.FirstName == student.FirstName &&
                 studentSubject.Student.LastName == student.LastName &&
                 studentSubject.Subject.SubjectName == subject.SubjectName);
        }

        public void AddNewStudentSubject(StudentSubject studentSubject)
        {
            _database.studentSubject.Add(studentSubject);
        }

        public StudentSubject GetStudentSubject(Student student, Subject subject)
        {
            return _database.studentSubject.Where(studentSubjectFromList =>
                 studentSubjectFromList.Student.FirstName == student.FirstName &&
                 studentSubjectFromList.Student.LastName == student.LastName &&
                 studentSubjectFromList.Subject.SubjectName == subject.SubjectName)
                .Select(studentSubject => studentSubject).ToList()[0];
        }

        public List<StudentSubject> GetStudentSubjectByStudent(Student student)
        {
            return _database.studentSubject.Where(studentSubjectFromList =>
                 studentSubjectFromList.Student.FirstName == student.FirstName &&
                 studentSubjectFromList.Student.LastName == student.LastName).ToList();
        }

        public List<int> GetGradesByStudent(Student student) { 
            return GetStudentSubjectByStudent(student)[0].Grades;
        }

    }
}
