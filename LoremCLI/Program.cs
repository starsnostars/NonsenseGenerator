using LoremGenerator;
using System;

namespace LoremCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new Generator();

            string res = gen.Generate(2);

            Console.WriteLine("Hello World!");
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
