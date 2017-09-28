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

        //Properties
        /*
             A property is declared like a field, but with a get/set block added. Here’s how to
            implement CurrentPrice as a property:
         */

        public class Stock
        {
            //get and set denote property accessors.
            decimal _currentPrice,sharedPrice;
            public decimal CurrentPrice
            {
                //The get accessor runs when the property is read. It must return a value of the property’s type.
                get { return _currentPrice; }
                //The set accessor runs when the  property is assigned. It has an implicit parameter named value
                set { _currentPrice = value; }

            }


            //Read-only and calculated properties
            //A property is read-only if it specifies only a get accessor,

            public decimal Worth
            {
                get { return _currentPrice * sharedPrice; }
            }

            //Expression-bodied properties
            public decimal Worth2 => _currentPrice * sharedPrice;

            //Automatic Properties
            //An automatic property declaration instructs the compiler to provide this implementation.
            public int Price { get; set; }

            //Property initializers (C# 6)
            //From C# 6, you can add a property initializer to automatic properties, just as with fields
            public string Name { get; set; } = "Waqar Ahmad";
            // This give Name Property and intial value is Waqar Ahmad

            //with an initializer can be  read-only:
            public string Address { get; } = "Islambad";

            //get and set accessibility
            //The get and set accessors can have different access levels.
            //The typical use case for this is to have a public property with an internal or private access modifier on the setter:

            private int _Age;
            public int Age
            {
                get { return _Age; }
                private set { _Age = value; }
            }

            /*
             Notice that you declare the property itself with the more permissive access level
             (public, in this case) and add the modifier to the accessor you want to be less accessible.
            */

          

        }

        // Indexers
        //Indexers are similar to properties but are accessed via an index argument rather than a property name.
        //The .NET class library design guidelines recommend having only one indexer per class.
        //So in your case, there's no way to do what you're asking using indexers only.


        public class Sentence
        {
            string[] words = "The quick brown fox".Split();
            public string this [int wordNum]
            {
                get { return words[wordNum]; }
                set { words[wordNum] = value; }
            }

            //public string this[int index] => words [index];

            //public string this[int intx] => words[intx];
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

            // Here’s how we could use this indexer:

            Sentence obj_indexer = new Sentence();
            Console.WriteLine(obj_indexer[3]);
            obj_indexer[3] = "NewStringAdded";
            Console.WriteLine(obj_indexer[3]);





            
        }
    }
}
