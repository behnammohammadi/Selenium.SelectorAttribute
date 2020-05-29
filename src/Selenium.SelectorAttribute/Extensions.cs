using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium.SelectorAttribute.Attributes;
using System;

namespace Selenium.SelectorAttribute
{
    public static class Extensions
    {
        /// <summary>
        /// Finds the first properties in the model using the given selector model that decorate with property attributes.
        /// </summary>
        /// <typeparam name="T">Model that decorate with attributes that derived from <see cref="T:Selenium.SelectorAttribute.Attributes.BaseAttribute" /></typeparam>
        /// <returns>The first matching properties in model on the current context.</returns>
        public static T FindElementsByModel<T>(this IWebDriver webDriver) where T : class, new()
        {
            if (webDriver is null)
                throw new ArgumentNullException(nameof(webDriver));

            var model = new T();

            foreach (var prop in model.GetType().GetProperties())
            {
                var attribute = (BaseAttribute)Attribute.GetCustomAttribute(prop, typeof(BaseAttribute));

                if (attribute == null || string.IsNullOrEmpty(attribute.Selector))
                    continue;

                IWebElement data;

                switch (attribute)
                {
                    case CssSelectorAttribute cssSelector:
                        data = webDriver.FindElement(By.CssSelector(cssSelector.Selector));
                        break;

                    case XPathSelectorAttribute xPathSelector:
                        data = webDriver.FindElement(By.XPath(xPathSelector.Selector));
                        break;

                    default:
                        continue;
                }

                if (data != null && !string.IsNullOrEmpty(data.Text))
                    prop.SetValue(model, Convert.ChangeType(data.Text, prop.PropertyType));
            }

            return model;
        }
    }
}
