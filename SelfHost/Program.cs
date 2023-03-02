using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameWiki.Host
{
    //Class handles the basic running and declaration of local server
    //SERVER INFO: localhost:8081
    class Program
    {
        private const string V = @"/close"; //Const for handling quit for debugging
        private HttpListener httpListener = null; //HttpListener to watch for http connections to client

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Server();
        }

        public void Server()
        {
            var isClosed = false;
            string tmp = "null";
            CoreCommand c = new CoreCommand();

            this.httpListener = new HttpListener();
            System.IO.Stream output = null;

            if (httpListener.IsListening)
                throw new InvalidOperationException("Server is currently running.");
            httpListener.Prefixes.Clear();
            httpListener.Prefixes.Add("http://localhost:8081/api/");
            httpListener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request.
            while (isClosed != true)
            {
                JObject foo = null;
                tmp = "null";
                HttpListenerContext context = httpListener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                if (request.HasEntityBody)
                {
                    System.IO.Stream body = request.InputStream;
                    System.Text.Encoding encoding = request.ContentEncoding;
                    System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                    string s = reader.ReadToEnd();
                    foo = JObject.Parse(s);
                    Console.WriteLine(foo);
                    body.Close();
                    reader.Close();
                }
                tmp = sendRoute(request.RawUrl, foo);

                // Construct a response.
                string responseString = tmp.ToString();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
            // You must close the output stream.
            output.Close();
            httpListener.Stop();
        }

        public string sendRoute(string url, dynamic json = null)
        {
            CoreCommand c = new CoreCommand();
            string tmp = "err";

            if (url == @"/api/getall")
            {
                tmp = c.returnGameList();
            }

            else if (url.Contains(@"/api/getbyid"))
            {
                string[] getID = url.Split('/');
                string idNum = getID[getID.Length - 1];
                tmp = c.returnGame(Convert.ToInt32(idNum));
            }

            else if (url.Contains(@"/api/update"))
            {
                string[] getID = url.Split('/');
                string idNum = getID[getID.Length - 1];
                string newName = (string)json["GAME_NM"];
                tmp = c.updateGame(Convert.ToInt32(idNum), newName);
            }

            else if (url.Contains(@"/api/delete"))
            {
                string[] getID = url.Split('/');
                string idNum = getID[getID.Length - 1];
                tmp = c.removeGame(Convert.ToInt32(idNum));
            }

            return tmp;
        }
    }
}