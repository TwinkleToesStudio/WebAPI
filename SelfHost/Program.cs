using System;
using System.Net;

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
            httpListener.Prefixes.Add("http://localhost:8081/");
            httpListener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request.
            while (isClosed != true)
            {
                HttpListenerContext context = httpListener.GetContext();
                HttpListenerRequest request = context.Request;
                if(request.RawUrl == V)
                {
                    isClosed = true;
                }
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                //Run Test command
                tmp = c.returnGameList();
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
    }
}