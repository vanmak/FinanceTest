using OpenQA.Selenium;

namespace FinanceTest.Configuration
{
	public abstract class WebDriverBase
	{
		protected WebDriverBase(ExtendedDriver extendedDriver)
		{
			Driver = extendedDriver.Driver;
			Waiter = extendedDriver.Waiter;
			JavaScriptExecutor = (IJavaScriptExecutor)Driver;
           
        }

		protected IWebDriver Driver { get; }
		protected ElementWaiter Waiter { get; }
		protected IJavaScriptExecutor JavaScriptExecutor { get; }
	}
}
