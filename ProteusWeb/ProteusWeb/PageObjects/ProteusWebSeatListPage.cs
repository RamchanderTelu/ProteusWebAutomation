using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProteusWeb.Extensions;
using ProteusWeb.SuppportingUtilites;

namespace ProteusWeb.PageObjects
{
    public class ProteusWebSeatListPage
    {
 
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[1]/aside/button[1]")]
        [CacheLookup]
        public IWebElement tabSeats { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/section/div/div[2]/div/div/div/div/div[1]/div[1]/button")]
        [CacheLookup]
        public IWebElement btnAddSeat { get; set; }
        
        public void AddSeat( )
        {
            GeneralUtilites.wait(1);
            tabSeats.mouseClick();
            GeneralUtilites.wait(1);
            btnAddSeat.mouseClick();        
        }
        
    }
    
}
