using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium.SelectorAttribute.Attributes;
using System;

namespace Selenium.SelectorAttribute
{
    public static class Extensions
    {
        public static T FindElementsByModel<T>(this IWebDriver remoteWebDriver) where T : class, new()
        {
            if (remoteWebDriver is null)
                throw new ArgumentNullException(nameof(remoteWebDriver));

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
                        data = remoteWebDriver.FindElement(By.CssSelector(cssSelector.Selector));
                        break;

                    case XPathSelectorAttribute xPathSelector:
                        data = remoteWebDriver.FindElement(By.XPath(xPathSelector.Selector));
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
