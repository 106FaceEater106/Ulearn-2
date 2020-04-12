﻿using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		// Ниже — это XML документация, её использует ваша среда разработки, 
		// чтобы показывать подсказки по использованию методов. 
		// Но писать её естественно не обязательно.
		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
			
			double g = 9.8;
			return 0.5 * Math.Asin(distance * g / Math.Pow(v, 2));
			//Более ясный вариант:
			// var g = 9.8;
			// var angle = Math.Asin(distance * g / (v * v));
			// return angle/2;
		}
	}
}
