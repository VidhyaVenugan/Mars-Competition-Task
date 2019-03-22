﻿using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Profile link
        [FindsBy(How = How.LinkText, Using = "Profile")]
        private IWebElement ProfileLink { get; set; }

        //Click on profile name drop down
        [FindsBy(How = How.XPath, Using = "//i[1][@class='dropdown icon']")]
        private IWebElement profileNameDropDown { get; set; }

        //Enter the First name
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement firstName { get; set; }

        //Enter the Last name
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement lastName { get; set; }

        //Click on save
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save')]")]
        private IWebElement saveName { get; set; }

        //Check for Profile Name
        [FindsBy(How = How.XPath, Using = "//div[@class='title active']")]
        private IWebElement profileName { get; set; }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement workSamples { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Manage Listings 
        [FindsBy(How = How.XPath, Using = "//div[@id = 'listing-management-section']/div[2]")]
        private IWebElement skillPresent { get; set; }

        internal void EditProfileName()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);

            //**********************************

            //Click on ProfileLink
            ProfileLink.Click();
            Thread.Sleep(1000);

            //*********************************

            //Click on profile drop down

            profileNameDropDown.Click();
            Thread.Sleep(1000);

            //**********************************

            //Enter the First Name and Last Name and click save
            firstName.Clear();
            Thread.Sleep(500);
            firstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));
            Thread.Sleep(500);
            lastName.Clear();
            Thread.Sleep(500);
            lastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));
            Thread.Sleep(500);
            saveName.Click();
            Thread.Sleep(2000);
            var modifiedName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='title']")).Text;
            Console.WriteLine("Changed Profile Name is : " + modifiedName);
            if (modifiedName.Equals(ExcelLib.ReadData(2, "NewProfileName")))
            {
                Base.test.Log(LogStatus.Pass, "Profile Name has been changed successfully");
            }

        }

        internal void EnterShareSkill()
        {
            //Click on Share Skill button
            Thread.Sleep(1000);
            ShareSkillButton.Click();
            Thread.Sleep(1000);
        }

        internal void EditShareSkill()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Thread.Sleep(1000);

            //**********************************
            //Enter the Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Base.test.Log(LogStatus.Info, "Title has been successfully entered");

            //********************************************
            //Enter the Description
            Thread.Sleep(1000);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.test.Log(LogStatus.Info, "Description has been successfully entered");

            //******************************************
            //Select the Category option
            Thread.Sleep(1500);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(CategoryDropDown).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> ServiceCategory = CategoryDropDown.FindElements(By.TagName("option"));
            int count = ServiceCategory.Count;
            Console.WriteLine("Number of Category : " + count);
            for (int i = 0; i < count; i++)
            {
                if (ServiceCategory[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    ServiceCategory[i].Click();
                    Base.test.Log(LogStatus.Info, "Category has been successfully selected");
                    break;
                }
            }

            //****************************************
            //Select the subcategory
            Thread.Sleep(2000);
            action.MoveToElement(SubCategoryDropDown).Build().Perform();
            Thread.Sleep(1500);
            IList<IWebElement> SubCategory = SubCategoryDropDown.FindElements(By.TagName("option"));
            int subcategorycount = SubCategory.Count;
            Console.WriteLine("Number of Sub Category : " + subcategorycount);
            for (int i = 0; i < subcategorycount; i++)
            {
                if (SubCategory[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"))
                {
                    SubCategory[i].Click();
                    Base.test.Log(LogStatus.Info, "Sub Category has been successfully selected");
                    break;
                }
            }

            //**************************************
            //Enter Tag name
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Base.test.Log(LogStatus.Pass, "Tag name has been succesfully enetered");

            //************************************
            //Service Type Option
            Thread.Sleep(2000);
            action.MoveToElement(ServiceTypeOptions).Build().Perform();
            Thread.Sleep(3000);
            // Storing all the elements under category of 'Service Type' in the list of WebLements
            IList<IWebElement> ServiceType = ServiceTypeOptions.FindElements(By.XPath("//div/input[@name='serviceType']"));
            //Indicating the number of buttons present
            int servicetypecount = ServiceType.Count;
            Console.WriteLine("Number of Service type : " + servicetypecount);
            for (int i = 0; i < servicetypecount; i++)
            {
                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = ServiceType.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[" + j + "]/div/label")).Text;
                //Checking if Name equals the "name" attribute - "ServiceType"
                if (Name.Equals(ExcelLib.ReadData(2, "ServiceType")) && Value.Equals("" + i))
                {
                    ServiceType.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Service Type - Hourly Basis has been succesfully selected");
                    break;
                }
                else if (Name.Equals(ExcelLib.ReadData(2, "ServiceType")))
                    {
                    ServiceType.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Service Type - One off Service has been succesfully selected");
                    break;
                }
                else
                    Base.test.Log(LogStatus.Fail, "Service Type provided is not available");

            }

            //*****************************************
            //Location Type Option
            Thread.Sleep(2000);
            action.MoveToElement(LocationTypeOption).Build().Perform();
            Thread.Sleep(3000);
            // Storing all the elements under category of 'Location Type' in the list of WebLements
            IList<IWebElement> LocationType = LocationTypeOption.FindElements(By.XPath("//div/input[@name='locationType']"));
            //Indicating the number of buttons present
            int locationtypecount = LocationType.Count;
            Console.WriteLine("Number of Location type : " + locationtypecount);
            for (int i = 0; i < locationtypecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = LocationType.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "LocationType"
                if (Name.Equals(ExcelLib.ReadData(2, "LocationType")) && Value.Equals("" + i))
                {
                    LocationType.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Location Type On-site has been succesfully selected");
                    break;
                }
                else if (Name.Equals(ExcelLib.ReadData(2, "LocationType")) && Value.Equals("" + i))
                {
                    LocationType.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Location Type Online has been succesfully selected");
                    break;
                }
                else
                    Base.test.Log(LogStatus.Fail, "Location Type provided is not available");
            }

            //******************************************
            //Entering start date
            Thread.Sleep(1000);
            StartDateDropDown.SendKeys(Keys.Delete);
            Thread.Sleep(2000);
            Console.WriteLine("Start date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            //1st Method using DateTime Class
            //====================================
            var dateTime = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
            Console.WriteLine("Date is : " + dateTime);
            /*DateTime parsedDate = DateTime.Parse(dateTime);
            Console.WriteLine("Parsed Date is : " + parsedDate);
            //var dateTimeNow = DateTime.Now; Return 00/00/0000 00:00:00
            //Console.WriteLine("Date Time Now : " + dateTimeNow);
            //var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
            //Console.WriteLine("Date only string is : " + dateOnlyString);
            var dateOnlyString = parsedDate.ToShortDateString(); //To convert string to DateTime format Return 00/00/0000 00:00:00
            Console.WriteLine("Date only string is : " + dateOnlyString);
            StartDateDropDown.SendKeys(dateOnlyString);*/

            //2nd Method using string split
            //==============================
            string[] splitDate = dateTime.Split(' ');
            int countSplitDate = splitDate.Count();
            Console.WriteLine("The count of date string is : " + countSplitDate);
            Console.WriteLine($"String 1 is : {splitDate[0]} ");
            Console.WriteLine($"String 2 is : {splitDate[1]} ");
            Console.WriteLine($"String 3 is : {splitDate[2]} ");
            StartDateDropDown.SendKeys(splitDate[0]);

            Thread.Sleep(2000);
            StartDateDropDown.SendKeys(Keys.Tab);
            Base.test.Log(LogStatus.Pass, "Start Date has succesfully been edited");

            //******************************************
            //Entering End date
            Thread.Sleep(1000);
            //Console.Out.Write("End Date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            Console.WriteLine("End Date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            var endDate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            DateTime parsedEndDate = DateTime.Parse(endDate);
            var endDateonly = parsedEndDate.ToShortDateString();
            EndDateDropDown.SendKeys(endDateonly);
            Thread.Sleep(500);
            EndDateDropDown.SendKeys(Keys.Tab);
            Base.test.Log(LogStatus.Pass, "End Date has succesfully been edited");

            //***************************************
            //Selecting the day
            Thread.Sleep(1000);
            action.MoveToElement(Days).Build().Perform();
            Thread.Sleep(2000);
            IList<IWebElement> allDays = Days.FindElements(By.XPath("//div/div/div/input[@name = 'Available']"));
            int allDaysCount = allDays.Count;
            Console.WriteLine("Number of Days : " + allDaysCount);
            for (int i = 0; i < allDaysCount; i++)
            {

                int j = i + 2;
                var day = GlobalDefinitions.driver.FindElement(By.XPath("//div[" + j + "]/div[1]/div[1]/label")).Text;

                if (day.Equals(ExcelLib.ReadData(2, "Selectday")))
                {
                    allDays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Day has been succesfully selected");
                    break;
                }

            }

            //*****************************************
            //Entering the starttime 
            Thread.Sleep(1000);
            Console.WriteLine("Start time read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            var startTime = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
            DateTime parsedStartTime = DateTime.Parse(startTime);
            var startTimeString = parsedStartTime.ToString("hh:mmtt");
            //var startTimeString = parsedStartTime.ToShortTimeString();
            Console.WriteLine("Start Time String is : " + startTimeString);
            Thread.Sleep(500);
            StartTimeDropDown.SendKeys(startTimeString);
            StartTimeDropDown.SendKeys(Keys.Tab);
            //*****************************************
            //Entering the endtime
            Thread.Sleep(1000);
            GlobalDefinitions.wait(5);
            Console.WriteLine("End time read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            var endTime = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            DateTime parsedEndTime = DateTime.Parse(endTime);
            var endTimeString = parsedEndTime.ToString("hh:mmtt");
            Console.WriteLine("End Time String is : " + endTimeString);
            Thread.Sleep(1000);
            EndTimeDropDown.SendKeys(endTimeString);

            //******************************************
            //Skill Trade Option
            Thread.Sleep(2000);
            action.MoveToElement(SkillTradeOption).Build().Perform();
            Thread.Sleep(3000);

            // Storing all the elements under category of 'Skill Trade' in the list of WebLements
            IList<IWebElement> SkillTrade = SkillTradeOption.FindElements(By.XPath("//div/input[@name='skillTrades']"));

            //Indicating the number of buttons present
            int skilltradecount = SkillTrade.Count;
            Console.WriteLine("Number of Skill Trade : " + skilltradecount);

            for (int i = 0; i < skilltradecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = SkillTrade.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div[1]/div[" + j + "]/div/label")).Text;
                               
                if (Name.Equals(ExcelLib.ReadData(2, "SkillTrade")))
                {
                    SkillTrade.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Skill Trade - Skill Exchange has been succesfully selected");
                    //****************************************
                    //Enter Skill-Exchange Tag name
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Base.test.Log(LogStatus.Pass, "Skill-Exchange Tag name has been succesfully enetered");

                    //**************************************
                    break;
                }
                else if (Name.Equals(ExcelLib.ReadData(2, "SkillTrade")))
                {
                    SkillTrade.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Skill Trade - Credit has been succesfully selected");
                    //****************************************
                    //Enter Credit Amount
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
                    Base.test.Log(LogStatus.Pass, "Credit amount has been succesfully enetered");

                    //**************************************
                    break;
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Skill Trade mentioned is not valid");
                }
            }
            
            //Work Samples

            //Thread.Sleep(1000);
            //workSamples.Click();
            //AutoItX3 fileUpload = new AutoItX3();
            //fileUpload.WinActivate("Open");
            //fileUpload.Send(@"C:\Users\Vidhya\Desktop\" + GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample"));
            //Thread.Sleep(4000);
            //fileUpload.Send("{ENTER}");
            //Thread.Sleep(5000);
            //Base.test.Log(LogStatus.Pass, "File has been uploaded successfully");


            //**********************************************

            //Active Option
            Thread.Sleep(2000);
            action.MoveToElement(ActiveOption).Build().Perform();
            Thread.Sleep(3000);

            // Storing all the elements under category of 'Active' in the list of WebLements
            IList<IWebElement> Active = ActiveOption.FindElements(By.XPath("//div/input[@name='isActive']"));

            //Indicating the number of buttons present
            int activecount = Active.Count;
            Console.WriteLine("Number of Active : " + activecount);

            for (int i = 0; i < activecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = Active.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "Active Option"
                if (Name.Equals(ExcelLib.ReadData(2, "Active")))// && Value.Equals("" + i))
                {
                    Active.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Services option - Active has been succesfully selected");
                    break;
                }
                else if (Name.Equals(ExcelLib.ReadData(2, "Active")))// && Value.Equals("" + i))
                {
                    Active.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Services option -Hidden has been succesfully selected");
                    break;
                }
                else
                    Base.test.Log(LogStatus.Fail, "Active option provided is not available");
            }
            //************************************

            //Save the page

            Thread.Sleep(1000);
            Save.Click();

            //****************************************

            //Verifying whether the service added is present in the listings

            Thread.Sleep(2000);
            GlobalDefinitions.wait(5000);
            bool serviceFound = false;
            IList<IWebElement> listings = skillPresent.FindElements(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr/td[3]"));
            int listingCount = listings.Count;
            Console.WriteLine("Number of Listings : " + listingCount);
            for (int i = 0; i < listingCount; i++)
            {
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr[" + j + "]/td[3]")).Text;
                Console.WriteLine("Name is : " + Name);
                if (Name.Equals(ExcelLib.ReadData(2, "Title")))
                {
                    serviceFound = true;
                    Base.test.Log(LogStatus.Pass, "Service has been added successfully");
                    break;
                }
                else
                {
                    serviceFound = false;
                    Base.test.Log(LogStatus.Fail, "Service has not been added successfully");
                    break;
                }
            }

        }
    }
}
