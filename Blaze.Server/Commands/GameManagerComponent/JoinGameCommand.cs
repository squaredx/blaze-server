using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class JoinGameCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];

            if (!GameManager.Games.ContainsKey(gameID.Value))
            {
                client.Reply(request, 0x12D0004, null);
                return;
            }

            client.GameID = gameID.Value;

            var data = new List<Tdf>
            {
                new TdfInteger("GID", (ulong)gameID.Value),
                new TdfInteger("JGS", 0)
            };

            client.Reply(request, 0, data);

            var game = GameManager.Games[gameID.Value];
            var gameClient = BlazeServer.Clients[game.ClientID];

            game.Slots.Add(client.User.ID);
            var slotID = game.Slots.FindIndex(slot => slot == client.User.ID);

            Log.Info(string.Format("Client {0} reserving slot {1} in game {2}", client.ID, slotID, gameID.Value));

            UserAddedNotification.Notify(client, gameClient.User.ID, gameClient.User.Name);
            UserUpdatedNotification.Notify(client, gameClient.User.ID);

            PlayerJoiningNotification.Notify(client);

            JoiningPlayerInitiateConnectionsNotification.Notify(client);
            PlayerClaimingReservationNotification.Notify(client);            
        }
    }
}
