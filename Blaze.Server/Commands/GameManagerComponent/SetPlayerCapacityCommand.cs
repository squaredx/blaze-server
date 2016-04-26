using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SetPlayerCapacityCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var playerCapacity = (TdfList)request.Data["PCAP"];

            Log.Info(string.Format("Client {0} setting game player capacity to {1}", gameID.Value, playerCapacity.List[0]));

            GameManager.Games[gameID.Value].Capacity = playerCapacity.List;

            request.Reply();

            GameSettingsChangeNotification.Notify(request.Client);
        }
    }
}
