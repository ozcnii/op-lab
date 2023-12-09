using System.Text;
using System.Globalization;
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
            var separators = new char[] { ' ', '!', '.', '?', ',' };
            var words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
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
                if (value.Substring(i, substr.Length).ToLower() == substr.ToLower())
                    count++;
            return count;
        }

        public static bool IsPalindrom(string value)
        {
            Regex regex = new Regex(@"[\p{L}\d]");
            MatchCollection matches = regex.Matches(value);

            var resultBuilder = new StringBuilder();

            foreach (Match match in matches)
            {
                resultBuilder.Append(match.Value);
            }
            var cleanString = resultBuilder.ToString();

            return cleanString.ToLower() == string.Join("", cleanString.ToLower().ToArray().Reverse());
        }

        public static bool IsDate(string date)
        {
            try
            {
                bool isDate = DateTime.TryParseExact(date, new[] { "dd.MM.yy", "dd.MM.yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time);
                return isDate;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}