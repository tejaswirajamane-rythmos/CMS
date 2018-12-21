using DocWorksQA.DockworksApi;
using System;
using DocWorksQA.Utilities;
using System.Collections.Generic;
using DocWorksQA.CmsApiMethods;
using Newtonsoft.Json.Linq;

namespace DocworksCmsQA.DockworksApi
{
   public class CreateProjectsApi
    {
        WSAPIClient client;
        

        public String CreateGitLabProject()
        {
            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String projectName = "API_GitLab_"+new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"projectName", projectName },
                {"RepositoryId", "6090611"},
                {"RepositoryName", "Docworks"},
                {"typeOfContent", 3},
                {"Description", "Project Description"},
                {"PublishedPath", "This is awesome"},
                {"SourceControlProviderType", "1"}
            };


            JObject c = CmsCommonMethods.CreateProject(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                String responseStatus = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token)["status"];

                Console.WriteLine(responseStatus);
             

            }
            catch (Exception)
            {
                throw;
            }
            return projectName;
        }


        public String CreateGitHubProject()
        {
            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String projectName = "API_GitHub_" + new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"projectName", projectName },
                {"RepositoryId", "118083636"},
                {"RepositoryName", "Docworks"},
                {"typeOfContent", 3},
                {"Description", "Project Description"},
                {"PublishedPath", "This is awesome"},
                {"SourceControlProviderType", "2"}
            };


            JObject c = CmsCommonMethods.CreateProject(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                String responseStatus = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token)["status"];
                Console.WriteLine(responseStatus);


            }
            catch (Exception)
            {
                throw;
            }
            return projectName;
        }

        public String CreateMercurialProject()
        {
            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String projectName = "API_Ono_" + new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"projectName", projectName },
                {"RepositoryName", "Docworks"},
                {"typeOfContent", 3},
                {"Description", "Project Description"},
                {"PublishedPath", "This is awesome"},
                {"SourceControlProviderType", "3"},
                {"MercurialRepositoryUrl", "https://bitbucket.org/mohittonde/docworks"}

            };


            JObject c = CmsCommonMethods.CreateProject(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                Dictionary<string, string> response = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);
                Console.WriteLine(response["status"]);


            }
            catch (Exception)
            {
                throw;
            }
            return projectName;
        }

    }
}
