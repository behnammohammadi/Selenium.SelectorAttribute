namespace Selenium.SelectorAttribute.Attributes
{
    /// <summary>
    ///     Specifies the Xpath selector to fetch data into decorated property.
    /// </summary>
    public sealed class XPathSelectorAttribute : BaseAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="XPathSelectorAttribute" /> class.
        /// </summary>
        /// <param name="selector">XPath selector</param>
        public XPathSelectorAttribute(string selector) : base(selector) { }
    }
}
