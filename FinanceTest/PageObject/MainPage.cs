using OpenQA.Selenium;
using FinanceTest.Configuration;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace FinanceTest.PageObject
{
	
	public class MainPage: WebDriverBase
	{
		public static string URL = DriverFactory.DefaultUrl();
		public MainPage(ExtendedDriver extendedDriver): base(extendedDriver)
		{
		}			
		public IWebElement ExchangeRateOFPurchase(string currencyName) => Driver.FindElement(By.XPath($"(//th[text()='{currencyName}']//../td/span/span[1])[1]"));
		public IWebElement ExchangeRateOFSale(string currencyName) => Driver.FindElement(By.XPath($"(//th[text()='{currencyName}']//../td/span/span[1])[2]"));
		public IWebElement ExchangeRateOFNBU(string currencyName) => Driver.FindElement(By.XPath($"(//th[text()='{currencyName}']//../td/span/span[1])[3]"));
		public IWebElement CurrencyAmount => Driver.FindElement(By.Id("currency_amount"));
		public IWebElement ConverterCurrencyDropDown => Driver.FindElement(By.Id("converter_currency"));
		public IWebElement CurrencyExchange(string currencyName) => Driver.FindElement(By.CssSelector($"p#{currencyName} input#currency_exchange"));
		public IWebElement TableRecord(string name) => Driver.FindElement(By.XPath($"//tbody/tr/th[text()='{name}']"));
		public double InnerText(IWebElement el)
		{
			return System.Convert.ToDouble(el.GetAttribute("innerText").ToString());
		}

		public void selectCurrency(string value)
		{
			var selectElement = new SelectElement(ConverterCurrencyDropDown);
			selectElement.SelectByValue(value);
		}
		
		public double value(IWebElement el)
		{
			var textWithoutSpaces = Regex.Replace(el.GetAttribute("value").ToString().Trim(), " ", "");
			return System.Convert.ToDouble(textWithoutSpaces);
			
		}
	}
}
