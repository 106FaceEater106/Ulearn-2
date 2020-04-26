namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static int RatioDiagonal(int height, int width)
        {
			return (width - 2) / (height - 2);
		}
		public static void MoveToDiagonaly(Robot robot, int width, Direction MoveRightOrDown, Direction MoveRigthOrDown)
		{
			if (!robot.Finished)
			{
				for (int i = 0; i < width; i++)
					robot.MoveTo(dir1);
			}

			if (!robot.Finished)
				robot.MoveTo(dir2);
		}

		public static void CheckFinishedAndMoveToRight(Robot robot, int width, int height)
		{
			var ratio = RatioDiagonal(height, width);
			MoveToDiagonaly(robot, ratio, Direction.Right, Direction.Down);
		}

		public static void CheckFinishedAndMoveToDown(Robot robot, int height, int width)
		{
			
			var ratio = RatioDiagonal(height, width);
			MoveToDiagonaly(robot, ratio, Direction.Down, Direction.Right);
		}

		public static bool MoveCheck(int width, int height)
		{
			return width > height;
        }

		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				if (MoveCheck(width, height))
				{
					CheckFinishedAndMoveToRight(robot, width, height);
				}
				else
				{
					CheckFinishedAndMoveToDown(robot, height, width);
				}
			}
		}
	}
}