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
        public void NumberOfWeeksTest(DateTime x, DateTime y, string z, int expected)
        {
            var actual = DateTimeHelper.NumberOfWeeks(x, y, z);
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

        public static IEnumerable<object[]> IsSundayData =>
            new[] {
                new object[] { new DateTime(2022, 01, 01), false },
                new object[] { new DateTime(2022, 01, 02), true },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 05), false },
            };

        [TestMethod]
        [DynamicData(nameof(IsSundayData))]
        public void IsSundayTest(DateTime x, bool expected)
        {
            var actual = DateTimeHelper.IsSunday(x);
            Assert.AreEqual(expected, actual);
        }
    }
}