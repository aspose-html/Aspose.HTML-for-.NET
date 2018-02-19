using Aspose.Html.Net;
using System.IO;
using System.Net;

namespace Aspose.Html.Examples.CSharp.Document
{
    class LoadHtmlDocWithCredentials
    {
        public static void Run()
        {
            string requestUri = "https://httpbin.org/basic-auth/user/passwd";
            HTMLDocument document = new HTMLDocument();
            try
            {
                var response = document.Context.Network.Send(new RequestMessage(requestUri)
                {
                    Method = HttpMethod.Get,
                    Credentials = new NetworkCredential("user", "passwd"),
                    PreAuthenticate = true
                });

                using (StringReader sr = new StringReader(response.Content.ReadAsString()))
                {
                    System.Console.WriteLine(document.ContentType);
                    System.Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
                        
        }
    }
}
