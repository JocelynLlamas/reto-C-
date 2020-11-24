using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayList;
using Students;

class App
{
    static void Main(string[] arg)
    {

        ArrayList<Student> arrayList = new ArrayList<Student>(40);
        arrayList.add(new Student("HOLA"));
        ArrayList<Student>.Iterator iterator = arrayList.getIterator();
        while (iterator.hasNext())
        {
            Student student = iterator.next();

            Console.WriteLine(student.getName());
        }
        Console.ReadKey();
    }

}

