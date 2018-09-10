using FinanceTest.Configuration;
using OpenQA.Selenium;

namespace FinanceTest.Navigation
{
	public class PageNavigation : WebDriverBase
	{
		public PageNavigation(ExtendedDriver extendedDriver) : base(extendedDriver)
		{
		}

		public IWebElement TabElement(string tabName) => Driver.FindElement(By.LinkText(tabName));

		public void GoToUrl(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}

		public void ClickTab(string tabName)
		{
			TabElement(tabName).Click();
		}	
	}
}
