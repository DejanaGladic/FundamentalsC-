using FundamentalsC_.Data;

namespace FundamentalsC_.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAll();

        Subject GetSubjectByName(string subjectName);

        bool IsPresent(string subjectName);
    }
}
