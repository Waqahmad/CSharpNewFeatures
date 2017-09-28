using System;

namespace NewFeaturesofDotnetcore
{
    class Program
    {

        //Expression-bodied Methods
        int foo1 (int x)
        {
            return x * 2;
        }
        //we can do that like, here foo is expression bodied method
        int foo (int x) => x * 2;


        //Overloading Constructor
        public class Student
        {
            public string StudentName;
            public int StudentMarks;
            public char Gender;
            public bool Promoted;
            public Student() { }
            //This is called Expression-bodied methods (C# 6)
            public Student (string name) => StudentName = name;
            // //This is called Expression-bodied methods (C# 6)
            public Student(string name, int marks) : this(name) => StudentMarks = marks;

            //Object Initializers Versus Optional Parameters, here G and P are optional Parameter
            public Student(string name, int marks, char G='M', bool p=false) : this(name, marks)
            {
                Gender = G;
                Promoted = p;
            }

        }



        static void Main(string[] args)
        {
            //// Note parameterless constructors can omit empty parentheses
            Student _stud = new Student { StudentName = "Waqar", StudentMarks = 585 };

            //Using object initializers, you can instantiate Bunny objects as follows:
            Student _std2 = new Student("Waqar") { StudentMarks = 45 };

            //Object Initializers Versus Optional Parameters
            Student _std3 = new Student("Waqar", 32, p: true);


            Student std = new Student();
            std.StudentMarks = 565;
            std.StudentName = "Ahmad";

            //Console.WriteLine("Hello World!");
        }
    }
}
