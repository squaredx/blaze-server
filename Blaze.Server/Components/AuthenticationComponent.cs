using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class AuthenticationComponent
    {
        public static void HandleRequest(Client client, Request request)
        {
            switch (request.CommandID)
            {
                case 0x28:
                    LoginCommand.HandleRequest(client, request);
                    break;

                case 0x32:
                    SilentLoginCommand.HandleRequest(client, request);
                    break;

                case 0x6E:
                    LoginPersonaCommand.HandleRequest(client, request);
                    break;

                case 0x1D:
                    ListUserEntitlements2Command.HandleRequest(client, request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
