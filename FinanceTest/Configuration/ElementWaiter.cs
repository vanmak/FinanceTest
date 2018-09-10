using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinanceTest.Configuration
{

	public class ElementWaiter
	{
		private const int _SHORT_DURATION_IN_SEC = 1;
		private const int _POLLING_INTERVAL_IN_MILLISECONDS = 20;
		private readonly ExtendedDriver _extendedDriver;
		public const int DEFAULT_DURATION_IN_SEC = 10;

		public ElementWaiter(ExtendedDriver extendedDriver)
		{
			_extendedDriver = extendedDriver;
		}

		public bool IsElementDisplayed(By elementSelector)
		{
			bool displayState = false;
			if (_extendedDriver.Driver.FindElements(elementSelector).Count > 0)
			{
				displayState = _extendedDriver.Driver.FindElement(elementSelector).Displayed;
			}
			return displayState;
		}

		public bool IsElementDisplayed(IWebElement element)
		{
			bool displayState;
			try
			{
				displayState = element.Displayed;
			}
			catch (NoSuchElementException)
			{
				displayState = false;
			}
			return displayState;
		}

		private WebDriverWait GetWebDriverWait(int durationInSeconds = DEFAULT_DURATION_IN_SEC)
		{
			var webDriverWait = new WebDriverWait(_extendedDriver.Driver, TimeSpan.FromSeconds(durationInSeconds));
			return webDriverWait;
		}
		private static DefaultWait<IWebElement> GetDefaultWait(IWebElement element, int durationInSeconds = DEFAULT_DURATION_IN_SEC)
		{
			DefaultWait<IWebElement> webDriverWait =
				new DefaultWait<IWebElement>(element)
				{
					Timeout = TimeSpan.FromSeconds(durationInSeconds),
					PollingInterval = TimeSpan.FromMilliseconds(_POLLING_INTERVAL_IN_MILLISECONDS)
				};
			return webDriverWait;
		}

		public bool IsElementClickable(By by, int durationInSeconds = _SHORT_DURATION_IN_SEC)
		{
			WebDriverWait webDriverWait = GetWebDriverWait(durationInSeconds);
			bool isClickable;
			try
			{
				webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
				isClickable = true;
			}
			catch (WebDriverTimeoutException)
			{
				isClickable = false;
			}
			return isClickable;
		}

		public static IWebElement WaitUntilClickable(IWebElement element, int durationInSeconds = DEFAULT_DURATION_IN_SEC)
		{
			DefaultWait<IWebElement> webDriverWait = GetDefaultWait(element, durationInSeconds);
			webDriverWait.Until(ExpectedConditions.ElementToBeClickable);
			return element;
		}

		public IWebElement WaitUntilClickable(By elementSelector, int durationInSeconds = DEFAULT_DURATION_IN_SEC)
		{

			WebDriverWait webDriverWait = GetWebDriverWait(durationInSeconds);
			return webDriverWait.Until(ExpectedConditions.ElementToBeClickable(elementSelector));
		}

		public void WaitUntilInvisible(By elementSelector, int durationInSeconds = DEFAULT_DURATION_IN_SEC)
		{
			var webDriverWait = new WebDriverWait(_extendedDriver.Driver, TimeSpan.FromSeconds(durationInSeconds));
			webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementSelector));
		}
	}
}
