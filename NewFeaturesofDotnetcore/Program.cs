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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
