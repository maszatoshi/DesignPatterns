using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    //ConcretePrototype2
    public class Student : Person
    {
        public Student(string name, Teacher teacher) : base(name)
        {
            Teacher = teacher;
        }

        public Teacher Teacher { get; set; }
        public override Person Clone()
        {
            //deep copy, https://youtu.be/zJT7h_amG40?t=962
            Student studentClone = (Student)MemberwiseClone();
            studentClone.Teacher = new Teacher(this.Teacher.Name, this.Teacher.Course);
            return studentClone;
        }
    }
}
