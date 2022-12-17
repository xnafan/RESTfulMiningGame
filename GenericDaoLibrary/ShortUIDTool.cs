using System;
using System.Text;

namespace GenericDaoLibrary
{
    public static class ShortUIDTool
    {
        #region Properties
        private static readonly Random _random = new Random();
        private static readonly char[] _characters = new char[] {'2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        #endregion
        public static string CreateShortId(int length = 6)
        {
            int hyphens = 0;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(_characters[_random.Next(_characters.Length)]);
                if ((builder.Length - hyphens) % 3 == 0 && length - 1 != i)
                {
                    builder.Append('-');
                    hyphens++;
                }
            }
            return builder.ToString();
        }
    }
}