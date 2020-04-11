using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    // TASK Vector Practice
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
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector
            {
                X = vector1.X + vector2.X,
                Y =
                 vector1.Y + vector2.Y
            };
        }

        // TAST CUT
        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(Math.Pow(segment.End.X - segment.Begin.X, 2) + Math.Pow(segment.End.Y - segment.Begin.Y, 2));
        }
        // метод проверяющий, что задаваемая вектором точка лежит в отрезке.
        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var segmentLength = Geometry.GetLength(segment);
            var length1 = Math.Sqrt(Math.Pow(vector.X - segment.Begin.X, 2) + Math.Pow(vector.Y - segment.Begin.Y, 2));
            var length2 = Math.Sqrt(Math.Pow(vector.X - segment.End.X, 2) + Math.Pow(vector.Y - segment.End.Y, 2));
            return CheckResultIsVectorInSegment((length2 + length1), segmentLength);
        }
        // проверка метода вернувшего результат 
        public static bool CheckResultIsVectorInSegment(double a, double b)
        {
            const double epsilon = 0.1;
            return Math.Abs(a - b) < epsilon;
        }


    }

    // TASK Cut Practice
    //  представляющий отрезок прямой
    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public static double GetLength(Vector vector)
        {
            return Geometry.GetLength(vector);
        }

        public bool IsVectorInSegment(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}
