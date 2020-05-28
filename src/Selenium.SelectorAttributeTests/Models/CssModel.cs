using Selenium.SelectorAttribute.Attributes;

namespace Selenium.SelectorAttributeTests.Models
{
    public class CssModel
    {
        [CssSelector("#mp-welcome > a")]
        public string Title { get; set; }
        [CssSelector("#lang > p > a:nth-child(3)")]
        public double ArticleCount { get; set; }
        [CssSelector("")]
        public string NullSelectorElement { get; set; }
    }
}
