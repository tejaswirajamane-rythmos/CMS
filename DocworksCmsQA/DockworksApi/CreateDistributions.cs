using DocWorksQA.DockworksApi;
using System;
using DocWorksQA.Utilities;
using System.Collections.Generic;
using DocWorksQA.CmsApiMethods;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace DocworksCmsQA.DockworksApi
{
   public class CreateDistributionsApi
    {
        WSAPIClient client;
        
       // [Test]
        public void Testing() {
            CreateProjectsApi cp = new CreateProjectsApi();
            String projectName = cp.CreateGitLabProject();
            String projectId = new DatabaseScripts.DatabaseScripts().GetProjectId(projectName);
            Console.WriteLine(projectId);
            Console.WriteLine(CreateGitLabDistribution(projectName));

        }


        public Dictionary<string, string> CreateGitLabDistribution(String projectName)
        {
            String projectId = new DatabaseScripts.DatabaseScripts().GetProjectId(projectName);

            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String distributionName = "API_GitLab_Distribution_"+new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"ProjectId", projectId },
                {"BranchName", "DocworksManual3"},
                {"DistributionName", distributionName},
                {"Description", "API Creation"},
                {"TocPath", "Tocfolder"}
            };


            JObject c = CmsCommonMethods.CreateDistributions(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                Dictionary<string, string> response = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);
                Console.WriteLine(response["status"]);
                response.Add("projectID", projectId);
                response.Add("distributionName", distributionName);

                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> CreateGitHubDistribution(String projectName)
        {
            String projectId = new DatabaseScripts.DatabaseScripts().GetProjectId(projectName);

            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String distributionName = "API_GitHub_Distribution_" + new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"ProjectId", projectId },
                {"BranchName", "DocWorksManual3"},
                {"DistributionName", distributionName},
                {"Description", "API Creation"},
                {"TocPath", "Tocfolder"}
            };


            JObject c = CmsCommonMethods.CreateDistributions(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                Dictionary<string, string> response = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);
                Console.WriteLine(response["status"]);
                response.Add("projectID", projectId);
                response.Add("distributionName", distributionName);

                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> CreateOnoDistribution(String projectName)
        {
            String projectId = new DatabaseScripts.DatabaseScripts().GetProjectId(projectName);

            client = new WSAPIClient(ConfigurationHelper.Get<String>("endpoint"));
            String token = client.Login();

            String distributionName = "API_Ono_Distribution_" + new CommonMethods().GenerateRandomString(5);

            var data = new Dictionary<string, object>
            {
                {"ProjectId", projectId },
                {"BranchName", "DocworksManual3"},
                {"DistributionName", distributionName},
                {"Description", "API Creation"},
                {"TocPath", "Tocfolder"}
            };


            JObject c = CmsCommonMethods.CreateDistributions(client, data, token);

            var responseID = c.GetValue("responseId").ToString();
            Console.WriteLine("Response ID " + responseID);

            try
            {
                Dictionary<string, string> response = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);
                Console.WriteLine(response["status"]);
                response.Add("projectID", projectId);
                response.Add("distributionName", distributionName);

                return response;

            }
            catch (Exception)
            {
                throw;
            }
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

                Dictionary<string, string> response = CmsCommonMethods.GetResponseCompleteExecution(client, responseID, token);

                Console.WriteLine(response["status"]);


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
