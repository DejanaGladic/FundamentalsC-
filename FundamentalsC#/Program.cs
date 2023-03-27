using FundamentalsC_.Data;
using FundamentalsC_.InterfaceImplementation;
using FundamentalsC_.Interfaces;
using FundamentalsC_.Repository;
using System;

ISubjectRepository subjectRepository = new SubjectRepository();
IStudentRepository studentRepository = new StudentRepository();
IStudentSubjectRepository studentSubjectRepository = new StudentSubjectRepository();
IValidator validator = new InputValidator();
List<Student> newStudentsList = new List<Student>();

string student;
string[] insertedStudents;
Student returnedStudent;

while (true) {

    Console.WriteLine("Choose the option");
    Console.WriteLine("1. List all subjects");
    Console.WriteLine("2. Insert new students");
    Console.WriteLine("3. Insert grade for students subject");
    Console.WriteLine("4. List subjects and grades of desired student");
    Console.WriteLine("5. Leave the app");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            GetAllSubjects();            
            break;
        case "2":
            InsertNewStudent();           
            break;
        case "3":
            InsertNewStudentsGrade();           
            break;
        case "4":
            GetGradesByStudent();           
            break;
        case "5":
            return;
        default:
            break;
    }

}

void GetGradesByStudent()
{
    Console.WriteLine("Insert the students name");
    student = Console.ReadLine();
    insertedStudents = student.Split(", ");

    returnedStudent = studentRepository.GetStudentByName(insertedStudents[0].Split(" ")[0],
        insertedStudents[0].Split(" ")[1]);

    var sumOfGrades = 0;
    List<StudentSubject> returnedStudentSubject = studentSubjectRepository.GetStudentSubjectByStudent(returnedStudent);
    foreach (var stSubj in returnedStudentSubject)
    {
        Console.WriteLine(stSubj.Subject);
        stSubj.Grades.ForEach(grade => { sumOfGrades += grade; });
        CalculateAverageGrade(sumOfGrades, stSubj.Grades.Count());       
        sumOfGrades = 0;
    }
}

void InsertNewStudentsGrade()
{
    Console.WriteLine("Insert the students name");
    student = Console.ReadLine();
    var stFirstName = student.Split(" ")[0];
    var stLastName = student.Split(" ")[1];

    if (!studentRepository.IsPresent(stFirstName, stLastName))
    {
        Console.WriteLine($"The student {stFirstName} {stLastName} is not present");
        return;
    }
    returnedStudent = studentRepository.GetStudentByName(stFirstName, stLastName);

    Console.WriteLine("Insert the subject name");
    var subjectName = Console.ReadLine();
    if (!subjectRepository.IsPresent(subjectName))
    {
        Console.WriteLine($"The subject {subjectName} is not present");
        return;
    }
    Subject returnedSubject = subjectRepository.GetSubjectByName(subjectName);

    Console.WriteLine("Insert the grade (from 1 to 5)");
    var grade = Console.ReadLine();

    if (!validator.CheckInputFormatForGradeValue(grade)) {
        Console.WriteLine($"Form of input is not valid");
        return;
    }

    StudentSubject studentSubject;

    if (studentSubjectRepository.IsPresent(returnedStudent, returnedSubject))
    {
        studentSubject = studentSubjectRepository.GetStudentSubject(returnedStudent, returnedSubject);
        studentSubject.Grades.Add(int.Parse(grade));
    }
    else
    {
        studentSubject = new StudentSubject(returnedStudent, returnedSubject);
        studentSubject.Grades.Add(int.Parse(grade));
        studentSubjectRepository.AddNewStudentSubject(studentSubject);
    }
}

void InsertNewStudent()
{
    student = Console.ReadLine();

    if (!validator.CheckInputFormatForMultipleStudents(student)) {
        Console.WriteLine($"Form of input is not valid");
        return;
    }

    insertedStudents = student.Split(", ");

    foreach (var insertedStudent in insertedStudents.ToList())
    {
        var firstName = insertedStudent.Split(" ")[0];
        var lastName = insertedStudent.Split(" ")[1];
        if (studentRepository.IsPresent(firstName, lastName))
        {
            Console.WriteLine($"The student {firstName} {lastName} is present");
            continue;
        }
        newStudentsList.Add(new Student(firstName, lastName));
    }
    studentRepository.AddNewStudents(newStudentsList);
}

void GetAllSubjects()
{
    var subjects = subjectRepository.GetAll().ToList();
    subjects.ForEach(subject => Console.WriteLine(subject));
}

void CalculateAverageGrade(int sumOfGrades, int numberOfGrades)
{
    decimal average = 0;
    average = (decimal)sumOfGrades / numberOfGrades;
    Console.WriteLine($"    ==> Prosecna ocena je: [{average}]");
    Console.WriteLine("Success is: " + averageGrade(average));
}

string averageGrade(decimal average) {
    if (average >= 4.5m && average <=5m) {
        return "Excellent";
    } else if (3.5m >= average && average < 4.5m) {
        return "Very good";
    } else if (2.5m >= average && average < 3.5m){
        return "Good";
    } else if (1.5m >= average && average < 2.5m){
        return "Enough";
    }
    return "Not enough";
}





