using System;
using System.Windows.Forms;

namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void SnakeMoveToRight(Robot robot)
        {
            robot.MoveTo(Direction.Right);
        }
        public static void SnakeMoveToLeft(Robot robot)
        {
            robot.MoveTo(Direction.Left);
        }
        public static void SnakeMoveToDown(Robot robot)
        {
            robot.MoveTo(Direction.Down);
        }
        // J: Методы SnakeMoveToDIRECTION могут быть заменены одним более общим методом

        public static void MoveOut(Robot robot, int width, int height)
        {
            // J: нарушение условия задачи:
                // "Запрещено иметь методы длиннее 12 строк кода"
            
            while (true)
            {
                for (int i = 0; i < width - 3; i++)
                {
                    SnakeMoveToRight(robot);
                }
                SnakeMoveToDown(robot);
                SnakeMoveToDown(robot);
                for (int i = 0; i < width - 3; i++)
                {
                    SnakeMoveToLeft(robot);
                }
                if (robot.Finished) break;
                SnakeMoveToDown(robot);
                SnakeMoveToDown(robot);
            }
        }

        
        public static void MoveFor(Robot robot, int stepCount, Direction direction)
        {
            // Замени эту строку кодом, который заставит 
            // робота совершить stepCount шагов в направлении direction
            throw new NotImplementedException();
        }
    }
}