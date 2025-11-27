using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
    public class AuthenticationTests : TestsBase
    {
        public AuthenticationTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET CredentialHandler.cs
        // Use CredentialHandler for basic authentication
        // Learn more: https://docs.aspose.com/html/net/message-handlers/authentication/

        // This message handler used basic autentifications request
        public class CredentialHandler : MessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                context.Request.Credentials = new NetworkCredential("username", "securelystoredpassword");
                context.Request.PreAuthenticate = true;

                Next(context);
            }
        }
        // @END_SNIPPET

       /*
        [Fact(DisplayName = "Adding the CredentialHandler to the Pipeline")]
        public void AddCredentialHandlerToPipelineTest()
        {
            // @START_SNIPPET AddCredentialHandlerToPipeline.cs
            // Authenticate and load protected HTML with custom configuration using C#
            // Learn more: https://docs.aspose.com/html/net/message-handlers/authentication/

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Add the CredentialHandler to the chain of existing message handlers
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
            handlers.Insert(0, new CredentialHandler());

            // Initialize an HTML document with specified configuration
            using HTMLDocument document = new HTMLDocument("https://httpbin.org/basic-auth/username/securelystoredpassword", configuration);
            // @END_SNIPPET
        }*/
    }
}

