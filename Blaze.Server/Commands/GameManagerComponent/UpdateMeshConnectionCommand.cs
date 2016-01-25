using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UpdateMeshConnectionCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} updating mesh connection", client.ID));

            var gameID = (TdfInteger)request.Data["GID"];

            var targ = (TdfList)request.Data["TARG"];
            var targData = (List<Tdf>)targ.List[0];
            var personaID = (TdfInteger)targData[1];
            var stat = (TdfInteger)targData[2];

            client.Reply(request, 0, null);

            if (stat.Value == 2)
            {
                if (client.Type == ClientType.GameplayUser)
                {
                    GamePlayerStateChangeNotification.Notify(client, gameID.Value, client.User.ID);
                    PlayerJoinCompletedNotification.Notify(client, gameID.Value, client.User.ID);
                }
                else if (client.Type == ClientType.DedicatedServer)
                {
                    GamePlayerStateChangeNotification.Notify(client, gameID.Value, personaID.Value);
                    PlayerJoinCompletedNotification.Notify(client, gameID.Value, personaID.Value);
                }
            }
            else if (stat.Value == 0)
            {
                if (client.Type == ClientType.GameplayUser)
                {
                    var game = GameManager.Games[gameID.Value];
                    game.Slots.Remove(personaID.Value);

                    PlayerRemovedNotification.Notify(client, client.User.ID);
                }
                else if (client.Type == ClientType.DedicatedServer)
                {
                    var game = GameManager.Games[gameID.Value];
                    game.Slots.Remove(personaID.Value);

                    PlayerRemovedNotification.Notify(client, personaID.Value);
                }
            }
        }
    }
}
