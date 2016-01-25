using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UpdateNetworkInfoCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} updating network info", client.ID));

            var addr = (TdfUnion)request.Data["ADDR"];
            var valu = (TdfStruct)addr.Data.Find(tdf => tdf.Label == "VALU");

            var inip = (TdfStruct)valu.Data.Find(tdf => tdf.Label == "INIP");
            var ip = (TdfInteger)inip.Data.Find(tdf => tdf.Label == "IP");
            var port = (TdfInteger)inip.Data.Find(tdf => tdf.Label == "PORT");

            client.InternalIP = ip.Value;
            client.InternalPort = (ushort)port.Value;

            client.ExternalIP = ip.Value;
            client.ExternalPort = (ushort)port.Value;

            client.Reply(request, 0, null);
        }
    }
}
