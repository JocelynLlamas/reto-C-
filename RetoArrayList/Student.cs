using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        private String name;

        public Student(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public bool equals(Object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }
            Student otherStudent = (Student)obj;

            return this.name.Equals(otherStudent.name);
        }
    }
}
