using System.Globalization;

namespace DateTimeHelper
{
    /// <summary>
    /// Global class providing DateTime methods.
    /// </summary>/// 
    public static class DateTimeHelper
    {
        /// <summary>
        /// US English culture code
        /// </summary>
        private const string EnglishCultureCode = "en-US";

        private static CultureInfo EnglishCulture =>
            CultureInfo
                .GetCultureInfo(EnglishCultureCode);

        /// <summary>
        /// Gets the culture info for specified culture.
        /// If culture code is invalid, then US english culture is returned.
        /// </summary>
        /// <param name="cultureCode">Culture code</param>
        private static CultureInfo GetCultureInfo(string? cultureCode)
        {
            if (string.IsNullOrEmpty(cultureCode))
                return EnglishCulture;

            try
            {
                return CultureInfo.GetCultureInfo(cultureCode);
            }
            catch (CultureNotFoundException)
            {
                return EnglishCulture;
            }
        }

        /// <summary>
        /// Gets the first day of the week.
        /// </summary>
        public static DayOfWeek GetFirstDayOfWeek() =>
            DateTimeHelper
                .GetFirstDayOfWeek();

        /// <summary>
        /// Gets the first day of the week.
        /// </summary>
        /// <param name="culture">Culture</param>
        public static DayOfWeek GetFirstDayOfWeek(string? culture) =>
            GetCultureInfo(culture)
                .DateTimeFormat
                .FirstDayOfWeek;

        /// <summary>
        /// Gets current date without minutes and seconds.
        /// </summary>
        /// <param name="date">Date</param>
        public static DateTime GetHourStart(DateTime date) =>
           new(date.Year, date.Month, date.Day, date.Hour, 0, 0);

        /// <summary>
        /// Gets current date without seconds.
        /// </summary>
        /// <param name="date">Date</param>
        public static DateTime GetMinuteStart(DateTime date) =>
            new(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);

        /// <summary>
        /// Gets the date from the beginning of week.
        /// </summary>
        /// <param name="date">Date of week</param>
        public static DateTime GetWeekStart(DateTime date) =>
            DateTimeHelper
                .GetWeekStart(date, null);

        /// <summary>
        /// Gets the date from the beginning of week.
        /// </summary>
        /// <param name="date">Date of week</param>
        /// <param name="culture">Culture</param>
        public static DateTime GetWeekStart(DateTime date, string? culture)
        {
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day);
            DayOfWeek firstDayOfWeek = DateTimeHelper.GetFirstDayOfWeek(culture);
            while (dateTime.DayOfWeek != firstDayOfWeek)
            {
                dateTime = dateTime.AddDays(-1);
            }
            return dateTime;
        }

        /// <summary>
        /// Gets the first day of the month from specific date.
        /// </summary>
        /// <param name="date">Date</param>
        public static DateTime GetMonthStart(DateTime date) =>
            new(date.Year, date.Month, 1);

        /// <summary>
        /// Gets the first day of the year from specific date.
        /// </summary>
        /// <param name="date">Date</param>
        public static DateTime GetYearStart(DateTime date) =>
            new(date.Year, 1, 1);

        /// <summary>
        /// Gets number of weeks in specified time interval.
        /// </summary>
        /// <param name="dateFrom">Time from</param>
        /// <param name="dateTo">Time to</param>
        public static int NumberOfWeeks(DateTime dateFrom, DateTime dateTo) =>
            DateTimeHelper
                .NumberOfWeeks(dateFrom, dateTo, null);

        /// <summary>
        /// Gets number of weeks in specified time interval.
        /// </summary>
        /// <param name="dateFrom">Time from</param>
        /// <param name="dateTo">Time to</param>
        /// <param name="culture">Culture</param>
        public static int NumberOfWeeks(DateTime dateFrom, DateTime dateTo, string? culture)
        {
            dateFrom = DateTimeHelper.GetWeekStart(dateFrom, culture);
            var timeSpan = dateTo.Subtract(dateFrom);
            return (timeSpan.Days + 1) / 7;
        }

        /// <summary>
        /// Returns true if the date is a weekday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsWeekday(DateTime date) =>
            (date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday);

        /// <summary>
        /// Returns true if the date is a weekend.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsWeekend(DateTime date) =>
            (date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday);

        /// <summary>
        /// Returns true if the date is Saturday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsSaturday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Returns true if the date is Sunday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsSunday(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Sunday;

        /// <summary>
        /// Returns true if the date is Monday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsMonday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Monday;
    }
}
