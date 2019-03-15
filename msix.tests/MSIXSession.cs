//******************************************************************************
//
// Copyright (c) 2017 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;

namespace MSIXTests
{
    public class MSIXTests
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppId = "18656RidoMin.MSIXCatalog_vzj0fd0atvkjr!App";
        private const string AppIdNightly = "18656RidoMin.MSIXCatalogNightly_0z5p9mqqb1pac!App";
        protected static WindowsDriver<WindowsElement> session;
        protected static WindowsDriver<WindowsElement> DesktopSession;


        public static void Setup(TestContext context)
        {
            // Launch Calculator application if it is not yet launched
            if (session == null)
            {
                // Create a new session to bring up an instance of the Calculator application
                // Note: Multiple calculator windows (instances) share the same process Id
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("deviceName", "WindowsPC");
                DesktopSession = null;
             

                appCapabilities.SetCapability("app", "Root");
                DesktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

                System.Threading.Thread.Sleep(1000);

                Console.WriteLine("LeftClick on Button \"Start\" at (0,79)");
                string xpath_LeftClickButtonStart_0_79 = "/Pane[@Name=\"Desktop 1\"][@ClassName=\"#32769\"]/Pane[@Name=\"Taskbar\"][@ClassName=\"Shell_TrayWnd\"]/Button[@Name=\"Start\"][@ClassName=\"Start\"]";
                var winElem_LeftClickButtonStart_0_79 = DesktopSession.FindElementByXPath(xpath_LeftClickButtonStart_0_79);
                if (winElem_LeftClickButtonStart_0_79 != null)
                {
                    winElem_LeftClickButtonStart_0_79.Click();
                }
                else
                {
                    Console.WriteLine($"Failed to find element using xpath: {xpath_LeftClickButtonStart_0_79}");
                    return;
                }

                System.Threading.Thread.Sleep(10000);

                // LeftClick on Edit "Search box" at (186,26)
                Console.WriteLine("LeftClick on Edit \"Search box\" at (186,26)");
                string xpath_LeftClickEditSearchbox_186_26 = "/Pane[@Name=\"Desktop 1\"][@ClassName=\"#32769\"]/Window[@Name=\"Start\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Window[@Name=\"Cortana\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Edit[@AutomationId=\"SearchTextBox\"][@Name=\"Search box\"]";
                var winElem_LeftClickEditSearchbox_186_26 = DesktopSession.FindElementByXPath(xpath_LeftClickEditSearchbox_186_26);
                if (winElem_LeftClickEditSearchbox_186_26 != null)
                {
                    winElem_LeftClickEditSearchbox_186_26.Click();
                }
                else
                {
                    Console.WriteLine($"Failed to find element using xpath: {xpath_LeftClickEditSearchbox_186_26}");
                    return;
                }

                System.Threading.Thread.Sleep(10000);


                // KeyboardInput VirtualKeys=""msix"" CapsLock=False NumLock=True ScrollLock=False
                Console.WriteLine("KeyboardInput VirtualKeys=\"\"msix\"\" CapsLock=False NumLock=True ScrollLock=False");
                winElem_LeftClickEditSearchbox_186_26.SendKeys("msix catalog");

                System.Threading.Thread.Sleep(10000);

                // LeftClick on ListItem "MSIX Catalog Nightly, Windows app, Press right to switch preview" at (394,22)
                Console.WriteLine("LeftClick on ListItem \"MSIX Catalog Nightly, Windows app, Press right to switch preview\" at (394,22)");
                string xpath_LeftClickListItemMSIXCatalo_394_22 = "/Pane[@Name=\"Desktop 1\"][@ClassName=\"#32769\"]/Window[@Name=\"Cortana\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Pane[@Name=\"Bing\"][@ClassName=\"WebView\"]/Pane[@Name=\"Bing\"]/List[@AutomationId=\"suggestionsList\"][@Name=\"Results\"]/ListItem[starts-with(@AutomationId,\"id_\")][starts-with(@Name,\"MSIX Catalog Nightly, Windows app, Press right to switch preview\")]";
                var winElem_LeftClickListItemMSIXCatalo_394_22 = DesktopSession.FindElementByXPath(xpath_LeftClickListItemMSIXCatalo_394_22);
                if (winElem_LeftClickListItemMSIXCatalo_394_22 != null)
                {
                    winElem_LeftClickListItemMSIXCatalo_394_22.Click();
                }
                else
                {
                    Console.WriteLine($"Failed to find element using xpath: {xpath_LeftClickListItemMSIXCatalo_394_22}");
                    return;
                }

                System.Threading.Thread.Sleep(10000);

                // LeftClick on Text "About" at (120,16)
                Console.WriteLine("LeftClick on Text \"About\" at (120,16)");
                string xpath_LeftClickTextAbout_120_16 = "/Pane[@Name=\"Desktop 1\"][@ClassName=\"#32769\"]/Window[@ClassName=\"Window\"]/List[@AutomationId=\"OptionsListView\"][@Name=\"Option items\"]/ListItem[@Name=\"msix.catalog.app.ViewModels.MenuItem\"][@ClassName=\"ListBoxItem\"]/Text[@Name=\"About\"][@ClassName=\"TextBlock\"]";
                System.Threading.Thread.Sleep(10000);

                var winElem_LeftClickTextAbout_120_16 = DesktopSession.FindElementByXPath(xpath_LeftClickTextAbout_120_16);
                if (winElem_LeftClickTextAbout_120_16 != null)
                {
                    winElem_LeftClickTextAbout_120_16.Click();
                }
                else
                {
                    Console.WriteLine($"Failed to find element using xpath: {xpath_LeftClickTextAbout_120_16}");
                    return;
                }


                System.Threading.Thread.Sleep(10000);



                var MSIXWindow = DesktopSession.FindElementByName("MSIX Catalog - 0.1.1942.0 [Packaged from AppInstaller] [NET FRAMEWORK]");
                var CortanaTopLevelWindowHandle = MSIXWindow.GetAttribute("NativeWindowHandle");
                CortanaTopLevelWindowHandle = (int.Parse(CortanaTopLevelWindowHandle)).ToString("x"); // Convert to Hex
                // DesktopSession.Keyboard.SendKeys(Keys.Alt + Keys.Tab + Keys.Alt + Keys.Tab);
                appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("appTopLevelWindow", CortanaTopLevelWindowHandle);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
            }
        }

        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.FindElementByAccessibilityId("PART_Close").Click();
            
                session.Quit();
                session = null;

            }
        }
        public static WindowsElement FindElementByXPath(string xPath)
        {
            WindowsElement uiTarget = null;
            int nTryCount = 10;

            while (nTryCount-- > 0)
            {
                try
                {
                    uiTarget = DesktopSession.FindElementByXPath(xPath);
                }
                catch
                {
                }

                if (uiTarget != null)
                {
                    System.Threading.Thread.Sleep(500); // default delay
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }

            return uiTarget;
        }
    }
}

