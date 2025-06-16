using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace TestAutomation.Utilities
{
    public class BaseTest
    {
        protected static ExtentReports extent = ExtentReportManager.GetInstance();

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            extent.Flush();

            try
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "ExtentReport.html");

                if (File.Exists(reportPath))
                {
                    Process.Start("xdg-open", reportPath);
                }
                else
                {
                    Console.WriteLine("Extent report not found at: " + reportPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening extent report: " + ex.Message);
            }
        }
    }
}
