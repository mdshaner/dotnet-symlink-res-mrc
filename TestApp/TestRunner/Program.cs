using System;
using CustomNamespace;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CustomNamespace.Common.Test);
            Console.WriteLine("Hello World!");
        }
    }
}
