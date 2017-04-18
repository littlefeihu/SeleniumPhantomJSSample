using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;

namespace SeleniumPhantomJSSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://passport.cnblogs.com/user/signin";
           var  driver1 = new PhantomJSDriver(GetPhantomJSDriverService());
            driver1.Navigate().GoToUrl(url);
           
            if (driver1.Title == "用户登录 - 博客园")
            {
                driver1.FindElement(By.Id("input1")).SendKeys("xielongbao");
                driver1.FindElement(By.Id("input2")).SendKeys("1234");
                driver1.FindElement(By.Id("signin")).Click();
            }
            driver1.GetScreenshot().SaveAsFile(@"C:\aa.png", ScreenshotImageFormat.Png);
            var o = driver1.ExecuteScript("$('#signin').val('dsa')");
        
            Console.WriteLine(driver1.PageSource);
            driver1.Navigate().GoToUrl(url);
            Console.WriteLine(driver1.PageSource);
            IWebDriver driver2 = new PhantomJSDriver(GetPhantomJSDriverService());
            driver2.Navigate().GoToUrl("https://home.cnblogs.com/");
            
            Console.WriteLine(driver2.PageSource);
            Console.WriteLine(driver1.PageSource);

            Console.Read();
        }

        private static PhantomJSDriverService GetPhantomJSDriverService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            //Proxy proxy = new Proxy();
            //proxy.HttpProxy = string.Format("127.0.0.1:9999");
      
            //service.ProxyType = "http";
            //service.Proxy = proxy.HttpProxy;
            return service;
        }
    }
}