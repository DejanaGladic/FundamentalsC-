using FundamentalsC_.Data;

namespace FundamentalsC_.Interfaces
{
    public interface IStudentSubjectRepository
    {
        List<StudentSubject> GetAll();
        public bool IsPresent(Student student, Subject subject);

        public void AddNewStudentSubject(StudentSubject studentSubject);

        public StudentSubject GetStudentSubject(Student student, Subject subject);

        public List<int> GetGradesByStudent(Student student);

        public List<StudentSubject> GetStudentSubjectByStudent(Student student);

    }
}
