using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace TestAutomation.Utilities
{
    public static class ExtentReportManager
    {
        private static ExtentReports extent;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string reportPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Reports", "ExtentReport.html");
                
                // Create Reports folder if not exists
                var reportDir = Path.GetDirectoryName(reportPath);
                if (!Directory.Exists(reportDir))
                {
                    Directory.CreateDirectory(reportDir);
                }

                var spark = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(spark);
            }

            return extent;
        }
    }
}
