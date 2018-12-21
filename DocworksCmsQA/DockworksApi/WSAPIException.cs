/**
 * TestRail API binding for .NET (API v2, available since TestRail 3.0)
 *
 * Learn more:
 *
 * http://docs.gurock.com/testrail-api2/start
 * http://docs.gurock.com/testrail-api2/accessing
 *
 * Copyright Gurock Software GmbH. See license.md for details.
 */

using System;
using System.Runtime.Serialization;

namespace DocWorksQA.DockworksApi
{
    [Serializable]
    public class WSAPIException : Exception
    {
        public WSAPIException()
        {
        }

        public WSAPIException(string message) : base(message)
        {
        }

        public WSAPIException(string message,
            Exception innerException) : base(message, innerException)
        {
        }

        protected WSAPIException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}