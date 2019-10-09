using System;
using System.Collections.Generic;
using System.Linq;
using leetcode.Code;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            Console.WriteLine(test?.Collection.Any() ?? false);
            test.Collection = new List<string>();
            Console.WriteLine(test?.Collection?.Any() ?? false);

            test.Collection = new List<string>{ "assd","asadasd"};

            Console.WriteLine(test?.Collection?.Any() ?? false);
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");

        }
    }
}

