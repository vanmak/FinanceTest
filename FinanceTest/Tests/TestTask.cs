using FinanceTest.Navigation;
using FinanceTest.PageObject;
using NUnit.Framework;
using System.Collections.Generic;

namespace FinanceTest.Tests
{
	public class TestTask:BaseTest
	{
		private NBUPage _nbuPage;
		private MainPage _mainPage;
		private PageNavigation _navigation;
		public const int AmountOfMoney = 100;

			[SetUp]
		public void setUP()
		{
			_mainPage = new MainPage(ExtendedDriver);
			_nbuPage = new NBUPage(ExtendedDriver);
			_navigation = new PageNavigation(ExtendedDriver);

		}

		[Test, Order(1)]
		public void VerifyExchangeRateLessThanSale()
		{

			foreach (string currency in new List<string> { "RUB", "USD", "EUR" })
			{
				Assert.Less(_mainPage.InnerText(_mainPage.ExchangeRateOFPurchase(currency)),
					_mainPage.InnerText(_mainPage.ExchangeRateOFSale(currency)), $"{currency} Exchange Rate isn't correct");
			}
		}

		[Test, Order(2)]
		public void VerifyCulculatorForUSD()
		{
			double exChangeRateofUSD = _mainPage.InnerText(_mainPage.ExchangeRateOFPurchase("USD"));
			_mainPage.selectCurrency("USD");
			_mainPage.CurrencyAmount.Clear();
			_mainPage.CurrencyAmount.SendKeys(System.Convert.ToString(AmountOfMoney));
			var ExChangeAmount = _mainPage.value(_mainPage.CurrencyExchange("UAH"));
			Assert.AreEqual(exChangeRateofUSD * AmountOfMoney, ExChangeAmount);
		}
		[Test, Order(3)]
		public void VerifyThatCheckboxesCheckedByDefault()
		{
			_navigation.ClickTab("НБУ");
			foreach (string currency in new List<string> { "RUB", "USD", "EUR" })
			{
				Assert.IsTrue(_nbuPage.isCheckBoxChecked(currency), $"CheckBox {currency} isn't checked");
			}
		}
		[Test, Order(4)]
		public void VerifyThatUserCanAddNewCurrency()
		{
			List<string> newCurrencies = new List<string> { "JPY", "MDL", "GBP" };
			_navigation.ClickTab("НБУ");
			foreach (string currency in newCurrencies)
			{
				_nbuPage.checkOption(currency);
			}
			_navigation.GoToUrl(MainPage.URL);
			foreach (string currency in newCurrencies)
			{
				Assert.IsTrue(_mainPage.TableRecord(currency).Displayed, $"{currency} isn't displayed");
			}
		}

		[OneTimeTearDown]
		public void CleanUo()
		{
			TestFixtureCleanUp();
		}
	}
}
