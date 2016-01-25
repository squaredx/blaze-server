using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UtilComponent
    {
        public static void HandleRequest(Client client, Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    FetchClientConfigCommand.HandleRequest(client, request);
                    break;

                case 2:
                    PingCommand.HandleRequest(client, request);
                    break;

                case 5:
                    GetTelemetryServerCommand.HandleRequest(client, request);
                    break;

                case 7:
                    PreAuthCommand.HandleRequest(client, request);
                    break;

                case 8:
                    PostAuthCommand.HandleRequest(client, request);
                    break;

                case 0xB:
                    UserSettingsSaveCommand.HandleRequest(client, request);
                    break;

                case 0xC:
                    UserSettingsLoadAllCommand.HandleRequest(client, request);
                    break;

                case 0x16:
                    SetClientMetricsCommand.HandleRequest(client, request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
