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
            var insertedStudents = student.Split(", ");

            insertedStudents.ToList().ForEach(insertedStudent =>
                newStudentsList.Add(new Student(insertedStudent.Split(" ")[0], insertedStudent.Split(" ")[1])));        
            
            studentRepository.AddNewStudents(newStudentsList);
            break;
        case "3":
            Console.WriteLine("Insert the students name");
            student = Console.ReadLine();
            insertedStudents = student.Split(", ");

            Student returnedStudent = studentRepository.GetStudentByName(insertedStudents[0].Split(" ")[0],
                insertedStudents[0].Split(" ")[1]);

            Console.WriteLine("Insert the subject name");
            var subjectName = Console.ReadLine();
            Subject returnedSubject = subjectRepository.GetSubjectByName(subjectName);

            Console.WriteLine("Insert the grade (from 1 to 5)");
            var grade = int.Parse(Console.ReadLine());

            StudentSubject studentSubject;
           
            if (studentSubjectRepository.IsPresent(returnedStudent, returnedSubject))
            {
                studentSubject = studentSubjectRepository.GetStudentSubject(returnedStudent, returnedSubject);
                studentSubject.Grades.Add(grade);
            }
            else {
                studentSubject = new StudentSubject(returnedStudent, returnedSubject);
                studentSubject.Grades.Add(grade);
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
            var average = 0;
            List<StudentSubject> returnedStudentSubject = studentSubjectRepository.GetStudentSubjectByStudent(returnedStudent);
            foreach (var stSubj in returnedStudentSubject)
            {
                Console.WriteLine(stSubj);
                stSubj.Grades.ForEach(grade => { sumOfGrades += grade; });
                average = sumOfGrades / stSubj.Grades.Count();
                Console.WriteLine($"    ==> Prosecna ocena je: [{average}]");
                sumOfGrades = 0;
            }
            break;
        case "5":
            return;
        default:
            break;
    }

}





