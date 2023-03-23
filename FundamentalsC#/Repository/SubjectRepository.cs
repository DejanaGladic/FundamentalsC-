using FundamentalsC_.Data;
using FundamentalsC_.Interfaces;

namespace FundamentalsC_.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        Database _database = new Database();

        public List<Subject> GetAll()
        {
            return _database.subjects;
        }

        public Subject GetSubjectByName(string subjectName)
        {
            return _database.subjects.Where(subject =>
                subject.SubjectName == subjectName).Select(subject => subject).ToList()[0];
        }
    }
}
