using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.Events;
using System.Data;

namespace AndroidAppiumTests
{
    public class Tests
    {
        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub"; 
        private const string appLocation = @"C:\com.example.androidappsummator.apk"; 
        private AndroidDriver<AndroidElement> driver;   
        private AppiumOptions options;  

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android"};
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement> (new Uri(appiumUrl), options); 
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_CalculateTwoPositiveNumbers()
        {
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.SendKeys("10");   
            secondInput.SendKeys("5");
            calcButton.Click(); 

            var result = resultField.Text;

            Assert.That(result, Is.EqualTo("15"));
        }

        [Test]
        public void Test_CalculateInvalidNumbers()
        {
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.SendKeys("10");
            secondInput.SendKeys("bbbb");
            calcButton.Click();

            var result = resultField.Text;

            Assert.That(result, Is.EqualTo("error"));
        }
    }
}