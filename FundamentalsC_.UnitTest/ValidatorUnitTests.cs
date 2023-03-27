using FundamentalsC_.InterfaceImplementation;
using FundamentalsC_.Interfaces;
using NUnit.Framework;

namespace FundamentalsC_.UnitTest
{
    [TestFixture]
    public class ValidatorUnitTests
    {
        IValidator inputValidator;
        string student;
        string gradeValue;

        [SetUp]
        public void SetUp()
        {
            inputValidator = new InputValidator();
        }

        [Test]
        public void InputFormatMultipleStudents_MultipleStudentsWithoutComma_ReturnsFalse()
        {
            student = "Dejana Gladic Marina Markovic";
            var result = inputValidator.CheckInputFormatForMultipleStudents(student);
            Assert.That(result, Is.False);
        }

        [Test]
        public void InputFormatMultipleStudents_MultipleStudentsWithComma_ReturnsTrue()
        {
            student = "Dejana Gladic, Marina Markovic";
            var result = inputValidator.CheckInputFormatForMultipleStudents(student);
            Assert.That(result, Is.True);
        }

        [Test]
        public void InputFormatForGradeValue_NotInteger_ReturnsFalse()
        {
            gradeValue = "grade";
            var result = inputValidator.CheckInputFormatForGradeValue(gradeValue);
            Assert.That(result, Is.False);
        }

        [Test]
        public void InputFormatForGradeValue_Integer_ReturnsTrue()
        {
            gradeValue = "5";
            var result = inputValidator.CheckInputFormatForGradeValue(gradeValue);
            Assert.That(result, Is.True);
        }

        [Test]
        public void InputFormatForGradeValue_GreaterThanAccepted_ReturnsFalse()
        {
            gradeValue = "10";
            var result = inputValidator.CheckInputFormatForGradeValue(gradeValue);
            Assert.That(result, Is.False);
        }

        [Test]
        public void InputFormatForGradeValue_LessThanAccepted_ReturnsFalse()
        {
            gradeValue = "-10";
            var result = inputValidator.CheckInputFormatForGradeValue(gradeValue);
            Assert.That(result, Is.False);
        }

        [Test]
        public void InputFormatForGradeValue_InAcceptedRange_ReturnsTrue()
        {
            gradeValue = "3";
            var result = inputValidator.CheckInputFormatForGradeValue(gradeValue);
            Assert.That(result, Is.True);
        }
    }
}