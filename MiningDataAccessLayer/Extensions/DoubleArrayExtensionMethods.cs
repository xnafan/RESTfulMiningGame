using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningDataAccessLayer.Extensions
{
    public static class DoubleArrayExtensionMethods
    {
        public static int[,] Smooth(this int[,] arrayToSmooth, int iterations = 1)
        {
            if (iterations < 1) { return arrayToSmooth; }
            int[,] result = null;
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                result = new int[arrayToSmooth.GetLength(0), arrayToSmooth.GetLength(1)];
                for (int x = 0; x < arrayToSmooth.GetLength(0); x++)
                {
                    for (int y = 0; y < arrayToSmooth.GetLength(1); y++)
                    {
                        var averageOfNeighbors = arrayToSmooth.GetNeighborsContents(x,y).Average();
                        var difference = averageOfNeighbors - arrayToSmooth[x, y];

                        result[x, y] = arrayToSmooth[x, y] + (int)(difference / 5);
                    }
                }
                arrayToSmooth = result;
            }
            return result;
        }

    }


}