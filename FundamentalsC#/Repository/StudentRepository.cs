using FundamentalsC_.Data;
using FundamentalsC_.Interfaces;

namespace FundamentalsC_.Repository
{
    public class StudentRepository : IStudentRepository
    {
        Database _database = new Database();
        public List<Student> GetAll()
        {
           return  _database.students;
        }

        public void AddNewStudents(List<Student> students)
        {
            _database.students.AddRange(students);
        }

        public Student GetStudentByName(string firstName, string lastName)
        {
           return _database.students.Where(studentFromList => 
                studentFromList.FirstName == firstName && 
                studentFromList.LastName == lastName).Select(student => student).ToList()[0];
        }
        public bool IsPresent(string firstName, string lastName)
        {
            return _database.students.Any(student =>
                 student.FirstName == firstName &&
                 student.LastName == lastName);
        }

    }
}
