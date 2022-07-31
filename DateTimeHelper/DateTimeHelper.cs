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
        /// Returns the number of years between two dates.
        /// </summary>
        /// <param name="value">Value date</param>
        /// <param name="compare">Compare date</param>
        public static int GetAgeInYears(DateTime value, DateTime compare)
        {
            if (value > compare)
                throw new ArgumentOutOfRangeException(nameof(value));

            int age = value.Year - compare.Year;
            if (value < compare.AddYears(age))
                age--;

            return age;
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
        /// Gets the DateTime.MinValue.
        /// </summary>
        public static DateTime GetMinDate() =>
            DateTime.MinValue;

        /// <summary>
        /// Gets the DateTime.MaxValue.
        /// </summary>
        public static DateTime GetMaxDate() =>
            DateTime.MaxValue;

        /// <summary>
        /// Gets number of weeks in specified time interval.
        /// </summary>
        /// <param name="dateFrom">Time from</param>
        /// <param name="dateTo">Time to</param>
        public static int GetNumberOfWeeks(DateTime dateFrom, DateTime dateTo) =>
            DateTimeHelper
                .GetNumberOfWeeks(dateFrom, dateTo, null);

        /// <summary>
        /// Gets number of weeks in specified time interval.
        /// </summary>
        /// <param name="dateFrom">Time from</param>
        /// <param name="dateTo">Time to</param>
        /// <param name="culture">Culture</param>
        public static int GetNumberOfWeeks(DateTime dateFrom, DateTime dateTo, string? culture)
        {
            dateFrom = DateTimeHelper.GetWeekStart(dateFrom, culture);
            var timeSpan = dateTo.Subtract(dateFrom);
            return (timeSpan.Days + 1) / 7;
        }

        /// <summary>
        /// Returns the specific datetime part.
        /// </summary>
        /// <param name="dateTime">Date</param>
        /// <param name="timeSpan">Timespan to remove</param>
        private static DateTime IgnoreTimeSpan(DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
                return dateTime;

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// Returns value with the milliseconds removed.
        /// </summary>
        /// <param name="dateTime">Date</param>
        public static DateTime IgnoreMilliseconds(DateTime dateTime) =>
            IgnoreTimeSpan(dateTime, TimeSpan.FromMilliseconds(1000));

        /// <summary>
        /// Returns value with the seconds removed.
        /// </summary>
        /// <param name="dateTime">Date</param>
        public static DateTime IgnoreSeconds(DateTime dateTime) => 
            IgnoreTimeSpan(dateTime, TimeSpan.FromSeconds(60));

        /// <summary>
        /// Returns value with the minutes removed.
        /// </summary>
        /// <param name="dateTime">Date</param>
        public static DateTime IgnoreMinutes(DateTime dateTime) => 
            IgnoreTimeSpan(dateTime, TimeSpan.FromMinutes(60));

        /// <summary>
        /// Returns value with the hours removed.
        /// </summary>
        /// <param name="dateTime">Date</param>
        public static DateTime IgnoreHours(DateTime dateTime) =>
            IgnoreTimeSpan(dateTime, TimeSpan.FromHours(24));         

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

        /// <summary>
        /// Returns true if the date is Tuesday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsTuesday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Returns true if the date is Wednesday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsWednesday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Returns true if the date is Thursday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsThursday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Returns true if the date is Friday.
        /// </summary>
        /// <param name="date">Date</param>
        public static bool IsFriday(this DateTime date) =>
            date.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Returns true if the hour is a valid hour.
        /// </summary>
        /// <param name="hour">Hour</param>
        public static bool IsValidHour(int hour) =>
            hour >= 0 &&
            hour <= 23;

        /// <summary>
        /// Returns true if the minute is a valid minute.
        /// </summary>
        /// <param name="minute">Minute</param>
        public static bool IsValidMinute(int minute) =>
            minute >= 0 &&
            minute <= 59;

        /// <summary>
        /// Returns true if the second is a valid second.
        /// </summary>
        /// <param name="second">Second</param>
        public static bool IsValidSecond(int second) =>
            second >= 0 &&
            second <= 59;

        /// <summary>
        /// Returns true if the year is a valid year.
        /// </summary>
        /// <param name="year">Year</param>
        public static bool IsValidYear(int year) =>
            year >= DateTime.MinValue.Year &&
            year <= DateTime.MaxValue.Year;

        /// <summary>
        /// Returns true if the month is a valid month.
        /// </summary>
        /// <param name="month">Month</param>
        public static bool IsValidMonth(int month) =>
            month >= 1 &&
            month <= 12;

        /// <summary>
        /// Returns true if the day is a valid day.
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        public static bool IsValidDay(int year, int month, int day) =>
            IsValidYear(year) &&
            IsValidMonth(month) &&
            day >= 1 &&
            DateTime.DaysInMonth(year, month) >= day;

        /// <summary>
        /// Returns true if the year, month, and day is a valid date.
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        public static bool IsValidDate(int year, int month, int day) =>
            IsValidYear(year) &&
            IsValidMonth(month) &&
            IsValidDay(year, month, day);

        /// <summary>
        /// Returns true if the hour, minute, and second is a valid time.
        /// </summary>
        /// <param name="hour">Hour</param>
        /// <param name="minute">Minute</param>
        /// <param name="second">Second</param>
        public static bool IsValidTime(int hour, int minute, int second = 0) =>
            IsValidHour(hour) &&
            IsValidMinute(minute) &&
            IsValidSecond(second);
    }
}
