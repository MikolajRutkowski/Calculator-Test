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
        public string LOTO(int max, int x = 2)
        {
            string pattern = "";
            var rand = new Random();
            for (int i = x; i > 0 ; i--)
            {
                pattern += rand.Next(max).ToString() + "x^" + i.ToString() + " + ";

            }
            pattern += rand.Next(max).ToString();
            return pattern;
        }

        void RandomClik(IWebElement target)
        {
            var rand = new Random();
            if(rand.Next(1,2) == 1)
            {
                target.Click();
            }
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
               // Thread.Sleep(1000);
            }

          
            for (int i = 0; i <10; i++)
            {
                Draw(LOTO(i+2));
            }

            Draw(LOTO(5, 3));

          
            IWebElement Zero = driver1.FindElement(By.Id("miejsca_zerowe"));
            Zero.Click();
            IWebElement OY = driver1.FindElement(By.Id("punkt_przeciecia_y"));
            OY.Click();
            IWebElement Ekstreama = driver1.FindElement(By.Id("ekstrema"));
            Ekstreama.Click();
            IWebElement Asymptoty = driver1.FindElement(By.Id("asymptoty"));
            Asymptoty.Click();
            IWebElement Pochodne = driver1.FindElement(By.Id("pochodne"));
            Pochodne.Click();

            for (int  i = 0;  i < 10 ;  i++)
            {
                Draw(LOTO(i + 5, 5));
                RandomClik(Zero);
                RandomClik(OY);
                RandomClik(Ekstreama);
                RandomClik(Asymptoty);
                RandomClik(Pochodne);
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
