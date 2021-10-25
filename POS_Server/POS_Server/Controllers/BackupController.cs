using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS_Server.Models.VM;
using System.Security.Claims;
using System.Web;
using System.Data.SqlClient;
using System.IO;

using Newtonsoft.Json.Converters;


namespace POS_Server.Controllers
{
    [RoutePrefix("api/Backup")]
    public class BackupController : ApiController
    {

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string sql = "";
        private string connectionstring = "";
        private string databaseName = "";
        private string backupFilename = "";
        private string restoreFilename = "";
        private void setConn()
        {

            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["incposdbEntities"].ConnectionString;
            if (connectionstring.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(connectionstring);
                connectionstring = efBuilder.ProviderConnectionString;
            }

            var connectionBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionstring);
            
            databaseName = connectionBuilder.InitialCatalog;

            connection = new SqlConnection(connectionstring);
        }
        public string backupDB(string filePath)
        {
            int res = 0;
            setConn();
            connection.Open();

              sql = "BACKUP DATABASE " + databaseName + " TO DISK = '" + filePath + "'";

            command = new SqlCommand(sql, connection);

            res = command.ExecuteNonQuery();
            //providerName="System.Data.SqlClient"

            connection.Close();
            connection.Dispose();
            if (res == -1)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        public string restoreDB(string filePath)
        {
            int res = 0;
            setConn();
            connection.Open();
            sql = "USE master;";

            sql += "ALTER DATABASE " + databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            sql += "RESTORE DATABASE " + databaseName + "  FROM  DISK = '" + filePath + "' WITH REPLACE;";
     
            sql += " ALTER DATABASE " + databaseName + " SET Multi_User ;";

            command = new SqlCommand(sql, connection);
            res = command.ExecuteNonQuery();


            connection.Close();
            connection.Dispose();

            if (res == -1)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        // GET api/<controller> get all Group
        [HttpPost]
        [Route("getbackup")]
        public string getbackup(string token)
        {
            //  public string Get(string token)
            string message = "";
            token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                string path = "";
                string filename = "back" + DateTime.Now.ToFileTime() + ".bak";
              //  string filename = "back.bak";

                path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), filename);
                var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), filename);
                if (files.Length > 0)
                {

                    File.Delete(files[0]);
                }

                message = backupDB(path);


                return TokenManager.GenerateToken(message);
            }


        }
        private string createBackup()
        {
            string message = "";

            string path = "";
          backupFilename = "back" + DateTime.Now.ToFileTime() + ".bak";
            //  string filename = "back.bak";

            path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), backupFilename);
            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), backupFilename);
            if (files.Length > 0)
            {

                File.Delete(files[0]);
            }

            message = backupDB(path);

            return message;
        }

        [HttpPost]
        [Route("getrestore")]
        public string getrestore(string token)
        {
       
            string message = "";
            token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                int logId = 0;
                
                UsersLogsController logcntrlr = new UsersLogsController();
                usersLogs logITEM = new usersLogs();
                BackupModel restoremodel = new BackupModel();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "logId")
                    {
                        logId = int.Parse(c.Value);
                        
                    }
                    if (c.Type == "fileName")
                    {
                        restoreFilename = c.Value;

                    }

                    
                }
                //get log row befor restore operation
                logITEM = logcntrlr.GetByID(logId);


                string path = "";
                try
                {

                    path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), restoreFilename);
                    //  var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), filename);
                    if (File.Exists(path))
                    {
                        message = restoreDB(path);
                        if (message == "1")
                        {

                            logITEM.logId = 0;
                            //save newlog row and return the logId
                            logId = int.Parse(logcntrlr.Save(logITEM));


                        }
                    }
                    else
                    {
                        message = "0";
                    }

                    restoremodel.logId = logId;
                    restoremodel.result = message;
                    //restoremodel.fileName = filename;

                    return TokenManager.GenerateToken(restoremodel);


                }
                catch (Exception ex)
                {

                    restoremodel.logId = logId;
                    restoremodel.result = ex.ToString();
                  //  restoremodel.fileName = filename;
                    return TokenManager.GenerateToken(restoremodel);
                }
            }


        }

      

        [HttpGet]
        [Route("GetFile")]
        public HttpResponseMessage GetFile()
        {
            string message = "";

            string dirpath = System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\");
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            ProcessDirectory(dirpath);

            message = createBackup();

            // send file to client
            if (message == "1")
            {
                if (String.IsNullOrEmpty(backupFilename))
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                string localFilePath;

                localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), backupFilename);

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = backupFilename;

                return response;
             

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public  void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                bool inuse = false;

                inuse = IsFileInUse(fileName);
                if (inuse==false)
                {
                    File.Delete(fileName);
                }

 //ProcessFile(fileName);
            }

           

         
        }

        private bool IsFileInUse(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                //throw new ArgumentException("'path' cannot be null or empty.", "path");
                return true;
            }
                

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

    


        // upload file
        [Route("uploadfile")]
        public IHttpActionResult uploadfile()
        {

            try
            {
                string dirPath = System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    restoreFilename = postedFile.FileName;
                 //   string imageWithNoExt = Path.GetFileNameWithoutExtension(postedFile.FileName);

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                    //    int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".bak", ".inc" };
                        //var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = Path.GetExtension(postedFile.FileName);

                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            
                            var message = "-1";
                            return Ok(message);
                        }
                        var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), restoreFilename);
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            // myfolder name where i want to save my file
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\temp\\"), restoreFilename);
                            postedFile.SaveAs(filePath);

                        // restore to DB

                        //}
                    }


                    // var message1 = string.Format("Image Updated Successfully.");
                    return Ok(string.Format("1"));
                }
   return  Ok(string.Format("1"));
              //  var res = string.Format("Please Upload a image.");

               // return Ok("2");
            }
            catch (Exception ex)
            {
                var res = string.Format("-2");

                return Ok(res);
            }
        }
    }
}