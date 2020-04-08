using System;

namespace Mazes
{
	public static class DiagonalMazeTask
	{
		// J: Более удачное название MoveDiagonally
		// J: Длина шага называется width, но dir1 может быть Down
		// J: Названия dir1 и dir2 ничего не отражают предназначения, которым они отличаются.
		// Т.е. их можно перепутать при передаче, если не знать КАК метод работает
		public static void MoveToDiagonaly(Robot robot, int width, Direction dir1, Direction dir2)
		{
			// J: Когда цикл или if выполняет 1 инструкцию, мы можем убрать скобки и сделать читаемее.
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
			ratio = (width - 2) / (height - 2); // Это можно было посчитать однажды
			MoveToDiagonaly(robot, ratio, Direction.Right, Direction.Down);
		}

		public static void CheckFinishedAndMoveToDown(Robot robot, int height, int width)
		{
			int ratio = 0;
			ratio = (height - 2) / (width - 2); // Это можно было посчитать однажды
			MoveToDiagonaly(robot, ratio, Direction.Down, Direction.Right);
		}

		// Название не соответсвует тому, что метод делает
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
			
			//J: почему бы не просто
			//return width > height 
		}
		
		public static void MoveOut(Robot robot, int width, int height)
		{
			//J: почему бы не просто
			//while (!robot.Finished)
			while (robot.Finished == false)
			{
				// J: Этот метод на каждой итерации while возвращает одно и то же значение. 
				// Мы можем посчитать его результат однажды
				if (CheckFinished(width, height))  
				{
					// Возможно, while стоило внести в эти методы? 
					CheckFinishedAndMoveToRight(robot, width, height);
				}
				else
				{
					// Возможно, while стоило внести в эти методы?
					CheckFinishedAndMoveToDown(robot, height, width);
				}
			}
		}
	}
}