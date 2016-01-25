using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class AdvanceGameStateCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var gameState = (TdfInteger)request.Data["GSTA"];

            Log.Info(string.Format("Client {0} changing game {1} state to {2}", client.ID, gameID.Value, (GameState)gameState.Value));

            var game = GameManager.Games[gameID.Value];
            game.State = (GameState)gameState.Value;

            client.Reply(request, 0, null);

            GameStateChangeNotification.Notify(client);
        }
    }
}
