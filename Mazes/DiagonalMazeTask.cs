namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveToDiagonaly(Robot robot, int width, Direction dir1, Direction dir2)
		{
			if (!robot.Finished)
			{
				for (int i = 0; i < width; i++)
				{
					robot.MoveTo(dir1);
				}
			}

			if (!robot.Finished)
				robot.MoveTo(dir2);
		}

		public static void CheckFinishedAndMoveToRight(Robot robot, int width, int height)
		{
			int ratio = 0;
			ratio = (width - 2) / (height - 2);
			MoveToDiagonaly(robot, ratio, Direction.Right, Direction.Down);
		}

		public static void CheckFinishedAndMoveToDown(Robot robot, int height, int width)
		{
			int ratio = 0;
			ratio = (height - 2) / (width - 2);
			MoveToDiagonaly(robot, ratio, Direction.Down, Direction.Right);
		}

		public static bool CheckFinished(int width, int height)
		{
			if (width > height)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
			while (robot.Finished == false)
			{
				if (CheckFinished(width, height))
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