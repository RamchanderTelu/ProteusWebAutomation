using ProteusWeb.PageObjects;
using ProteusWeb.SuppportingUtilites;
using ProteusWeb.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProteusWeb.Hooks
{
    [Binding]
    public sealed class ProteusWebHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            GeneralUtilites.KillProcesses();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
          BrowserFactory.closeAllDrivers();
        }
    }
}
