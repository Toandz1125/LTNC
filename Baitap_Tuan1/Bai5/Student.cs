using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    public class Student
    {
        public string name { get; set; }
        int semeter;
        [Required]
        [StringLength(50)]
        public CourseType CourseType { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (value ==null || value.Length == 0)
                {
                    throw new Exception("Name cannot be blank");
                }
                name = value;
            }
        }
        public Student()
        {

        }
        public Student(string name, CourseType course, int semeter)
        {
            this.Name = name;
            this.Semeter = semeter;
            this.CourseType = course;
        }
        public int Semeter
        {
            get { return semeter; }
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new Exception("Semeter must be in range 1-8");
                }
                semeter = value;
            }
        }
        public override string ToString()
        {
            return $"{Name}, {CourseType}, {Semeter}";
        }
    }
}
