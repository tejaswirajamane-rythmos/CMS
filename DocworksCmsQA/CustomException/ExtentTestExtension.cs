using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using System;
using System.Text;

namespace DocworksCmsQA.CustomException
{
    public static class ExtentTestExtension
    {
        
        public static ExtentTest CustomeFail(this ExtentTest extentTest, Exception ex)
        {
            return extentTest.CustomeLog(Status.Fail, ex);
        }

        public static ExtentTest CustomeLog(this ExtentTest extentTest, Status status, Exception ex, MediaEntityModelProvider provider = null)
        {
            ExceptionInfo exInfo = new ExceptionInfo(ex);
            extentTest.GetModel().ExceptionInfo = exInfo;
            String t = ex.Message + "\n" + ex.GetType() + "\n"+ex.StackTrace;
            //  StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine(string.Format("Message:{0}", ex.Message));
            //stringBuilder.AppendLine(string.Format("StackTrace:{0}", ex.StackTrace));
            //return extentTest.Log(status, stringBuilder.ToString(), provider);
            return extentTest.Log(status, exInfo.GetType()+"\n"+ex.Message+"\n"+exInfo.Name+"\n"+exInfo.StackTrace, provider);
        }
    }
}
