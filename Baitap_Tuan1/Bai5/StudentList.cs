using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Net.Http.Headers;

namespace Bai5
{
    public class StudentList : IStudentAPP
    {
        private List<Student> ?students;
        string fileName = "StudentList.txt";
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new Exception("File name cannot be blank");
                }
                fileName = value;
            }
        }
        public StudentList()
        {
            this.students = new List<Student>();
        }
        public StudentList(string fileName)
        {
            students = new List<Student>();
            if (!System.IO.File.Exists(fileName))
            {
                Console.WriteLine("File not found: " + fileName);
                return;
            }
            ReFile(fileName);
        }
        public void Print()
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public bool AddStudent(Student student)
        {
            if (student == null) return false;
            if (checkDouble(student))
            {
                Console.WriteLine("Duplicate student. Skipping...");
                return false;
            }
            students.Add(student);
            return true;
        }
        public StudentList getStudentByName(string Name)
        {
            StudentList resultList = new StudentList();
            foreach (Student student in students)
            {
                if (student.Name == Name)
                {
                    resultList.AddStudent(student);
                }
            }
            return resultList;
        }
        public void GenerateReport()
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students to report.");
                return;
            }

            Hashtable report = new Hashtable();

            foreach (Student sv in this.students)
            {
                string key = sv.Name + "|" + sv.CourseType;

                if (report.ContainsKey(key))
                {
                    report[key] = (int)report[key] + 1;
                }
                else
                {
                    report[key] = 1;
                }
            }

            Console.WriteLine("Student Name | Course | Total of Course");
            foreach (DictionaryEntry entry in report)
            {
                string[] parts = entry.Key.ToString().Split('|');
                string name = parts[0];
                string course = parts[1];
                Console.WriteLine($"{name} | {course} | {entry.Value}");
            }
        }
        public bool checkDouble(Student sv)
        {
            Student Sv = students.Where(s => s.Name.Equals(sv.Name) && s.CourseType.Equals(sv.CourseType) && s.Semeter.Equals(sv.Semeter)).FirstOrDefault();
            if (Sv != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateStudent(string name, CourseType course, int sem, Student newInfo)
        {
            Student student = students
                .Where(s => s.Name.Equals(name) && s.CourseType.Equals(course) && s.Semeter == sem)
                .FirstOrDefault();

            if (student == null)
            {
                Console.WriteLine("Student cannot be found.");
                return false;
            }

            if (checkDouble(newInfo))
            {
                Console.WriteLine("The new information is same as other.");
                return false;
            }

            student.Name = newInfo.Name;
            student.CourseType = newInfo.CourseType;
            student.Semeter = newInfo.Semeter;

            Console.WriteLine("Update Successfully!");
            return true;
        }

        public bool DeleteStudent(string name, CourseType course, int sem)
        {
            Student student = students
                .Where(s => s.Name.Equals(name) && s.CourseType.Equals(course) && s.Semeter == sem)
                .FirstOrDefault();

            if (student == null)
            {
                Console.WriteLine("Student cannot be found.");
                return false;
            }

            students.Remove(student);
            Console.WriteLine("Delete Successfully!");
            return true;
        }


        public void ReFile(string file)
        {
            StreamReader fr = new StreamReader(file);
            while (!fr.EndOfStream)
            {
                string? line = fr.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] ps = line.Split(',');
                if (ps.Length < 3) continue;

                string name = ps[0].Trim();
                string courseStr = ps[1].Trim().ToLower();
                int sem = int.Parse(ps[2].Trim());

                CourseType course;
                switch (courseStr)
                {
                    case "java":
                        course = CourseType.Java;
                        break;
                    case "csharp":
                        course = CourseType.CSharp;
                        break;
                    case "python":
                        course = CourseType.Python;
                        break;
                    default:
                        Console.WriteLine("Invalid course type: " + ps[1]);
                        continue;
                }
                if (ps.Length > 0)
                {
                    try
                    {
                        students.Add(new Student(name, course, int.Parse(ps[2])));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error parsing student data: " + ex.Message);
                        continue;
                    }
                }
            }
            fr.Close();
        }
    }
}
