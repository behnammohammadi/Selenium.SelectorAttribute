using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.SelectorAttributeTests.Models;
using Xunit;

namespace Selenium.SelectorAttribute.Tests
{
    public class ExtensionsTests
    {
        private readonly IWebDriver _driver;
        public ExtensionsTests()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
        }
        [Fact]
        public void FindElementsByModelCssSelectorTest()
        {
            var result = _driver.FindElementsByModel<CssModel>();

            Assert.False(string.IsNullOrEmpty(result.Title));
            Assert.True(string.IsNullOrEmpty(result.NullSelectorElement));
            Assert.True(result.ArticleCount > 0);
        }

        [Fact]
        public void FindElementsByModelXPathSelectorTest()
        {
            var result = _driver.FindElementsByModel<XPathModel>();

            Assert.False(string.IsNullOrEmpty(result.Title));
            Assert.True(string.IsNullOrEmpty(result.NullSelectorElement));
            Assert.True(result.ArticleCount > 0);
        }
    }
}