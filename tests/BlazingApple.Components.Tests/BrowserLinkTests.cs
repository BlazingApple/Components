using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BlazingApple.Components.Tests;

[TestClass]
public class BrowserLinkTests
{
    public static IEnumerable<object[]> IsExternal_Success_Parameters
    {
        get
        {
            yield return new object[] { "https://ourgov.app", false };
            yield return new object[] { "https://ourgov.app/tags", false };
            yield return new object[] { "file://ourgov.app/tags", false };
            yield return new object[] { "file://tags", false };
            yield return new object[] { "file:///tags", false };
            yield return new object[] { "ourgov.app/tags", false };
            yield return new object[] { "docs.ourgov.app/tags", true };
            yield return new object[] { "/", false };
            yield return new object[] { "/tags", false };
            yield return new object[] { "tags", false };
            yield return new object[] { "https://google.com", true };
            yield return new object[] { "ourgov.app", false };
            // yield return new object[] { "docs.ourgov.app", true };
            yield return new object[] { "https://docs.ourgov.app", true };

        }
    }
    [TestMethod]
    [DynamicData(nameof(IsExternal_Success_Parameters))]
    public void IsExternal_Success(string url, bool expected)
    {
        bool actual = BrowserLink.IsExternal("ourgov.app", url);
        Assert.AreEqual(expected, actual);
    }
}
