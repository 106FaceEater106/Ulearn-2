using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rublez
{
    class Program
    {
        public static double Calculate(string splitRublez)
        {
            var rublez = double.Parse(splitRublez.Split(' ')[0]);
            var percent = double.Parse(splitRublez.Split(' ')[1]) / 100;
            var month = int.Parse(splitRublez.Split(' ')[2]);

            for(var i = 1; i <= month; i++)
            {
                rublez += rublez * percent / 12;
            }

            return rublez;
        }
        static void Main(string[] args)
        {
            string splitRublez = Console.ReadLine();
            var value = Calculate(splitRublez);
            Console.WriteLine(value);
            Console.ReadLine();

        }
    }
}
