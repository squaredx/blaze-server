using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SubmitTrustedEndGameReportCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} submitting trusted end-game report", client.ID));

            client.Reply(request, 0, null);
        }
    }
}
