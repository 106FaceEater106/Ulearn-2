using System;
namespace Recognizer
{
	public static class GrayscaleTask
	{
        // rgb system colors
		const double RedMultiplier = 0.299;
        const double GreenMultiplier = 0.587;
        const double BlueMultiplier = 0.114;
        const double NumberOfShades = 255;

     

        public static double[,] ToGrayscale(Pixel[,] original)
		{
            var width = original.GetLength(0);
            var height = original.GetLength(1);

            var grayscalerArr = new double[width, height];

            for (var x = 0; x < width; x++) 
            { 
                var x1 = width;
                for (var y = 0; y < height; y++)
                {
                    var y1 = height;
                    var R = original[x,y];
                    var G = original[x, y];
                    var B = original[x, y];
                    grayscalerArr[x, y] = ((RedMultiplier * R.R)
                        + (GreenMultiplier * G.G)
                        + (BlueMultiplier * B.B)) / NumberOfShades; 
                }
            }
            return grayscalerArr ;
		}
	}
}