using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Profile");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();

            }

            [Test]
            public void UserShareSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Skill");

                // Create an class and object to call the method
                ShareSkill obj = new ShareSkill();
                obj.EnterShareSkill();
                obj.EditShareSkill();

            }
            [Test]
            public void UserManageListings()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Manage Listings");

                // Create an class and object to call the method
                ManageListings obj = new ManageListings();
                obj.Listings();

            }
        }
    }
}