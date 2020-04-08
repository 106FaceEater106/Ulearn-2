using System;

namespace Mazes
{
    public static class EmptyMazeTask
    {
        // J: Без знания того, что метод нужно использовать вместе с MoveOut, неочевидно что такое i;
        // J: По названию и аргументам не ясно, что метод делает.
        public static void RobotMove(Robot robot, int width, int height, int i)
        {
            if (i < width - 3) robot.MoveTo(Direction.Right);
            if (i < height - 3) robot.MoveTo(Direction.Down);
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            
            // Условие для for, несвязанное напрямую со счетчиком - нехорошая практика,
            // Ниже приведен код без for, делающий тоже самое 
            // Стоит сказать, что число шагов можно посчитать заранее, тогда программа не зависнет, если робот не дойдет 
            for (int i = 0; robot.Finished != true; i++)
            {
                RobotMove(robot, width, height, i);
            }
            
            // var i = 0;
            // while (!robot.Finished)
            // {
            //     i++;   
            //     RobotMove(robot, width, height, i);
            // }
        }

        // Этот метод позволит не тащить i в метод RobotMove.
        // Возможно он подскажет, как избавиться от цикла вне его вовсе.
        public static void MoveFor(Robot robot, int stepCount, Direction direction)
        {
            // Замени эту строку кодом, который заставит 
            // робота совершить stepCount шагов в направлении direction
            throw new NotImplementedException();
        }
    }
}

