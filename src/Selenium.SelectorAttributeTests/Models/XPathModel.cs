using Selenium.SelectorAttribute.Attributes;

namespace Selenium.SelectorAttributeTests.Models
{
    public class XPathModel
    {
        [XPathSelector("//*[@id='mp-welcome']/a")]
        public string Title { get; set; }
        [XPathSelector("//*[@id='lang']/p/a[2]")]
        public double ArticleCount { get; set; }
        [XPathSelector("")]
        public string NullSelectorElement { get; set; }
    }
}
