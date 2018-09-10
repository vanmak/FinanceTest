using FinanceTest.Configuration;

namespace FinanceTest.Tests
{
	public  class BaseTest
	{

		public BaseTest()
		{
			ExtendedDriver = new ExtendedDriver();			
		}

		public ExtendedDriver ExtendedDriver { get; }
	
		public void TestFixtureCleanUp()
		{
			ExtendedDriver.Driver.Quit();
		} 
	}
}