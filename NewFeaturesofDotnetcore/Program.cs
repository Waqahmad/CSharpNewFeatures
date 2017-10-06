using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

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
            public string  Gender;
            public bool Promoted;
            public Student() { }
            //This is called Expression-bodied methods (C# 6)
            public Student (string name) => StudentName = name;
            // //This is called Expression-bodied methods (C# 6)
            public Student(string name, int marks) : this(name) => StudentMarks = marks;

            //Object Initializers Versus Optional Parameters, here G and P are optional Parameter
            public Student(string name, int marks, string  G="M", bool p=false) : this(name, marks)
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

            //Constants
            //A constant is a static field whose value can never change.

            public const string Message = "I am breliant guy";

            //Static Constructor

             /*  A static constructor executes once per type, rather than once per instance. A type
                can define only one static constructor, and it must be parameterless and have the
                same name as the type:
             */

            static Sentence()
            {
                Console.WriteLine("Type Initialized");
            }
            //static Sentence(int a) => a;

        }
        //Partial methods
        /*
         * A partial method consists of two parts: a definition and an implementation. The definition
         is typically written by a code generator, and the implementation is typically
         manually authored. If an implementation is not provided, the definition of the partial
         method is compiled away (as is the code that calls it). This allows auto-generated
         code to be liberal in providing hooks, without having to worry about bloat. Partial
         methods must be void and are implicitly private.
         Partial methods were introduced in C# 3.0.
         */
        //Rules for Partial Methods

        //Partial methods are indicated by the partial modifier.
        //Partial methods must be private.
        //Partial methods must return void.
        //Partial methods must only be declared within partial classes.
        //Partial methods do not always have an implementation.
        //Partial methods can be static and generic.
        //Partial methods can have arguments including ref but not out. 
        //You cannot make a delegate to a partial method.


        public partial class PaymentForm
        {
            //Parial Methods are private , by default
            //Partial Defination
           partial void ValidatePayment(decimal Amount);
           
        }

      public partial class PaymentForm
        {

            //Partial Implimentation
            partial void ValidatePayment(decimal Amount)
            {
               if(Amount>200)
                {

                }
            }
            //You can call a partial method inside the constructor where the method is defined.
            public void CallParialMethod()
            {
                ValidatePayment(56);
            }
        }

       

        static void Main(string[] args)
        {

            string jsonstring = File.ReadAllText("person.json");
            Student std_json = JsonConvert.DeserializeObject<Student>(jsonstring);
            Console.WriteLine(std_json);


            //// Note parameterless constructors can omit empty parentheses
            Student _stud = new Student { StudentName = "Waqar", StudentMarks = 585 };

            string outputjson = JsonConvert.SerializeObject(_stud);
            File.WriteAllText("person.json", outputjson);


            //Using object initializers, you can instantiate Bunny objects as follows:
            Student _std2 = new Student("Waqar") { StudentMarks = 45 };

            //Object Initializers Versus Optional Parameters
            Student _std3 = new Student("Waqar", 32, p: true);

            PaymentForm obj = new PaymentForm();
            obj.CallParialMethod();





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
