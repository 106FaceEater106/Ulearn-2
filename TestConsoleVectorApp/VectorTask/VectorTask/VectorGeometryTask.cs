using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    public class Vector {
        public double X = 0;
        public double Y = 0;
    }

    public class Geometry
    {
        //возвращает длину переданного вектора
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }
        //который возвращает сумму двух переданных векторов
        public static double Add(Vector vector1, Vector vector2)
        {
            return GetLength(vector1) + GetLength(vector2);
        }

    }

}
