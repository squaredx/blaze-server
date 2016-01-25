using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SetGameSettingsCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var gameSettings = (TdfInteger)request.Data["GSET"];

            Log.Info(string.Format("Client {0} setting game settings to {1}", gameID.Value, gameSettings.Value));

            GameManager.Games[gameID.Value].Settings = gameSettings.Value;

            client.Reply(request, 0, null);

            GameSettingsChangeNotification.Notify(client);
        }
    }
}
