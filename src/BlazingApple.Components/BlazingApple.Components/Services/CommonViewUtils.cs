using System.Diagnostics.Contracts;

namespace BlazingApple.Components.Services
{
    /// <summary>Various methods to ease the display logic of common operations, like rendering a date.</summary>
    public static class CommonViewUtils
    {
        private const string DATE_FORMAT = "MMM dd \\'yy";
        private const string DATE_MONTH_YEAR_FORMAT = "MMM \\'yy";
        private const string TIME_FORMAT = " h:mm tt";

        /// <summary>Returns, in local time, the date string formatted as "Sep 22 '20 8:00 AM".</summary>
        /// <param name="dateTime">The date object to render to a user friendly string</param>
        /// <param name="justMonthYear">Don't show the exact date, just the month and year. If this is set, the time is not shown.</param>
        /// <param name="onlyDate">Set this if you want to hide the time</param>
        /// <returns>A user friendly string</returns>
        public static string GetDateTimeString(DateTimeOffset dateTime, bool justMonthYear = false, bool onlyDate = false)
        {
            string format;
            if (justMonthYear)
            {
                format = DATE_MONTH_YEAR_FORMAT;
                onlyDate = false; // Ignore whatever was passed in.
            }
            else
            {
                format = DATE_FORMAT;
            }

            if (!onlyDate)
            {
                format += TIME_FORMAT;
            }
            return dateTime.ToLocalTime().ToString(format);
        }

        /// <summary>Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.</summary>
        /// <param name="routeParams">The pieces of the route.</param>
        /// <returns></returns>
        public static string GetInternalSlug(params string[] routeParams)
        {
            routeParams = routeParams.Where(routeVal => !string.IsNullOrEmpty(routeVal)).ToArray();
            return string.Join('/', routeParams);
        }

        /// <summary>Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.</summary>
        /// <param name="route">The pieces of the route.</param>
        /// <returns></returns>
        public static string GetLeafSlug(string route)
        {
            string[] pieces = route.Split('/');
            return pieces[^1];
        }

        /// <summary>Gets the string value of the model.</summary>
        /// <param name="model">The model type.</param>
        /// <returns>Model type.</returns>
        public static string GetModelType(object model)
        {
            string modelType = model.GetType().ToString();
            modelType = modelType[(modelType.LastIndexOf(".") + 1)..];
            return modelType;
        }

        /// <summary>Converts an integer to a "90%" percent string.</summary>
        /// <param name="percent">The integer percent value.</param>
        /// <returns>See summary.</returns>
        public static string GetPercentString(int percent)
        {
            return string.Format("{0}%", percent);
        }

        /// <summary>Given a value and a count of decimals, return the value as a string percentage.</summary>
        /// <param name="percent">The percentage number</param>
        /// <param name="decimals">The number of decimals to display</param>
        /// <returns>(32.7454, 2) returns 32.75%</returns>
        public static string GetPercentString(double percent, int decimals = 2)
        {
            string formatString = GetPercentageFormatString(decimals);
            return string.Format(formatString, percent);
        }

        /// <summary>Given a value and a count of decimals, return the value as a string percentage.</summary>
        /// <param name="percent">The percentage number</param>
        /// <param name="decimals">The number of decimals to display</param>
        /// <returns>(32.7454, 2) returns 32.75%</returns>
        public static string GetPercentString(float percent, int decimals = 2)
        {
            string formatString = GetPercentageFormatString(decimals);
            return string.Format(formatString, percent);
        }

        /// <summary>Whether or not the date time is the minimum (empty).</summary>
        /// <param name="dateTime">The date being compared.</param>
        /// <returns>True if so, false otherwise.</returns>
        public static bool IsMinimumDate(DateTime dateTime) => dateTime == default;

        /// <summary>Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.</summary>
        public static void ParseInternalSlug(string route, out string country, out string state, out string slug)
        {
            string[] pieces = route.Split('/');

            if (pieces.Length == 2)
            {
                country = pieces[0];
                state = string.Empty;
                slug = pieces[1];
            }
            else
            {
                country = pieces[0];
                state = pieces[1];
                slug = pieces[2];
            }
        }

        /// <summary>Get a percentage format string with the specified number of decimal places.</summary>
        /// <param name="decimals">The number of decimals desired. The default is 0.</param>
        /// <returns>A format string to be used to format a percentage.</returns>
        private static string GetPercentageFormatString(int decimals)
        {
            string formatString = "{0:P" + decimals + "}";
            return formatString;
        }
    }
}
