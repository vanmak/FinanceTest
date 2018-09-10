using OpenQA.Selenium;
using FinanceTest.Configuration;

namespace FinanceTest.PageObject
{

	public class NBUPage : WebDriverBase
	{
		public static string URL = DriverFactory.DefaultUrl()+"NBU";
		public NBUPage(ExtendedDriver extendedDriver) : base(extendedDriver)
		{
		}
		public IWebElement checkBox(string currencyName) => Driver.FindElement(By.XPath($"//th[text()='{currencyName}']/preceding-sibling::td/input"));

		public void checkOption(string name)
		{
			if (checkBox(name).GetAttribute("checked") == null)
			{
				checkBox(name).Click();
			}
		}

		public bool isCheckBoxChecked(string name)
		{
			return System.Convert.ToBoolean(checkBox(name).GetAttribute("checked"));
		}
	}
}
