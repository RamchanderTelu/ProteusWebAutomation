using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ProteusWeb.WrapperFactory;

namespace ProteusWeb.Extensions  
{
    public static class ElementExtensions
    {
        public static IWebDriver driver = BrowserFactory.Driver;

        public static void enterText(this IWebElement element, string strText)
        {
            if (strText != null)
            {                
                element.Clear();
                element.SendKeys(strText);
                element.SendKeys(Keys.Tab);
           }
        }
      
        public static void mouseClick(this IWebElement element)
        {
            Actions action = new  Actions(BrowserFactory.Driver);
            action.MoveToElement(element).Build().Perform();
            action.Click(element).Perform();          
        }

       
        public static void selectText(this IWebElement element, string strText)
        {
            if (!string.IsNullOrEmpty(strText))
            {
                SelectElement select = new SelectElement(element);
                select.SelectByText(strText);              
            }
        }
        
        public static void selectValue(this IWebElement element, string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {              
                string control = element.GetAttribute("id");
                SelectElement select = new SelectElement(element);
                select.SelectByValue(strValue);
            }
        }

 
        public static void waitForElementClickable(this IWebElement element)
        {
          
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(90));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));            
        }

        public static object getPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }
       

        public static bool elementVisible(string xpath)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            if (driver.FindElements(By.XPath(xpath)).Count > 0)
            {
                WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool elementExist(string elementName, string Method)
        {             
            try
            {
                if (Method == "XPath")
                {
                    if (driver.FindElements(By.XPath(elementName)).Count >= 1)
                        return true;
                }
                else if (Method == "PartialLinkText")
                {
                    if (driver.FindElements(By.PartialLinkText(elementName)).Count >= 1)
                        return true;
                }
                else if(Method == "Id")
                {
                    if (driver.FindElements(By.Id(elementName)).Count > 0)
                        return true;
                    
                 }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
                return false;
            }
            return false; 
        }

        public static bool elementVisibleByID(string strID)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            if (driver.FindElements(By.Id(strID)).Count > 0)
            {
                WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(strID)));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool elementExist(string xpath)
        {

            if (driver.FindElements(By.XPath(xpath)).Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }        

        public static void Sync()
        {
            if (driver.FindElements(By.XPath("//p[contains(text(),'Loading')]")).Count > 0)
            {
                WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(90));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//p[contains(text(),'Loading')]")));
            }
        }

    }
}
