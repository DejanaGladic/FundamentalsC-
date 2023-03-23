namespace FundamentalsC_.Data
{
    public class Database
    {
        public List<Student> students = new List<Student> { 
            new Student("Jack", "Jackson"),
            new Student("Mark", "Markson"),
            new Student("Philip", "Philipson")
        };

        public List<Subject> subjects = new List<Subject> {
            new Subject("Algebra"),
            new Subject("Mathematics"),
            new Subject("Biology")
        };

        public List<StudentSubject> studentSubject = new List<StudentSubject>();
    }
}
