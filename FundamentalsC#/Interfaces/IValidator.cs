namespace FundamentalsC_.Interfaces
{
    public interface IValidator
    {
        public bool CheckInputFormatForMultipleStudents(string? student);
        public bool CheckInputFormatForGradeValue(string gradeValue);

    }
}
