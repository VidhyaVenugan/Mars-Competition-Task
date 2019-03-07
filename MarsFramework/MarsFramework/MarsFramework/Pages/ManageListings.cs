using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How=How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            Thread.Sleep(1000);

            //Click on Manage Listings
            Thread.Sleep(1000);
            manageListingsLink.Click();
            Thread.Sleep(1000);

            //Click on view the listing
            view.Click();
            Thread.Sleep(500);

            ////Click on edit the listing
            //GlobalDefinitions.driver.Navigate().Back();
            //Thread.Sleep(1000);
            //edit.Click();
            //Thread.Sleep(500);
            //ShareSkill obj = new ShareSkill();
            //obj.EditShareSkill();
            //Thread.Sleep(1000);

            //Click on delete the listing
            Thread.Sleep(2000);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(delete).Build().Perform();
            Thread.Sleep(3000);
            IList<IWebElement> listings = delete.FindElements(By.XPath("//tr/td[8]/i[3]"));
            int listingCount = listings.Count;
            Console.WriteLine("Number of Listings : " + listingCount);
            for (int i = 0; i < listingCount; i++)
            {
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//tr["+ j +"]/td[3]")).Text;
                Console.WriteLine("Name is : " + Name);
                if (Name.Equals(ExcelLib.ReadData(2, "Title")))
                {
                    listings.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Clicking on delete icon has been successfully performed");
                    break;
                }
                
            }

            // To click on yes or no in the alert message for deleting
            Thread.Sleep(2000);
            action.MoveToElement(clickActionsButton).Build().Perform();
            Thread.Sleep(3000);
            IList<IWebElement> clickAction = clickActionsButton.FindElements(By.TagName("button"));
            //Indicating the number of buttons present
            int clickActionCount = clickAction.Count;
            Console.WriteLine("Number of Actions for Deleting : " + clickActionCount);
            for (int i = 1; i <= clickActionCount; i++)
            {
                if (clickAction[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction"))
                {
                    clickAction[i].Click();
                    Base.test.Log(LogStatus.Info, "Action has been performed successfully");
                    Thread.Sleep(500);
                    break;
                }

            }

        }
    }
}
