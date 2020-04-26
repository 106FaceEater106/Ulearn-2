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
        public static void MoveOut(Robot robot, int width, int height)
        {
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
    }
}