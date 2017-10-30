using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            Console.WriteLine(new String(line.AsEnumerable().Select(elem =>  Convert.ToChar(elem + 3)).ToArray()));
            var consoleKeyInfo = Console.ReadKey();
        }
    }
}
