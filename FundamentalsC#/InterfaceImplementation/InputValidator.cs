using FundamentalsC_.Interfaces;

namespace FundamentalsC_.InterfaceImplementation
{
    public class InputValidator: IValidator
    {
        public bool CheckInputFormatForMultipleStudents(string? student) {
            if (student.Split(" ").Count() > 2 && !student.Contains(","))
            {
                return false;
            }
            return true;
        }

        public bool CheckInputFormatForGradeValue(string gradeValue) {
            int gradeInt;
            if (!int.TryParse(gradeValue, out gradeInt) || gradeInt < 1 || gradeInt > 5)
            {
                return false;
            }
            return true;
        }
    }
}
