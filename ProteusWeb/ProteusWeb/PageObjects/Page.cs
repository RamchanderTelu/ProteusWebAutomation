using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProteusWeb.WrapperFactory;

namespace ProteusWeb.PageObjects
{ 
    public static class Page
    {
        private static T getPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static ProteusWebLoginPage ProteusWebLogin
        {
            get { return getPage<ProteusWebLoginPage>(); }
        }

        public static ProteusWebSeatListPage ProteusWebSeatList
        {
            get { return getPage<ProteusWebSeatListPage>(); }
        }

        public static ProteusWebHomePage ProteusWebHome
        {
            get { return getPage<ProteusWebHomePage>(); }
        }

        public static ProteusWebAdvertisersPage ProteusWebAdvertisers
        {
            get { return getPage<ProteusWebAdvertisersPage>(); }
        }       
        
        public static ProteusWebSeatAddPage ProteusWebSeatAdd
        {
            get { return getPage<ProteusWebSeatAddPage>(); }
        }

        public static ProteusWebCampaignsPage ProteusWebCampaigns 
        {
            get { return getPage<ProteusWebCampaignsPage>(); }
        }
        
    }
}
