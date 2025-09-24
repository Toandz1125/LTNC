using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    public interface IStudentAPP
    {
        bool AddStudent(Student student);
        public StudentList getStudentByName(string Name);
        void Print();
        void ReFile(string fileName);
    }
}
