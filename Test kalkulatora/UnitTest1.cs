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
        public string LOTO(int max)
        {
            string pattern = "";
            var rand = new Random();
            double one = rand.Next(max);
            double two = rand.Next(max+1);
            double three = rand.Next(max+2);
            double four = rand.Next(max+3);
            pattern = one.ToString() + "x^4 + " + two.ToString() + "x^3 + " + three.ToString() + "x^2 + " + one.ToString() + "x +" + max.ToString();
            return pattern;
        }



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
                Input.Clear();
                Input.SendKeys(data);
                Click.Click();
                Thread.Sleep(1000);
            }

            Draw("2x^4 - 5x + 10");
            for (int i = 0; i <100; i++)
            {
                Draw(LOTO(i+2));
            }
            
        }
        [TearDown]
        public void QuitDriver()
        {
            Thread.Sleep(10000);
              driver1.Quit();
        }
    }
}
