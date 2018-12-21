using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DocWorksQA.DockworksApi
{
    public class WSAPIClient
    {
        private string m_user;
        private string m_password;
        private string m_url;
        private string auth_flag;

        public WSAPIClient(string base_url)
        {
            if (!base_url.EndsWith("/"))
            {
                base_url += "/";
            }

            this.m_url = base_url;
        }

        /**
		 * Get/Set Authorization Indicator
		 *
		 * Returns/sets the authorization indicator for API requests.
		 */
        public string AuthorizationIndicator
        {
            get { return this.auth_flag; }
            set { this.auth_flag = value; }
        }

        /**
		 * Get/Set User
		 *
		 * Returns/sets the user used for authenticating the API requests.
		 */
        public string User
        {
            get { return this.m_user; }
            set { this.m_user = value; }
        }

        /**
		 * Get/Set Password
		 *
		 * Returns/sets the password used for authenticating the API requests.
		 */
        public string Password
        {
            get { return this.m_password; }
            set { this.m_password = value; }
        }

        /**
		 * Send Get
		 *
		 * Issues a GET request (read) against the API and returns the result
		 * (as JSON object, i.e. JObject or JArray instance).
		 *
		 * Arguments:
		 *
		 * uri                  The API method to call including parameters
		 *                      (e.g. get_case/1)
		 */
        public object SendGet(string uri, string token)
        {
            return SendRequest("GET", uri, null, token);
        }

        /**
		 * Send POST
		 *
		 * Issues a POST request (write) against the API and returns the result
		 * (as JSON object, i.e. JObject or JArray instance).
		 *
		 * Arguments:
		 *
		 * uri                  The API method to call including parameters
		 *                      (e.g. add_case/1)
		 * data                 The data to submit as part of the request (as
		 *                      serializable object, e.g. a dictionary)
		 */
        public object SendPost(string uri, object data, String token)
        {
            return SendRequest("POST", uri, data, token);
        }



        private object SendRequest(string method, string uri, object data, String token)
        {
            string url = this.m_url + uri;

            // Create the request object and set the required HTTP method
            // (GET/POST) and headers (content type and basic auth).
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = method;

            request = SetAuthToken(request, token);

            if (method == "POST")
            {
                // Add the POST arguments, if any. We just serialize the passed
                // data object (i.e. a dictionary) and then add it to the request
                // body.
                if (data != null)
                {
                    byte[] block = Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(data)
                    );

                    request.GetRequestStream().Write(block, 0, block.Length);
                }
            }

            // Execute the actual web request (GET or POST) and record any
            // occurred errors.
            Exception ex = null;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw;
                }

                response = (HttpWebResponse)e.Response;
                ex = e;
            }

            // Read the response body, if any, and deserialize it from JSON.
            string text = "";
            if (response != null)
            {
                var reader = new StreamReader(
                    response.GetResponseStream(),
                    Encoding.UTF8
                );

                using (reader)
                {
                    text = reader.ReadToEnd();
                }
            }

            JContainer result;
            if (text != "")
            {
                if (text.StartsWith("["))
                {
                    result = JArray.Parse(text);
                }
                else
                {
                    result = JObject.Parse(text);
                }
            }
            else
            {
                result = new JObject();
            }

            // Check for any occurred errors and add additional details to
            // the exception message, if any (e.g. the error message returned
            // by TestRail).
            if (ex != null)
            {
                Console.WriteLine(result);
                string error = (string)result["error"];
                if (error != null)
                {
                    error = '"' + error + '"';
                }
                else
                {
                    error = "No additional error message received";
                }

                throw new WSAPIException(
                    String.Format(
                        "TestRail API returned HTTP {0} ({1})",
                        (int)response.StatusCode,
                        error
                    )
                );
            }

            return result;
        }

        private HttpWebRequest SetContentType(HttpWebRequest request, String contentType)
        {
            request.ContentType = contentType;


            return request;
        }


        private HttpWebRequest SetAuthToken(HttpWebRequest request, String token)
        {
            request.Headers.Add("Authorization", "Bearer " + token);
            return request;
        }



        public string Login()
        {

            string postData = "grant_type=password";
            postData += ("&username=services@unitydevlab.local");
            postData += ("&password=p@ssw04d");
            postData += ("&client_id=CMSApiClient");


            WebRequest request = WebRequest.Create(m_url + "/connect/token");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.


            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            string accessToken = JObject.Parse(responseFromServer).GetValue("access_token").ToString();
            Console.WriteLine(accessToken);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return accessToken;

        }


    }
}