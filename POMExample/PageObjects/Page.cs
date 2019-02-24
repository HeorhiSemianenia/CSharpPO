using log4net;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;
using System;

namespace POMExample.PageObjects
{
    public static class Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static ILog GetLog()
        {
            return log;
        }

        private static T GetPage<T>(String waitDuration) where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>("shortWait"); }
        }

        public static DashboardPage Dashboard
        {
            get { return GetPage<DashboardPage>("shortWait"); }
        }

        public static ChatPage Chat
        {
            get { return GetPage<ChatPage>("shortWait"); }
        }

        public static BillingPage Billing
        {
            get { return GetPage<BillingPage>("longWait"); }
        }

        public static NewProjectPage NewProject
        {
            get { return GetPage<NewProjectPage>("middleWait"); }
        }

        public static ProjectManagmentPage ProjectManagment
        {
            get { return GetPage<ProjectManagmentPage>("middleWait"); }
        }
    }
}
