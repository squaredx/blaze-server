using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UpdateGameNameCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var gameName = (TdfString)request.Data["GNAM"];

            Log.Info(string.Format("Client {0} changing game {1} game name to \"{2}\"", request.Client.ID, gameID.Value, gameName.Value));

            GameManager.Games[gameID.Value].Name = gameName.Value;

            request.Reply();
        }
    }
}
