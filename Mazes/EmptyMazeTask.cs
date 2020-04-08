// Вставьте сюда финальное содержимое файла EmptyMazeTask.cs
namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void RobotMove(Robot robot, int width, int height, int i)
        {
            if (i < width - 3) robot.MoveTo(Direction.Right);
            if (i < height - 3) robot.MoveTo(Direction.Down);
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            for (int i = 0; robot.Finished != true; i++)
            {
                RobotMove(robot, width, height, i);
            }
        }
    }
}

