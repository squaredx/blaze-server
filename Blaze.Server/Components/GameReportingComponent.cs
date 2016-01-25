using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameReportingComponent
    {
        public static void HandleRequest(Client client, Request request)
        {
            switch (request.CommandID)
            {
                case 0x64:
                    SubmitTrustedMidGameReportCommand.HandleRequest(client, request);
                    break;

                case 0x65:
                    SubmitTrustedEndGameReportCommand.HandleRequest(client, request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
