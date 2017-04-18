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
           IWebDriver driver1 = new PhantomJSDriver(GetPhantomJSDriverService());
            driver1.Navigate().GoToUrl(url);
            if (driver1.Title == "用户登录 - 博客园")
            {
                driver1.FindElement(By.Id("input1")).SendKeys("xielongbao");
                driver1.FindElement(By.Id("input2")).SendKeys("1234");
                driver1.FindElement(By.Id("signin")).Click();
            }
            Console.WriteLine(driver1.PageSource);

            IWebDriver driver2 = new PhantomJSDriver(GetPhantomJSDriverService());
            driver2.Navigate().GoToUrl("https://home.cnblogs.com/");
            Console.WriteLine(driver2.PageSource);
            Console.WriteLine(driver1.PageSource);

            Console.Read();
        }

        private static PhantomJSDriverService GetPhantomJSDriverService()
        {
            PhantomJSDriverService pds = PhantomJSDriverService.CreateDefaultService();
            //设置代理服务器地址
            //pds.Proxy = $"{ip}:{port}";  
            //设置代理服务器认证信息
            //pds.ProxyAuthentication = GetProxyAuthorization();
            return pds;
        }
    }
}