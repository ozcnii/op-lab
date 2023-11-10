using System.Text.RegularExpressions;

namespace Lab7
{
    public static class Stringer
    {
        public static int LettersCount(string value)
        {
            var regex = new Regex(@"\p{L}");
            return regex.Count(value);
        }

        public static double AverageWordCount(string value)
        {
            var words = value.Split(" ");
            return words.Aggregate(0, (acc, curr) => acc += curr.Length) / words.Length;
        }

        public static string Replace(string value, string oldValue, string newValue)
        {
            var result = "";
            var size = oldValue.Length;
            int i = 0;

            while (i < value.Length)
            {
                var isMatch = false;

                if (i + size <= value.Length && value.Substring(i, size).ToLower() == oldValue.ToLower())
                {
                    var regex = new Regex(@"[^\p{L}]");
                    if ((i == 0 || regex.IsMatch(value[i - 1].ToString())) && (i + size == value.Length || regex.IsMatch(value[i + size].ToString())))
                    {
                        result += newValue;
                        i += size;
                        isMatch = true;
                    }
                }

                if (!isMatch)
                {
                    result += value[i];
                    i++;
                }
            }

            return result;
        }

        public static int CountSubstrings(string value, string substr)
        {
            int count = 0;
            for (int i = 0; i <= value.Length - substr.Length; i++)
                if (value.Substring(i, substr.Length) == substr)
                    count++;
            return count;
        }

        public static bool IsPalindrom(string value)
        {
            return value == string.Join("", value.ToArray().Reverse());
        }

        public static bool IsDate(string value)
        {
            var arr = value.Split(".");
            if (arr.Length != 3)
                return false;

            var dParsed = int.TryParse(arr[0], out int d);
            if (!dParsed || d < 1 || d > 31)
                return false;

            var mParsed = int.TryParse(arr[1], out int m);
            if (!mParsed || m < 1 || m > 12)
                return false;

            var yParsed = int.TryParse(arr[2], out int y);
            if (!yParsed || y < 0 || arr[2].Length < 2)
                return false;

            return true;
        }
    }
}