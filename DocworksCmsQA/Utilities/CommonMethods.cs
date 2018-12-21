using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using DocWorksQA.Pages;
using DocworksCmsQA.Utilities;

namespace DocWorksQA.Utilities
{
    public class CommonMethods : Verify
    {


        public void CloseDriver(IWebDriver Driver) {
            String driverToUse = ConfigurationHelper.Get<String>("DriverToUse");
            int hash = 0;
            try {
                hash = Driver.GetHashCode();
                if (driverToUse.ToLower().Equals("firefox"))
                {
                    Driver.Navigate().GoToUrl("about:config");
                    //Driver.Close();
                }

                if (Driver != null) {
                    Driver.Navigate().GoToUrl("about:blank");
                    Driver.Quit();
                    Console.WriteLine(driverToUse + " " + Driver.GetHashCode() + " Driver quited successfully.");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("There was error in Quitting the driver. " + hash);
                Console.WriteLine(ex.Message);
            }



        }

        public String TakeScreenshot(IWebDriver driver)
        {

            String path = GetCurrentProjectPath() + "/bin/Release/Reports/Screenshot";

            CreateDirectory(path);

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            TimeAndDate.Replace(" ", "_");

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
           // Screenshot screenshot = ssdriver.GetScreenshot();
           // screenshot.SaveAsFile(path + "/screenshot-" + TimeAndDate + ".jpg", ScreenshotImageFormat.Jpeg);
            return "./Screenshot/screenshot-" + TimeAndDate + ".jpg";

        }


        public void ReportExceptionScreenshot(IWebDriver driver, Exception ex) {
            String path = TakeScreenshot(driver);
            ExceptionScreenshot(path, ex.Message);

        }

        public void ReportExceptionScreenshot(ExtentTest test, IWebDriver driver, Exception ex)
        {
//            String path = TakeScreenshot(driver);
          //  ExceptionScreenshot(test, path, ex.GetType().ToString());

        }

        public void ExceptionScreenshot(String path, String message)
        {
            Info("<a style=\"font - size: 20px; color: red;\" href=\"" + path + "\">Exception Occurred : " + message + "<br></a>");
        }

        public void ExceptionScreenshot(ExtentTest test, String path, String message)
        {
            //test.AddScreenCaptureFromPath(path, message);
            test.Fail("FAILURE : " +message, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
    //        Info(test, "<a style=\"font - size: 20px; color: red;\" href=\"" + path + "\">Screenshot : Exception Occurred - " + message + "<br></a>");
        }

        public string GetImagePath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\Images\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\Images\" + TimeAndDate + ".jpg";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }

        public string GetInvalidImagePath()
        {
            String path = GetCurrentProjectPath();

            String savedpath = path + @"\MediaFiles\Images\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".tif" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\Images\" + TimeAndDate + ".tif";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }



        public string GetCodeBlockPath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\CodeBlocks\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".txt", ".cs" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\CodeBlocks\" + TimeAndDate + ".txt";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }

        public string GetInvalidCodeBlockPath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\CodeBlocks\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".docx", ".xml" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\CodeBlocks\" + TimeAndDate + ".xml";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }

        public void CreateDirectory(String path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateFile(String fileName, Dictionary<string, string> data)
        {
            FileInfo f = new FileInfo(fileName);
            StreamWriter w = f.CreateText();
            foreach (var pair in data)
            {
                string key = pair.Key;
                string value = pair.Value;
                w.WriteLine(key + "=" + value);
            }

            w.Close();
        }

      




        public String RandomValueOfLengthMorethan100()
        {
            char data = ' ';
            String dat = "";
            Random ran = new Random();
            for (int i = 0; i <= 250; i++)
            {
                data = (char)(ran.Next(25) + 97);
                dat = data + dat;
            }
            return dat;

        }


        public String RandomValueOfLengthMorethan1000()
        {

            char data = ' ';
            String dat = "";
            Random ran = new Random();
            for (int i = 0; i <= 1000; i++)
            {
                data = (char)(ran.Next(25) + 97);
                dat = data + dat;
            }

            return dat;
        }



        public String GenerateRandomNumbers(int length)
        {
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
            Random rng = new Random();
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = characters.ElementAt(rng.Next(characters.Length));

            }
            return new String(text);
        }

        public String GenerateNumbers(int length)
        {
            String characters = "0123456789";
            Random rng = new Random();
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = characters.ElementAt(rng.Next(characters.Length));

            }
            return new String(text);
        }

        public String GenerateRandomSpecialCharacters(int length)
        {
            String characters = "!@#$%^&~*()|{}`?";
            Random rng = new Random();
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = characters.ElementAt(rng.Next(characters.Length));

            }
            return new String(text);
        }


        public String GenerateRandomString(int length)
        {
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rng = new Random();
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = characters.ElementAt(rng.Next(characters.Length));

            }
            return new String(text);
        }



        public void UpdateGitLabProjectProperties(String distributionStatus) {

            Properties prop = new Properties(GetCurrentProjectPath() + "//bin/gitLabProject");
            prop.set("distributionStatus", distributionStatus);
            prop.Save();

        }

        public void UpdateGitHubProjectProperties(String distributionStatus)
        {

            Properties prop = new Properties(GetCurrentProjectPath() + "//bin/gitHubProject");
            prop.set("distributionStatus", distributionStatus);
            prop.Save();

        }

        public void UpdateMercurialProjectProperties(String distributionStatus)
        {

            Properties prop = new Properties(GetCurrentProjectPath() + "//bin/onoProject");
            prop.set("distributionStatus", distributionStatus);
            prop.Save();

        }

        public bool FileExists(String filePath) {

            return System.IO.File.Exists(filePath);
        }

        public String CreateDistribution(String projectType, ExtentTest test, IWebDriver driver)
        {
            String projectName = "";

            if (projectType.Equals("GitLab"))
            {
                if (FileExists(GetCurrentProjectPath() + "//bin/gitLabProject.properties"))
                {
                    Properties prop = new Properties(GetCurrentProjectPath() + "//bin/gitLabProject");
                    if (prop.get("distributionStatus").ToLower().Equals("success"))
                    {
                        Console.WriteLine("Using existing GitLab project.");
                        projectName = prop.get("projectName");
                    }
                    else if(prop.get("projectStatus").ToLower().Equals("success"))
                    {
                        CreateDistribution(test, driver, prop.get("projectName"));
                        UpdateGitLabProjectProperties("Success");
                    }
                    else
                    {
                        projectName = CreateGitLabProject(test, driver);
                        CreateDistribution(test, driver, projectName);
                        UpdateGitLabProjectProperties("Success");
                    }
                }
            }else if (projectType.Equals("Mercurial"))
            {
                if (FileExists(GetCurrentProjectPath() + "//bin/onoProject.properties"))
                {
                    Properties prop = new Properties(GetCurrentProjectPath() + "//bin/onoProject");
                    if (prop.get("distributionStatus").ToLower().Equals("success"))
                    {
                        Console.WriteLine("Using existing Mercurial project.");
                        projectName = prop.get("projectName");
                    }
                    else if (prop.get("projectStatus").ToLower().Equals("success"))
                    {
                        CreateMercurialDistribution(test, driver, prop.get("projectName"));
                        UpdateMercurialProjectProperties("Success");
                    }
                    else
                    {
                        projectName = CreateMercurialProject(test, driver);
                        CreateMercurialDistribution(test, driver, projectName);
                        UpdateMercurialProjectProperties("Success");
                    }
                }

            }
            else if (projectType.Equals("GitHub"))
            {
                if (FileExists(GetCurrentProjectPath() + "//bin/GitHubProject.properties"))
                {
                    Properties prop = new Properties(GetCurrentProjectPath() + "//bin/GitHubProject");
                    if (prop.get("distributionStatus").ToLower().Equals("success"))
                    {
                        Console.WriteLine("Using existing GitHub project.");
                        projectName = prop.get("projectName");
                    }
                    else if (prop.get("projectStatus").ToLower().Equals("success"))
                    {
                        CreateDistribution(test, driver, prop.get("projectName"));
                        UpdateGitHubProjectProperties("Success");
                    }
                    else
                    {
                        projectName = CreateGitHubProject(test, driver);
                        CreateDistribution(test, driver, projectName);
                        UpdateGitHubProjectProperties("Success");
                    }
                }

            }

            return projectName;


        }



        public String CreateDistribution(ExtentTest test, IWebDriver driver, String projectName) {
            AddProjectPage project = new AddProjectPage(test, driver);

            project.SearchForProject(projectName);
            CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
            distmodule.ClickDistribution();
            String expected2 = distmodule.EnterDistirbutionName();
            System.Threading.Thread.Sleep(75000);
            distmodule.SelectBranch("DocworksManual2");
            distmodule.EnterDescription("This distribution is created for GitLabWithout TOC Path");
            distmodule.ClickCreateDistribution();
            project.ClickNotifications();
            String status2 = project.GetNotificationStatus();
            SuccessScreenshot(driver, "Distribution: " + expected2 + " got Created successfully Without TOC Path", test);
            VerifyText(test, "creating distribution " + expected2 + " in " + projectName + " is successful", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + "");
            project.ClickDashboard();
            return projectName;

        }

        public String CreateMercurialDistribution(ExtentTest test, IWebDriver driver, String projectName)
        {
            AddProjectPage project = new AddProjectPage(test, driver);

            project.SearchForProject(projectName);
            CreateDistributionPage distribution = new CreateDistributionPage(test, driver);
            distribution.ClickDistribution();
            String expected1 = distribution.EnterDistirbutionName();
            System.Threading.Thread.Sleep(5000);
            distribution.EnterBranchForMercurial("DocworksManual3");
            distribution.EnterTocPath();
            distribution.EnterDescription("This distribution is created for Mercurial Project");
            distribution.ClickCreateDistribution();
            project.ClickNotifications();
            String status1 = project.GetNotificationStatus();
            project.SuccessScreenshot("Distribution got Created successfully With TOC Path");
            VerifyText(test, "creating distribution " + expected1 + " in " + projectName + " is successful", status1, "Distribution is Created For Mercurial TOC with status:" + status1 + "", "Distribution is not created For Mercurial TOC with status: " + status1 + "");
            project.ClickDashboard();
            return projectName;
        }

        public String CreateGitLabProject(ExtentTest test, IWebDriver driver)
        {
            if (FileExists(GetCurrentProjectPath() + "//bin/gitLabProject.properties"))
            {
                Properties prop = new Properties(GetCurrentProjectPath() + "//bin/gitLabProject");
                try { 
                    if (prop.get("projectStatus").ToLower().Equals("success"))
                    {
                        Console.WriteLine("Using existing GitLab project.");
                        return prop.get("projectName");
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    
                }


            }

            AddProjectPage addProject = new AddProjectPage(test, driver);
            addProject.ClickAddProject();
            String projectName = addProject.EnterProjectTitle();
            addProject.SelectContentType("Manual");
            addProject.SelectSourceControlProviderType("GitLab");
            addProject.SelectRepository("Docworks");
            addProject.EnterPublishedPath("Publishing path to create project");
            addProject.EnterDescription("This is to create Project");
            addProject.ClickCreateProject();
            addProject.ClickNotifications();
            String status = GetNotificationStatus(driver);
            addProject.SuccessScreenshot("Project Created Title");
            VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
            addProject.ClickDashboard();
            addProject.SearchForProject(projectName);
            String actual = addProject.GetProjectTitle();
            addProject.SuccessScreenshot("ProjectTitle");
            VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            return projectName;
            
        }

        public String CreateGitHubProject(ExtentTest test, IWebDriver driver)
        {
            if (FileExists(GetCurrentProjectPath() + "//bin/gitHubProject.properties"))
            {
                Properties prop = new Properties(GetCurrentProjectPath() + "//bin/gitHubProject");
                if (prop.get("projectStatus").ToLower().Equals("success"))
                {
                    Console.WriteLine("Using existing GitHub project.");
                    return prop.get("projectName");
                }

            }

            AddProjectPage addProject = new AddProjectPage(test, driver);
            addProject.ClickAddProject();
            String projectName = addProject.EnterProjectTitle();
            addProject.SelectContentType("Manual");
            addProject.SelectSourceControlProviderType("GitHub");
            addProject.SelectRepository("Docworks");
            addProject.EnterPublishedPath("Publishing path to create project");
            addProject.EnterDescription("This is to create Project");
            addProject.ClickCreateProject();
            addProject.ClickNotifications();
            String status = GetNotificationStatus(driver);
            addProject.SuccessScreenshot("Project Created Title");
            VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
            addProject.ClickDashboard();
            addProject.SearchForProject(projectName);
            String actual = addProject.GetProjectTitle();
            addProject.SuccessScreenshot("ProjectTitle");
            VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            return projectName;

        }


        public String CreateMercurialProject(ExtentTest test, IWebDriver driver) {

            if (FileExists(GetCurrentProjectPath() + "//bin/onoProject.properties"))
            {
                Properties prop = new Properties(GetCurrentProjectPath() + "//bin/onoProject");
                try { 
                if (prop.get("projectStatus").ToLower().Equals("success"))
                {
                    Console.WriteLine("Using existing Mercurial project.");
                    return prop.get("projectName");
                }
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            AddProjectPage addProject = new AddProjectPage(test, driver);
            addProject.ClickAddProject();
            String projectName = addProject.EnterProjectTitle();

            addProject.SelectContentType("Manual");
            addProject.SelectSourceControlProviderType("Ono");

            addProject.EnterMercurialRepoPath();
            addProject.EnterPublishedPath("Publishing path to create project");
            addProject.EnterDescription("This is to create Project");
            addProject.ClickCreateProject();

            addProject.ClickNotifications();

            String status = addProject.GetNotificationStatus();
            addProject.SuccessScreenshot("Project Created Title");

            VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");

            addProject.ClickDashboard();

            addProject.SearchForProject(projectName);
            String actual = addProject.GetProjectTitle();
            addProject.SuccessScreenshot("ProjectTitle");
            VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");

          
            return projectName;
        }

        public void WaitForProcessCompletion(IWebDriver driver)
        {
            By NOTIFICATION_MESSAGE = By.XPath("//div[@ngclass='operation-status-wrapper']//small");
            for (int i = 0; i < 300; i++)
            {

                String tmp = driver.FindElement(NOTIFICATION_MESSAGE).Text;

                if (tmp.Contains("successful"))
                {
                    Console.WriteLine(i + " : " + tmp);
                    break;
                }
                else
                {
                    Console.WriteLine(tmp);
                    //Console.WriteLine("Notification is still in progress.");
                    System.Threading.Thread.Sleep(1000);
                }

            }
        }

        public String GetNotificationStatus(IWebDriver driver)
        {
            By NOTIFICATION_MESSAGE = By.XPath("//div[@ngclass='operation-status-wrapper']//small");
            WaitForProcessCompletion(driver);
            return driver.FindElement(NOTIFICATION_MESSAGE).Text;

        }

        public void ClickNotification(IWebDriver driver)
        {
            By NOTIFICATION_BELL = By.XPath("//i[@class='mdi mdi-bell mdi-24px']");
            driver.FindElement(NOTIFICATION_BELL).Click();
        }

        public void SuccessScreenshot(IWebDriver driver, String message, ExtentTest test)
        {
            String path = TakeScreenshot(driver);
            SuccessScreenshot(path, message, test);
        }

        public void SuccessScreenshot(String path, String message, ExtentTest test)
        {
            Info(test, "<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }

        
    }
}
