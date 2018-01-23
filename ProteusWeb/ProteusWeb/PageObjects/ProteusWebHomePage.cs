using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProteusWeb.Extensions;
using ProteusWeb.WrapperFactory;
using ProteusWeb.SuppportingUtilites; 

namespace ProteusWeb.PageObjects
{
    public class ProteusWebHomePage
    {   
        [FindsBy(How = How.Id, Using = "administration")]
        [CacheLookup]
        public IWebElement tabAdministration { get; set; }

        [FindsBy(How = How.Id, Using = "campaigns")]
        [CacheLookup]
        public IWebElement tabCampaign { get; set; }
              

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/header/div/div[2]/img")]
        [CacheLookup]
        public IWebElement imgHomeProtues { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/header/div/div[3]/div/div/div[1]/button")]      
        public IWebElement btnExpand { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/header/div/div[3]/div/div/div[2]/ul/li[2]")]       
        public IWebElement btnLogOut { get; set; }


        public void NavigateProteusAdministration()
        {
            GeneralUtilites.wait(1);
            tabAdministration.mouseClick();
        }

        public void NavigateProteusCampaign()
        {
            GeneralUtilites.wait(1);
            tabCampaign.mouseClick();
        }

        public bool CheckCampaignTabExist()
        {
            return tabCampaign.Displayed;
        }

        public bool CheckHomePage()
        {
            return imgHomeProtues.Displayed;
        }

        public bool CheckLogOutExist()
        {
            GeneralUtilites.wait(0.5);
            btnExpand.mouseClick();
            GeneralUtilites.wait(0.5);
            bool boolLogOut = btnLogOut.Displayed;
            btnExpand.mouseClick();
            return boolLogOut;
        }

        public void Logout()
        {
            btnExpand.mouseClick();
            GeneralUtilites.wait(0.5);
            btnLogOut.mouseClick();
        }
    }
}
 