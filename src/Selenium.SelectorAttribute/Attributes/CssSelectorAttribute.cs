namespace Selenium.SelectorAttribute.Attributes
{
    /// <summary>
    ///     Specifies the Css selector to fetch data into decorated property.
    /// </summary>
    public sealed class CssSelectorAttribute : BaseAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CssSelectorAttribute" /> class.
        /// </summary>
        /// <param name="selector">Css selector</param>
        public CssSelectorAttribute(string selector) : base(selector) { }
    }
}
