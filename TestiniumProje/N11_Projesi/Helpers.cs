﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace N11_Projesi
{
  public  class Helpers
    {
     
        //Buradaki amaç 4 ana tarayıcıdan uygulamamı başlatmak.
        public string CurrentPcDefaultBrowserName()
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string browserName;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice))
            {
                if (userChoiceKey == null)
                    return "None";

                object progIdValue = userChoiceKey.GetValue("Progid");

                if (progIdValue == null)
                    return "None";

                browserName = progIdValue.ToString();

                if (browserName.Contains("Chrome"))
                    browserName = "Chrome";

                else if (browserName.Contains("IE"))
                    browserName = "InternetExplorer";

                else if (browserName.Contains("Firefox"))
                    browserName = "Firefox";

                else if (browserName.Contains("Safari"))
                    browserName = "Safari";

                else
                    browserName = "None";
            }
            return browserName;
        }

        public class ReturnModel
        {
            public bool IsSuccess { get; set; }

            public string ErrorMessage { get; set; }
        }


        public ReturnModel TestStartFirefox()
        {
            ReturnModel testOk = new ReturnModel();
            try
            {
                IWebDriver driver = new FirefoxDriver();
                string link = @"http://www.n11.com/";
                driver.Navigate().GoToUrl(link);

                //LOGİN KISMI

                //driver.FindElement(By.ClassName("btnSignIn")).Click();
                //driver.FindElement(By.Id("email")).SendKeys("tutkutektas@hot.com");
                //driver.FindElement(By.Id("password")).SendKeys("tutkutektaspassword");
                //driver.FindElement(By.Id("loginButton")).Click();

                //Arama sonucunda 2. sayfa seçilme işlemi ve rastgele bir ürünü seçme işlemi

                driver.FindElement(By.Id("searchData")).SendKeys("Bilgisayar");
                driver.FindElement(By.ClassName("searchBtn")).Click();
                driver.FindElement(By.XPath(".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click();
                //Yukardaki kodda .XPATH ile tüm sayfada döndük id si contentListing içine girip en alttaki 2. seçeneği seçtirdik.
                //Bunları yaparken contentListing içinde tek div var ona girdik sonra o divin içindede tek div var
                //3. kısımda 2 tane div var biz ortadaki olan div[2] yi seçtik. Son kısımda 4 div var. en altta sayfa geçişlerini sağlayan 4.Divi seçtik
                //4.Divin içindende sayfa adlar 'a' ile sıralanmış o yüzden a2 yi seçtik.
                driver.FindElement(By.XPath(".//*[@id='p-402919973']/div/a")).Click();

                //Son Kısım Sepet işlemleri
                driver.FindElement(By.XPath(".//*[@class='btnHolder']a[2]")).Click();
                //driver.FindElement(By.ClassName("btnAddBasket")).Click();
                driver.FindElement(By.ClassName("myBasket")).Click();
                driver.FindElement(By.ClassName("spinnerArrow")).Click();
                driver.FindElement(By.ClassName("removeProdData")).Click();

                testOk.IsSuccess = true;

            }
            catch (Exception ex)
            {
                testOk.IsSuccess = false;
                testOk.ErrorMessage = "Hata : " + ex.Message;
            }
            return testOk;
        }
       

    }
}
