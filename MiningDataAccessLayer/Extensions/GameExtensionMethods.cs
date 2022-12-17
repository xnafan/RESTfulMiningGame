using MiningDataAccessLayer.Model;
using System;
using System.Security.Cryptography;
using System.Text;
namespace MiningDataAccessLayer.Extensions;
public static class GameExtensionMethods
{
    private static readonly string ASCII_DENSITY = " ...:::---===+++***###%%%@@@";
    public static string ToAscii(this MiningGame game)
    {
        StringBuilder builder = new StringBuilder();
        for (int y = 0; y < game.MapSideLength; y++)
        {
            for (int x = 0; x < game.MapSideLength; x++)
            {
                var weight = game.GetMapSquareValue(x, y) / (double)100;

                builder.Append(ASCII_DENSITY[(int)(ASCII_DENSITY.Length * weight)]);
            }
            builder.AppendLine();
        }   
        return builder.ToString();
    }
    private static MD5 hasher = MD5.Create();
    public static int ToIntHash (this string theString)
    {
        return BitConverter.ToInt32(hasher.ComputeHash(Encoding.UTF8.GetBytes(theString)));
    }
}