using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Test_kalkulatora
{
    public class Tests
    {

        IWebDriver driver1;
        Uri calculator = new Uri("https://www.matemaks.pl/program-do-rysowania-wykresow-funkcji.html");

        [SetUp]
        public void Setup()
        {
            driver1 = new ChromeDriver();

            driver1.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver1.Manage().Window.Size = new System.Drawing.Size(1500, 1000);

            driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(10);

        }

        [Test]
        public void Test1()
        {
           
        }
        [TearDown]
        public void QuitDriver()
        {
            Thread.Sleep(10);
              driver1.Quit();
        }
    }
}
