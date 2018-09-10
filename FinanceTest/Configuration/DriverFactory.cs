using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;

namespace FinanceTest.Configuration
{
	public static class DriverFactory
	{
		public static IWebDriver GetNewInstance()
		{
			switch (BrowserType())
			{
				case "chrome":
					var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
					var relativePath = @"..\..\Configuration\Drivers";
					var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));
					return new ChromeDriver(chromeDriverPath);


				case "IE":
					return new InternetExplorerDriver();

				default:
					return new ChromeDriver();
			}
		}

		public static string BrowserType()
		{
			return ConfigurationManager.AppSettings["browser"];
		}

		public static string DefaultUrl()
		{
			return ConfigurationManager.AppSettings["Environment"];
		}
	}
}

