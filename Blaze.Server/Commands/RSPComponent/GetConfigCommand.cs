using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GetConfigCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} requested RSP configuration", client.ID));

            foreach (var tdf in request.Data)
            {
                Log.Info(tdf.Key + "(" + tdf.Value.Type + ")");
            }

            client.Reply(request, 0, null);
        }
    }
}
