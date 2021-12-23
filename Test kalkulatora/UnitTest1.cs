using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Segment.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;

namespace Test_kalkulatora
{




    public class Tests
    {
       //sdsdsdsds


        IWebDriver driver1;
        Uri calculator = new Uri("https://www.matemaks.pl/program-do-rysowania-wykresow-funkcji.html");

        [SetUp]
        public void Setup()
        {
            driver1 = new ChromeDriver();

            driver1.Manage().Window.Position = new System.Drawing.Point(0, 0);
            driver1.Manage().Window.Size = new System.Drawing.Size(1500, 1000);

            driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(10);

        }

        [Test]
        public void Test1()
        {
            driver1.Navigate().GoToUrl(calculator);

            IWebElement Input = driver1.FindElement(By.Id("wzor_funkcji"));
            IWebElement Click = driver1.FindElement(By.Id("rysuj_button"));
            void Draw(string data)
        {
                Input.Click();
                Input.SendKeys(data);
                Click.Click();
        }

            Draw("2x^4 - 5x + 10");

        }
        [TearDown]
        public void QuitDriver()
        {
            Thread.Sleep(10000);
              driver1.Quit();
        }
    }
}
