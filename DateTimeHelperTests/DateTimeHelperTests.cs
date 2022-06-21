using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTimeHelper.Tests
{
    [TestClass()]
    public class DateTimeHelperTests
    {
        [DataTestMethod]
        [DataRow(null, DayOfWeek.Sunday)]
        [DataRow("test", DayOfWeek.Sunday)]
        [DataRow("ar-AE", DayOfWeek.Saturday)]
        [DataRow("ar-EG", DayOfWeek.Saturday)]
        [DataRow("en-US", DayOfWeek.Sunday)]
        [DataRow("zh-CN", DayOfWeek.Sunday)]
        [DataRow("en-NZ", DayOfWeek.Monday)]
        [DataRow("en-GB", DayOfWeek.Monday)]
        public void GetFirstDayOfWeekTest(string x, DayOfWeek expected)
        {
            var actual = DateTimeHelper.GetFirstDayOfWeek(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetHourStartData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01, 17, 30, 30), new DateTime(2022, 01, 01, 17, 0, 0) },
                new object[] { new DateTime(2022, 02, 28, 13, 45, 00), new DateTime(2022, 02, 28, 13, 0, 0) },
                new object[] { new DateTime(2022, 06, 04, 20, 15, 45), new DateTime(2022, 06, 04, 20, 0, 0) },
            };

        [TestMethod]
        [DynamicData(nameof(GetHourStartData))]
        public void GetHourStartTest(DateTime x, DateTime expected)
        {
            var actual = DateTimeHelper.GetHourStart(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetMinuteStartData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01, 17, 30, 30), new DateTime(2022, 01, 01, 17, 30, 0) },
                new object[] { new DateTime(2022, 02, 28, 13, 45, 00), new DateTime(2022, 02, 28, 13, 45, 0) },
                new object[] { new DateTime(2022, 06, 04, 20, 15, 45), new DateTime(2022, 06, 04, 20, 15, 0) },
            };

        [TestMethod]
        [DynamicData(nameof(GetMinuteStartData))]
        public void GetMinuteStartTest(DateTime x, DateTime expected)
        {
            var actual = DateTimeHelper.GetMinuteStart(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetWeekStartData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), null,  new DateTime(2021, 12, 26) },
                new object[] { new DateTime(2022, 01, 01), "test",  new DateTime(2021, 12, 26) },
                new object[] { new DateTime(2022, 01, 01), "ar-AE",  new DateTime(2022, 01, 01) },
                new object[] { new DateTime(2022, 01, 01), "en-US",  new DateTime(2021, 12, 26) },
                new object[] { new DateTime(2022, 01, 01), "en-GB",  new DateTime(2021, 12, 27) },
                new object[] { new DateTime(2022, 06, 01), "ar-AE",  new DateTime(2022, 05, 28) },
                new object[] { new DateTime(2022, 06, 01), "en-US",  new DateTime(2022, 05, 29) },
                new object[] { new DateTime(2022, 06, 01), "en-GB",  new DateTime(2022, 05, 30) },
            };

        [TestMethod]
        [DynamicData(nameof(GetWeekStartData))]
        public void GetWeekStartTest(DateTime x, string y, DateTime expected)
        {
            var actual = DateTimeHelper.GetWeekStart(x, y);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetMonthStartData =>
            new[] {
                new object[] { new DateTime(2022, 01, 30), new DateTime(2022, 01, 01) },
                new object[] { new DateTime(2022, 02, 28), new DateTime(2022, 02, 01) },
                new object[] { new DateTime(2022, 06, 04), new DateTime(2022, 06, 01) },
            };

        [TestMethod]
        [DynamicData(nameof(GetMonthStartData))]
        public void GetMonthStartTest(DateTime x, DateTime expected)
        {
            var actual = DateTimeHelper.GetMonthStart(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetYearStartData =>
            new[] {
                new object[] { new DateTime(2020, 12, 30), new DateTime(2020, 01, 01) },
                new object[] { new DateTime(2021, 10, 12), new DateTime(2021, 01, 01) },
                new object[] { new DateTime(2022, 06, 01), new DateTime(2022, 01, 01) },
            };

        [TestMethod]
        [DynamicData(nameof(GetYearStartData))]
        public void GetYearStartTest(DateTime x, DateTime expected)
        {
            var actual = DateTimeHelper.GetYearStart(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetMinDateData =>
            new[] {
                new object[] { DateTime.MinValue }
            };

        [TestMethod]
        [DynamicData(nameof(GetMinDateData))]
        public void GetMinDateTest(DateTime expected)
        {
            var actual = DateTimeHelper.GetMinDate();
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetMaxDateData =>
            new[] {
                new object[] { DateTime.MaxValue }
            };

        [TestMethod]
        [DynamicData(nameof(GetMaxDateData))]
        public void GetMaxDateTest(DateTime expected)
        {
            var actual = DateTimeHelper.GetMaxDate();
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> NumberOfWeeksData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), null, 5 },
                new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), "test", 5 },
                new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), "ar-AE", 4 },
                new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), "en-US", 5 },
                new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), "en-GB", 5 },
                new object[] { new DateTime(2022, 06, 01), new DateTime(2022, 07, 01), "ar-AE", 5 },
                new object[] { new DateTime(2022, 06, 01), new DateTime(2022, 07, 01), "en-US", 4 },
                new object[] { new DateTime(2022, 06, 01), new DateTime(2022, 07, 01), "en-GB", 4 },
            };

        [TestMethod]
        [DynamicData(nameof(NumberOfWeeksData))]
        public void GetNumberOfWeeksTest(DateTime x, DateTime y, string z, int expected)
        {
            var actual = DateTimeHelper.GetNumberOfWeeks(x, y, z);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsWeekdayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), true },
                new object[] { new DateTime(2022, 01, 04), true },
                new object[] { new DateTime(2022, 01, 05), true },
                new object[] { new DateTime(2022, 01, 06), true },
                new object[] { new DateTime(2022, 01, 07), true },
            };

        [TestMethod]
        [DynamicData(nameof(IsWeekdayData))]
        public void IsWeekdayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsWeekday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsWeekendData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), true },
                new object[] { new DateTime(2022, 01, 02), true },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsWeekendData))]
        public void IsWeekendTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsWeekend(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsSaturdayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), true },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsSaturdayData))]
        public void IsSaturdayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsSaturday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsSundayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), true },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsSundayData))]
        public void IsSundayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsSunday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsMondayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), true },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsMondayData))]
        public void IsMondayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsMonday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsTuesdayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), true },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsTuesdayData))]
        public void IsTuesdayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsTuesday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsWednesdayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), true },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsWednesdayData))]
        public void IsWednesdayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsWednesday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsThursdayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), true },
                new object[] { new DateTime(2022, 01, 07), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsThursdayData))]
        public void IsThursdayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsThursday(x);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> IsFridayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), false },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), true },
            };

        [TestMethod]
        [DynamicData(nameof(IsFridayData))]
        public void IsFridayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsFriday(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(-10, false)]
        [DataRow(0, false)]
        [DataRow(10000, false)]
        [DataRow(1, true)]
        [DataRow(1066, true)]
        [DataRow(1976, true)]
        [DataRow(2022, true)]
        [DataRow(9999, true)]
        public void IsValidYearTest(int x, bool expected)
        {
            var actual = DateTimeHelper.IsValidYear(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(13, false)]
        [DataRow(22, false)]
        [DataRow(1, true)]
        [DataRow(6, true)]
        [DataRow(8, true)]
        [DataRow(10, true)]
        [DataRow(12, true)]
        public void IsValidMonthTest(int x, bool expected)
        {
            var actual = DateTimeHelper.IsValidMonth(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2022, 2, 29, false)]
        [DataRow(2022, 11, 31, false)]
        [DataRow(2022, 12, 32, false)]
        [DataRow(2022, 13, 1, false)]
        [DataRow(1, 1, 1, true)]
        [DataRow(2022, 1, 1, true)]
        [DataRow(2022, 6, 30, true)]
        [DataRow(2020, 12, 31, true)]
        public void IsValidDayTest(int x, int y, int z, bool expected)
        {
            var actual = DateTimeHelper.IsValidDay(x, y, z);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2022, 2, 29, false)]
        [DataRow(2022, 11, 31, false)]
        [DataRow(2022, 12, 32, false)]
        [DataRow(2022, 13, 1, false)]
        [DataRow(2020, 2, 29, true)]
        [DataRow(1, 1, 1, true)]
        [DataRow(22, 5, 5, true)]
        [DataRow(2022, 1, 1, true)]
        [DataRow(2022, 6, 30, true)]
        [DataRow(2020, 12, 31, true)]
        public void IsValidDateTest(int x, int y, int z, bool expected)
        {
            var actual = DateTimeHelper.IsValidDate(x, y, z);
            Assert.AreEqual(expected, actual);
        }
    }
}