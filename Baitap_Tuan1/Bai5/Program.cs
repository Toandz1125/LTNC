using System;
using Bai5;

class Program
{
    static void Main(string[] args)
    {
        StudentList studentList = new StudentList();
        studentList.ReFile(studentList.FileName);

        int choice;
        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Print student list");
            Console.WriteLine("2. Search student by name");
            Console.WriteLine("3. Add new student");
            Console.WriteLine("4. Update student info");
            Console.WriteLine("5. Delete student");
            Console.WriteLine("6. Generate report");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Student list ---");
                    studentList.Print();
                    break;

                case 2:
                    Console.Write("Enter student name to search: ");
                    string searchName = Console.ReadLine();
                    StudentList result = studentList.getStudentByName(searchName);
                    result.Print();
                    break;


                case 3:
                    Console.WriteLine("\n--- Add new student ---");
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter course (Java/CSharp/Python): ");
                    string courseStr = Console.ReadLine();
                    Console.Write("Enter semester (1-8): ");
                    int sem = int.Parse(Console.ReadLine());

                    CourseType course;
                    switch (courseStr.ToLower())
                    {
                        case "java": course = CourseType.Java; break;
                        case "csharp": course = CourseType.CSharp; break;
                        case "python": course = CourseType.Python; break;
                        default:
                            Console.WriteLine("Invalid course!");
                            goto EndAdd;
                    }

                    try
                    {
                        Student newStudent = new Student(name, course, sem);
                        studentList.AddStudent(newStudent);
                        Console.WriteLine("Student added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                EndAdd:
                    break;

                case 4:
                    Console.WriteLine("\n--- Update student info ---");
                    Console.Write("Enter old name: ");
                    string oldName = Console.ReadLine();
                    Console.Write("Enter old course (Java/CSharp/Python): ");
                    string oldCourseStr = Console.ReadLine();
                    Console.Write("Enter old semester: ");
                    int oldSem = int.Parse(Console.ReadLine());

                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new course (Java/CSharp/Python): ");
                    string newCourseStr = Console.ReadLine();
                    Console.Write("Enter new semester: ");
                    int newSem = int.Parse(Console.ReadLine());

                    CourseType oldCourse = (CourseType)Enum.Parse(typeof(CourseType), oldCourseStr, true);
                    CourseType newCourse = (CourseType)Enum.Parse(typeof(CourseType), newCourseStr, true);

                    studentList.UpdateStudent(
                        oldName, oldCourse, oldSem,
                        new Student(newName, newCourse, newSem)
                    );
                    break;

                case 5:
                    Console.WriteLine("\n--- Delete student ---");
                    Console.Write("Enter name: ");
                    string delName = Console.ReadLine();
                    Console.Write("Enter course (Java/CSharp/Python): ");
                    string delCourseStr = Console.ReadLine();
                    Console.Write("Enter semester: ");
                    int delSem = int.Parse(Console.ReadLine());

                    CourseType delCourse = (CourseType)Enum.Parse(typeof(CourseType), delCourseStr, true);
                    studentList.DeleteStudent(delName, delCourse, delSem);
                    break;

                case 6:
                    Console.WriteLine("\n--- Report ---");
                    studentList.GenerateReport();
                    break;

                case 0:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again!");
                    break;
            }
        } while (choice != 0);
    }
}
