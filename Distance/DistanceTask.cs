using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        public static double GetAkDot(double x, double ax, double y, double ay)
        {
            return Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
        }

        public static double GetKbDot(double x, double bx, double y, double by)
        {
            return Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
        }

        public static double GetAbDot(double ax, double bx, double ay, double by)
        {
            return Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
        }
        //скалярное произведение векторов
        public static double GetScalarLenghtAkAb(double x, double ax, double bx, double y, double ay, double by)
        {
            return (x - ax) * (bx - ax) + (y - ay) * (by - ay);
        }

        public static double GetScalarLenghtBkAb(double x, double bx, double ax, double y, double by, double ay)
        {
            return (x - bx) * (-bx + ax) + (y - by) * (-by + ay);
        }

        public static double ReturnResultPerpendicular(double x, double ax, double y, double ay, double bx, double by)
        {

            return (GetAkDot(x, ax, y, ay) + DistanceTask.GetKbDot(x, bx, y, by) + DistanceTask.GetAbDot(ax, bx, ay, by)) / 2.0;
        }

        public static double ReturnResultSegment(double x, double ax, double y, double ay, double bx, double by)
        {
            return Math.Sqrt(Math.Abs((ReturnResultPerpendicular(x, ax, y, ay, bx, by) * (ReturnResultPerpendicular(x, ax, y, ay, bx, by) - GetAkDot(x, ax, y, ay)) * (ReturnResultPerpendicular(x, ax, y, ay, bx, by) - GetKbDot(x, bx, y, by)) * (ReturnResultPerpendicular(x, ax, y, ay, bx, by) - GetAbDot(ax, bx, ay, by)))));
        }

        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            if (GetAbDot(ax, bx, ay, by) == 0)
            {
                return GetAkDot(x, ax, y, ay);
            }
            else if ((GetScalarLenghtAkAb(x, ax, bx, y, ay, by) >= 0) && (GetScalarLenghtBkAb(x, bx, ax, y, by, ay) >= 0))
            {
                return (2.0 * ReturnResultSegment(x, ax, y, ay, bx, by)) / GetAbDot(ax, bx, ay, by);
            }
            else if ((GetScalarLenghtAkAb(x, ax, bx, y, ay, by) < 0) || (GetScalarLenghtBkAb(x, bx, ax, y, by, ay) < 0))
            {
                return Math.Min(GetAkDot(x, ax, y, ay), GetKbDot(x, bx, y, by));
            }
            else return 0;
        }
    }
}