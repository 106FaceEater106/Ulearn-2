// Вставьте сюда финальное содержимое файла PluralizeTask.cs

namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			// J: Рабочее решение, хоть есть алгоритм проще.
			if (count % 100 >= 5 && count % 100 <= 20)
				return "рублей";
			else
			{
				if (count % 10 >= 2 && count % 10 <= 4)
					return "рубля";
				else
				{
					if ((count % 10 >= 5 && count % 10 <= 9) || count % 10 == 0)
						return "рублей";
					else return "рубль";
				}
			}
			
			// J: К слову, все фигурные скобки и else в методе можно убрать:
			if (count % 100 >= 5 && count % 100 <= 20)
				return "рублей";
			if (count % 10 >= 2 && count % 10 <= 4)
				return "рубля";
			if ((count % 10 >= 5 && count % 10 <= 9) || count % 10 == 0)
				return "рублей";
			return "рубль";
		}
	}
}