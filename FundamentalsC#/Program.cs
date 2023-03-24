using FundamentalsC_.Data;
using FundamentalsC_.Interfaces;
using FundamentalsC_.Repository;

ISubjectRepository subjectRepository = new SubjectRepository();
IStudentRepository studentRepository = new StudentRepository();
IStudentSubjectRepository studentSubjectRepository = new StudentSubjectRepository();
List<Student> newStudentsList = new List<Student>();

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
            var subjects = subjectRepository.GetAll().ToList();
            subjects.ForEach(subject => Console.WriteLine(subject));
            break;
        case "2":
            var student = Console.ReadLine();

            if (student.Split(" ").Count() > 2 && !student.Contains(",")) {
                Console.WriteLine($"Form of input is not valid");
                break;
            }
            var insertedStudents = student.Split(", ");

            foreach (var insertedStudent in insertedStudents.ToList())
            {
                var firstName = insertedStudent.Split(" ")[0];
                var lastName = insertedStudent.Split(" ")[1];
                if (studentRepository.IsPresent(firstName, lastName)) {
                    Console.WriteLine($"The student {firstName} {lastName} is present");
                    continue;
                }
                newStudentsList.Add(new Student(firstName, lastName));
            } 
            studentRepository.AddNewStudents(newStudentsList);
            break;
        case "3":
            Console.WriteLine("Insert the students name");
            student = Console.ReadLine();
            var stFirstName = student.Split(" ")[0];
            var stLastName = student.Split(" ")[1];

            if (!studentRepository.IsPresent(stFirstName, stLastName))
            {
                Console.WriteLine($"The student {stFirstName} {stLastName} is not present");
                break;
            }
            Student returnedStudent = studentRepository.GetStudentByName(stFirstName, stLastName);

            Console.WriteLine("Insert the subject name");
            var subjectName = Console.ReadLine();
            if (!subjectRepository.IsPresent(subjectName))
            {
                Console.WriteLine($"The subject {subjectName} is not present");
                break;
            }
            Subject returnedSubject = subjectRepository.GetSubjectByName(subjectName);

            Console.WriteLine("Insert the grade (from 1 to 5)");
            var grade = Console.ReadLine();
            int gradeInt;
            if (!int.TryParse(grade, out gradeInt) || gradeInt < 1 || gradeInt > 5) {
                Console.WriteLine($"Form of input is not valid");
                break;
            }
               
            StudentSubject studentSubject;
           
            if (studentSubjectRepository.IsPresent(returnedStudent, returnedSubject))
            {
                studentSubject = studentSubjectRepository.GetStudentSubject(returnedStudent, returnedSubject);
                studentSubject.Grades.Add(gradeInt);
            }
            else {
                studentSubject = new StudentSubject(returnedStudent, returnedSubject);
                studentSubject.Grades.Add(gradeInt);
                studentSubjectRepository.AddNewStudentSubject(studentSubject);
            }
            break;
        case "4":
            Console.WriteLine("Insert the students name");
            student = Console.ReadLine();
            insertedStudents = student.Split(", ");

            returnedStudent = studentRepository.GetStudentByName(insertedStudents[0].Split(" ")[0],
                insertedStudents[0].Split(" ")[1]);

            var sumOfGrades = 0;
            decimal average = 0;
            List<StudentSubject> returnedStudentSubject = studentSubjectRepository.GetStudentSubjectByStudent(returnedStudent);
            foreach (var stSubj in returnedStudentSubject)
            {
                Console.WriteLine(stSubj.Subject);
                stSubj.Grades.ForEach(grade => { sumOfGrades += grade; });
                average = (decimal)sumOfGrades / stSubj.Grades.Count();
                Console.WriteLine($"    ==> Prosecna ocena je: [{average}]");
                Console.WriteLine("Success is: "+averageGrade(average));
                sumOfGrades = 0;
            }
            break;
        case "5":
            return;
        default:
            break;
    }

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





