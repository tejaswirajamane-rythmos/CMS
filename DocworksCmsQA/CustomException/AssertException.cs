using System;

namespace DocworksCmsQA.CustomException
{
    [Serializable]
    public class AssertException : Exception
    {
        public override string StackTrace { get; }
        public  AssertException(String message) : base(message)
        {
            this.StackTrace = message;
        }

        public AssertException(Exception e) :base(e.Message){
            this.StackTrace = e.Message+"\n"+e.Source+"\n"+e.StackTrace;
        }


       

    }
}
