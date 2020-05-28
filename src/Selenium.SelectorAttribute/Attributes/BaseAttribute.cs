using System;

namespace Selenium.SelectorAttribute.Attributes
{
    /// <summary>
    /// on derived classes we use sealed class because of performance issue on unsealed class attributes.
    /// </summary>
    public abstract class BaseAttribute : Attribute
    {
        protected BaseAttribute(string selector) => Selector = selector;
        public string Selector { get; internal set; }
    }
}
