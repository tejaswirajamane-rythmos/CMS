using OpenQA.Selenium;
using System;

namespace DocworksCmsQA.CustomException
{
    [Serializable]
    public class ExceptionHandler : WebDriverException
    {
        public override string StackTrace { get; }
        public ExceptionHandler(String message) : base(message)
        {
            this.StackTrace = message;
        }

        

    }
}
