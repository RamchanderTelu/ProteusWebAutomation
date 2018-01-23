using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProteusWeb.Extensions;
using ProteusWeb.SuppportingUtilites;

namespace ProteusWeb.PageObjects
{
    public class ProteusWebLoginPage
    {
                                        
        [FindsBy(How = How.Id, Using = "username")]        
        [CacheLookup]
        public IWebElement txtUserName { get; set; }
  
        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        public IWebElement txtPassword { get; set; }

        
        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div/form/div/div[4]/div[2]/div/button")]
        [CacheLookup]
        public IWebElement btnLogIn { get; set; }

        [FindsBy(How = How.Id, Using = "remember_me")]
        [CacheLookup]
        public IWebElement chbxRememberMe { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div/form/div/div[4]/a")]      
        public IWebElement lnkForgottenPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/section/div/div/form/div/div[4]/div[1]/div")]      
        public IWebElement txtInvalidUsernamePassword { get; set; }

        
        public void loginToApplication(string username, string password)
        {
            GeneralUtilites.wait(1);
            //Enter Username in UserName Textbox
            txtUserName.enterText(username);            

            //Enter Password in Password Textbox
            txtPassword.enterText(password);

            if (chbxRememberMe.Selected)
                chbxRememberMe.mouseClick();
            //Click on SignIn Button
            btnLogIn.mouseClick();
        }

        public bool CheckInvalidUsernamePassword()
        {

            //  return ElementExtensions.elementExist(txtInvalidUsernamePassword.GetAttribute("XPath"), "XPath");
            GeneralUtilites.wait(1);
            return txtInvalidUsernamePassword.Displayed;
        }
    }
}
