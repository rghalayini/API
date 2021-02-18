using System;
using System.IO;
using System.Net;

using System.Linq;
using System.Text;
using Newtonsoft.Json;



namespace _9ConsoleApp
{
    class Program
    {
        //to do a get request
        //public static void Main()
        //{
        //    // Create a request for the URL.
        //    WebRequest request = WebRequest.Create(
        //      "http://localhost:57676/api/Speakers/");
        //    // If required by the server, set the credentials.
        //    request.Credentials = CredentialCache.DefaultCredentials;

        //    // Get the response.
        //    WebResponse response = request.GetResponse();
        //    // Display the status.
        //    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

        //    // Get the stream containing content returned by the server.
        //    // The using block ensures the stream is automatically closed.
        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        // Open the stream using a StreamReader for easy access.
        //        StreamReader reader = new StreamReader(dataStream);
        //        // Read the content.
        //        string responseFromServer = reader.ReadToEnd();
        //        // Display the content.
        //        Console.WriteLine(responseFromServer);
        //    }

        //    // Close the response.
        //    response.Close();
        //}

        //to do a post, activate below and comment out the above Main method

        static void Main(string[] args)
        {

            PostJson("http://localhost:57676/api/Speakers", new Speaker
            {
                name = "Will Smith",
                Bio = "likes to drive cars",
                webSite = "www.smith.com"
            });
        }


        private static void PostJson(string uri, Speaker postParameters)
        {
            string postData = JsonConvert.SerializeObject(postParameters);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Console.WriteLine(httpWebResponse);
        }
    }
    public class Speaker
    {
        public string name { get; set; }
        public string Bio { get; set; }
        public string webSite { get; set; }
    }

}

