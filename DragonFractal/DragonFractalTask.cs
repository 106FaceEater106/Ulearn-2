// Вставьте сюда финальное содержимое файла DragonFractalTask.cs


// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing;
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		// 45 градусов
		public static double GetAngle45()
		{
			return Math.PI * 45 / 180;
		}
		// 135 градусов
		public static double GetAngle135()
		{
			return Math.PI * 135 / 180;
		}

		public static double GetFractalXangle45(double x, double y)
		{
			return (x * Math.Cos(GetAngle45()) - y * Math.Sin(GetAngle45())) / Math.Sqrt(2);
		}

		public static double GetFractalYangle45(double x, double y)
		{
			return (x * Math.Sin(GetAngle45()) + y * Math.Cos(GetAngle45())) / Math.Sqrt(2);
		}

		public static double GetFractalXangle135(double x, double y)
		{
			return (x * Math.Cos(GetAngle135()) - y * Math.Sin(GetAngle135())) / Math.Sqrt(2) + 1;
		}

		public static double GetFractalYangle135(double x, double y)
		{
			return (x * Math.Sin(GetAngle135()) + y * Math.Cos(GetAngle135())) / Math.Sqrt(2);
		}

		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{

			var x = 1.0;
			var y = 0.0;
			var random = new Random(seed);

			for (int i = 0; i < iterationsCount; i++)
			{
				var nextNumber = random.Next(1, 3);
				if (nextNumber == 1)
				{
					var x1 = GetFractalXangle45(x, y);
					var y1 = GetFractalYangle45(x, y);
					x = x1;
					y = y1;
				}
				if (nextNumber == 2)
				{
					var x1 = GetFractalXangle135(x, y);
					var y1 = GetFractalYangle135(x, y);
					x = x1;
					y = y1;
				}
				pixels.SetPixel(x, y);
			}
		}

	}
}