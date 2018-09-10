using OpenQA.Selenium;

namespace FinanceTest.Configuration
{

	public class ExtendedDriver
	{
		public ExtendedDriver()
		{
			Driver = DriverFactory.GetNewInstance();
			Driver.Url = DriverFactory.DefaultUrl();
			Driver.Manage().Window.Maximize();
			Waiter = new ElementWaiter(this);
		}

		public IWebDriver Driver { get; }
		public ElementWaiter Waiter { get; }
	}
}