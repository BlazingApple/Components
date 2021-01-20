using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Services
{
	public static class CommonViewUtils
	{
		private const string DATE_MONTH_YEAR_FORMAT = "MMM \\'yy";
		private const string DATE_FORMAT = "MMM dd \\'yy";
		private const string TIME_FORMAT = " h:mm tt";

		/// <summary>
		/// Returns, in local time, the date string formatted as "Sep 22 '20 8:00 AM".
		/// </summary>
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

		public static bool IsMinimumDate(DateTime dateTime)
		{
			return dateTime == DateTime.MinValue;
		}

		public static string GetPercentString(int percent)
		{
			return string.Format("{0}%", percent);
		}


		/// <summary>
		/// Given a value and a count of decimals, return the value as a string percentage.
		/// </summary>
		/// <param name="percent">The percentage number</param>
		/// <param name="decimals">The number of decimals to display</param>
		/// <returns>(32.7454, 2) returns 32.75%</returns>
		public static string GetPercentString(double percent, int decimals = 2)
		{
			string formatString = _getPercentageFormatString(decimals);
			return string.Format(formatString, percent);
		}

		/// <summary>
		/// Given a value and a count of decimals, return the value as a string percentage.
		/// </summary>
		/// <param name="percent">The percentage number</param>
		/// <param name="decimals">The number of decimals to display</param>
		/// <returns>(32.7454, 2) returns 32.75%</returns>
		public static string GetPercentString(float percent, int decimals = 2)
		{
			string formatString = _getPercentageFormatString(decimals);
			return string.Format(formatString, percent);
		}

		/// <summary>
		/// Get a percentage format string with the specified number of decimal places.
		/// </summary>
		/// <param name="decimals">The number of decimals desired. The default is 0.</param>
		/// <returns>A format string to be used to format a percentage.</returns>
		private static string _getPercentageFormatString(int decimals)
		{
			string formatString = "{0:P" + decimals + "}";
			return formatString;
			for (int i = 0; i < decimals; i++)
			{
				if (i == 1)
				{
					formatString += ".0";
				}
				else
				{
					formatString += "0";
				}
			}
			formatString += "}%";
			return formatString;
		}

		/// <summary>
		/// Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.
		/// </summary>
		/// <param name="routeParams">The pieces of the route.</param>
		/// <returns></returns>
		public static string GetInternalSlug(params string[] routeParams)
		{
			routeParams = routeParams.Where(routeVal => !string.IsNullOrEmpty(routeVal)).ToArray();
			return string.Join('/', routeParams);

		}

		/// <summary>
		/// Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.
		/// </summary>
		/// <param name="routeParams">The pieces of the route.</param>
		/// <returns></returns>
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

		public static string GetModelType(object model)
		{
			string modelType = model.GetType().ToString();
			modelType = modelType.Substring(modelType.LastIndexOf(".") + 1);
			return modelType;
		}

		/// <summary>
		/// Given a broken out slug (broken out by the framework, combine it for easy string comparison in the database.
		/// </summary>
		/// <param name="routeParams">The pieces of the route.</param>
		/// <returns></returns>
		public static string GetLeafSlug(string route)
		{
			string[] pieces = route.Split('/');
			return pieces[pieces.Length - 1];

		}

		/// <summary>
		/// Removes characters that should not be in urls, like periods, spaces, commas.
		/// Spaces and commas are swapped with a "-", while other characters are removed entirely.
		/// 
		/// Do not call this function with "slashes (/)" in the slug, they will be removed. 
		/// Prepend those after calling this function.
		/// </summary>
		/// <param name="name">Name to turn into a slug</param>
		/// <returns></returns>
		public static string CreateSlugFromName(string name)
		{
			string slug;
			slug = name.Replace(".", "");
			slug = slug.Replace(", ", "-");
			slug = slug.Replace(",", "-");
			slug = slug.Replace("{", "");
			slug = slug.Replace("}", "");
			slug = slug.Replace("}", "");
			slug = slug.Replace("^", "");
			slug = slug.Replace("~", "");
			slug = slug.Replace("[", "");
			slug = slug.Replace("]", "");
			slug = slug.Replace("`", "");
			slug = slug.Replace("\\", "");
			slug = slug.Replace(" ", "-");
			slug = slug.ToLowerInvariant();
			return slug;
		}

		#region Http Query Strings
		public static string AddQueryStringValue(string queryString, string parameterName, string parameterValue)
		{
			Contract.Assert(!string.IsNullOrEmpty(parameterName));

			if (string.IsNullOrEmpty(parameterValue))
			{
				return queryString;
			}
			if (string.IsNullOrEmpty(queryString))
			{
				queryString = "?" + parameterName + "=" + parameterValue;
			}
			else
			{
				queryString = queryString + "&" + parameterName + "=" + parameterValue;
			}
			return queryString;
		}
		#endregion

	}
}
