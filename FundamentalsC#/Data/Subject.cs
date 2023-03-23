namespace FundamentalsC_.Data
{
    public class Subject
    {
        public string SubjectName { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
        }

        public override string ToString() { 
            return SubjectName;
        }
    }
}
