using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProteusWeb.Extensions;
using System.Collections.Generic;
using ProteusWeb.WrapperFactory;
using ProteusWeb.SuppportingUtilites;

namespace ProteusWeb.PageObjects
{
  public  class ProteusWebCampaignsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='3']")]
        [CacheLookup]
        public IWebElement txtCampaigns { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/header/div/div[3]/div/div/div[1]/button")]       
        public IWebElement btnExpand { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[1]/aside/button")]
        [CacheLookup]
        public IWebElement btnFLIGHTS { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/header/div/div[3]/div/div/div[2]/ul/li[2]")]
        public IWebElement btnLogOut { get; set; }        

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/div[2]/div/input")]
        [CacheLookup]
        public IWebElement txtSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/div[1]/div/div/input")]
        [CacheLookup]
        public IWebElement txtSort { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/div[3]/div/div/input")]
        [CacheLookup]
        public IWebElement txtAdvertiser { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/div[4]/div/div/input")]
        [CacheLookup]
        public IWebElement txtAgency { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/button[1]")]    
        public IWebElement btnApplyFilters { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[1]/div/div[2]/button[2]")]
        public IWebElement btnClearFilters { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]")]
        [CacheLookup]
        public IWebElement rowFlights { get; set; }
         

        public bool CheckCampaignsPageLoad()
        {
            return txtCampaigns.Displayed;
        }

        public int GetFligtRowsCount()
        {
           By FlightRow = By.XPath("//*[@id='root']/div/section/div/div[2]/div/div/div/div[2]/div");          
           IList <IWebElement> elementTypes = BrowserFactory.Driver.FindElements(FlightRow);
            Console.WriteLine("Flight Count : " + elementTypes.Count );
           return elementTypes.Count;
        }

      public bool CheckFLIGHTSExist()
        {
            return btnExpand.Displayed;
        }

        public bool CheckLogOutExist()
        {
            btnExpand.mouseClick();
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


        public bool CheckSearchByFlightNameOrBookingCodeExist()
        {
            try
            {
                txtSearch.enterText("FINCEANCE");
                txtSearch.enterText("IO-6466");
                return txtSearch.Displayed;                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
                return false;
            }
        }

        public void EnterSearchFilter(string Sort = "", string Search = "", string Advertiser = "", string Agency = "" )
        {
            if (Sort != "")
                txtSort.enterText(Sort);
            if (Search != "")
                txtSearch.enterText(Search);
            if (Advertiser != "")
                txtAdvertiser.enterText(Advertiser);
            if (Agency != "")
                txtAgency.enterText(Agency);
        }

        public bool CheckFliterExist()
        {
            return txtAdvertiser.Displayed && txtAgency.Displayed;
        }
    }        
}

