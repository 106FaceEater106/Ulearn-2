using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTask;
namespace TestConsoleVectorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vectorTest = new Vector() {X = 1, Y = 1 };
            Console.WriteLine("Длина вектора: {0}", Geometry.GetLength(vectorTest));
            Console.ReadLine();
        }
    }
}
