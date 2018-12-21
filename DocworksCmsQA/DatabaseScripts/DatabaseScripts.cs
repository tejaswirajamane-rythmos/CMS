using DocWorksQA.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.DatabaseScripts
{
    public class DatabaseScripts
    {
        String id;
        MongoClient Client;
        readonly String dbName;
        
        public DatabaseScripts() {

            var conString = ConfigurationHelper.Get<String>("dbconnection") + "&ssl=true";
            dbName = ConfigurationHelper.Get<String>("dbname");
            Client = new MongoClient(new MongoUrl(conString));
                        

        }

        public string GetOneProjectForManual_GitHub()
        {
            string projectName = this.GetOneProjectForManual(2);
            return projectName;
        }

        public string GetOneProjectForManual_GitLab()
        {
            string projectName = this.GetOneProjectForManual(1);
            return projectName;
        }

        public string GetOneProjectForManual_Mercurial()
        {
            string projectName = this.GetOneProjectForManual(3);
            return projectName;
        }

        public string GetOneProjectForManual(int sourceControlProviderType)
        {
            Random random = new Random();
            var DB = Client.GetDatabase(dbName);
            var builder = Builders<BsonDocument>.Filter;

            var projectFilter = builder.Eq("Status", 2) & builder.Eq("TypeOfContent", 3) & builder.Eq("IsDeleted", false) & builder.Eq("SourceControlProviderType", sourceControlProviderType);
            var projectList = DB.GetCollection<BsonDocument>("Project").Find(projectFilter).ToListAsync().Result;

            foreach (var currentProject in projectList)
            {

                if (currentProject.GetValue("ProjectName").ToString().ToLower().Contains("api")) { 
                    var distributionFilter = builder.Eq("Status", 2) & builder.Eq("IsActive", true) & builder.Eq("ProjectId", currentProject.GetValue("_id"));
                    var distributionList = DB.GetCollection<BsonDocument>("Distribution").Find(distributionFilter).ToListAsync().Result;

                    if (distributionList.Count > 0)
                    {
                        var distribution = distributionList[random.Next(distributionList.Count)];

                        var nodeFilter = builder.Eq("IsNodeDeleted", false) & builder.Eq("Status", 2) & builder.Ne("ParentId", BsonNull.Value) & builder.Ne("FileName", BsonNull.Value) & builder.Eq("DistributionId", distribution.GetValue("_id"));
                        var nodeList = DB.GetCollection<BsonDocument>("Node").Find(nodeFilter).ToListAsync().Result;
                        if (nodeList.Count >0) { 
                            var node = nodeList[random.Next(nodeList.Count)];
                            return currentProject.GetValue("ProjectName").ToString();
                        }
                    }
                }
            }

            return null;

        }



        public string GetOneProjectForManualWithoutDistribution(int sourceControlProviderType)
        {
            Random random = new Random();
            var DB = Client.GetDatabase(dbName);
            var builder = Builders<BsonDocument>.Filter;

            var projectFilter = builder.Eq("Status", 2) & builder.Eq("TypeOfContent", 3) & builder.Eq("IsDeleted", false) & builder.Eq("SourceControlProviderType", sourceControlProviderType);
            var projectList = DB.GetCollection<BsonDocument>("Project").Find(projectFilter).ToListAsync().Result;

            foreach (var currentProject in projectList)
            {

                if (currentProject.GetValue("ProjectName").ToString().ToLower().Contains("api"))
                {
                            return currentProject.GetValue("ProjectName").ToString();
                 }
            }

            return null;

        }

        public string GetOneDistributionFromProject(string projectName)
        {
            var projectId = GetProjectId(projectName);
            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Distribution");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Status", 2) & builder.Eq("IsActive", true) & builder.Eq("ProjectId", BsonObjectId.Parse(projectId));

            var list = collection.Find(filter).ToListAsync().Result.FirstOrDefault();
            return list.GetValue("DistributionName").ToString();

        }

        public void FindProjectAndDelete(String projectName) {
            Console.WriteLine("Finding the project to Delete. "+projectName);

            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Project");
            var Filter = new BsonDocument("ProjectName", projectName);
            var list = collection.Find(Filter).ToListAsync().Result.FirstOrDefault();

            Console.WriteLine("Projects Found : "+list);
            id = list.GetValue("_id").ToString();
            collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
            System.Threading.Thread.Sleep(20000);
        
        }

        public void FindDistributionAndDelete(String distributionName)
        {
            Console.WriteLine("Finding the project to Delete. " + distributionName);

            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Distribution");
            var Filter = new BsonDocument("DistributionName", distributionName);
            var list = collection.Find(Filter).ToListAsync().Result.FirstOrDefault();

            Console.WriteLine("Distribution Found : " + list);
            id = list.GetValue("_id").ToString();
            collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
            System.Threading.Thread.Sleep(10000);

        }

        public String GetProjectId(String projectName)
        {
            Console.WriteLine("Finding the project. " + projectName);

            var DB = Client.GetDatabase(dbName);
            var collection = DB.GetCollection<BsonDocument>("Project");
            var Filter = new BsonDocument("ProjectName", projectName);
            var list = collection.Find(Filter).ToListAsync().Result.FirstOrDefault();
            return list.GetValue("_id").ToString();

        }


    }
}
