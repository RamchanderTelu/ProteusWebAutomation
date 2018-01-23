using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects; 
using ProteusWeb.Extensions;
using ProteusWeb.SuppportingUtilites;

namespace ProteusWeb.PageObjects
{
    public class ProteusWebSeatAddPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div[1]/div/form/div[2]/div[1]/div/input")]
        [CacheLookup]
        public IWebElement txtSeatDescription { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div[1]/div/form/div[2]/div[2]/div[1]/div/input")]
        [CacheLookup]
        public IWebElement txtSeatOperationalUnit { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div[1]/div/form/div[2]/div[3]/div[1]/div/input")]
        [CacheLookup]
        public IWebElement txtSeatVendor { get; set; }
              

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div[1]/div/form/div[2]/div[4]/div/input")]
        [CacheLookup]
        public IWebElement txtSeatPartnerID { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div[1]/div/form/div[1]/div[2]/div/button[2]")]
        [CacheLookup]
        public IWebElement btnSeatSave { get; set; }


        public void EnterNewSeatDetailsAndSave()
        {
            txtSeatDescription.enterText("QA Automation Description" + GeneralUtilites.RandomNumber(100,999));
            txtSeatOperationalUnit.enterText("QA Operational Unit 120");
            txtSeatVendor.enterText("AMAZON");
            txtSeatPartnerID.enterText("12345");
            GeneralUtilites.wait(1);
            btnSeatSave.mouseClick();
        } 
    }
}