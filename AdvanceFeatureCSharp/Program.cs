using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceFeatureCSharp
{
    class Program
    {

        delegate int Tranformer(int x);
        static int Square(int x) => x * x;


        class Utility
        {
            public static void Transform(int[] values, Tranformer t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
        }

        public delegate void ProgressReporter(int percentComplete);

        public class Util
        {
            public static void HardWork(ProgressReporter p)
            {
                for (int i = 0; i < 10; i++)
                {
                    p(i * 10); // Invoke delegate
                    System.Threading.Thread.Sleep(100); // Simulate hard work
                }
            }
            public delegate T Transformer<T>(T arg);
            public static void Transform<T>(T[] values, Transformer<T> t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
        }

        public interface ITransformer
        {
            int Transform(int x);
        }
        public class Utiliz
        {
            public static void TransformAll(int[] values, ITransformer t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t.Transform(values[i]);
            }
        }
        class Squarer : ITransformer
        {
            public int Transform(int x) => x * x;
        }
        class Cuber : ITransformer
        {
            public int Transform(int x) => x * x * x;
        }

        static void Main(string[] args)
        {
            Tranformer t = Square;
            int result = t(3);
            //Short handed
            Tranformer t2 = new Tranformer(Square);
            int rsl3 = t2(3);
            int rsl4 = t.Invoke(5);

            int[] values = { 1, 2, 3 };
            Utility.Transform(values, Square);

            foreach (int i in values)
                Console.Write(i + " ");

            //Multi Cast Delegate Example

            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;

            Util.HardWork(p);

            X x = new X();
            ProgressReporter pi = x.InstanceProgress;
            pi(99); // 99
            Console.WriteLine(pi.Target == x); // True
            Console.WriteLine(pi.Method); // Void InstanceProgress(Int32)



            //Generic Delgate Type
            int[] values2 = { 1, 2, 3 };
            Util.Transform(values2, Square); // Hook in Square
            foreach (int i in values2)
                Console.Write(i + " ");

            //Delegate using Interfaces
            Utiliz.TransformAll(values, new Squarer());
            foreach (int i in values)
                Console.WriteLine(i);


            Utiliz.TransformAll(values, new Cuber());
            foreach (int i in values)
                Console.WriteLine(i);
        }


        class X
        {
            public void InstanceProgress(int percentComplete)
            => Console.WriteLine(percentComplete);
        }
        static void WriteProgressToConsole(int percentComplete)
               => Console.WriteLine(percentComplete);

        static void WriteProgressToFile(int percentComplete)
        => System.IO.File.WriteAllText("progress.txt",
        percentComplete.ToString());
    }
}


