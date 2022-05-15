using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BlazingApple.Components;

namespace BlazingApple.Components.Tests
{
    [TestClass]
    public class BadgeTests
    {
        private static IEnumerable<object[]> BadgeNameTestCases
        {
            get
            {
                yield return new object[] { "hello world, how are you", false, "HWHA" };
                yield return new object[] { "\"SSD\"", true, "SSD" };
                yield return new object[] { "SSD", true, "SSD" };
                yield return new object[] { "\"happy world to us\"", false, "HWTU" };
                yield return new object[] { "\"American Association of Automobiles dba AAA\"", false, "AAOA" };
                yield return new object[] { "\"Association of Wisconsin Snowmobile Clubs, Inc.\"", false, "AOWS" };
                yield return new object[] { "\"Americash Loans of WI, LLC\"", false, "\"ALW\"" };
            }
        }

        [TestMethod, DataTestMethod]
        [DynamicData(nameof(BadgeNameTestCases))]
        public void GetBadgeString_TestAbbreviations(string testCase, bool useFullString, string expected)
        {
            string actual = Badge.GetBadgeString(testCase, useFullString);
            Assert.AreEqual(expected, actual);
        }
    }
}
