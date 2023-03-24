using FundamentalsC_.Data;

namespace FundamentalsC_.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        void AddNewStudents(List<Student> students);

        Student GetStudentByName(string firstName, string lastName);

        public bool IsPresent(string firstName, string lastName);

    }
}
