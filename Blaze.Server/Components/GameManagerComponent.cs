using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameManagerComponent
    {
        public static void HandleRequest(Client client, Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    CreateGameCommand.HandleRequest(client, request);
                    break;

                //case 2:
                //    Log.Warn("*destroyGame(game)");
                //    break;

                case 3:
                    AdvanceGameStateCommand.HandleRequest(client, request);
                    break;

                case 4:
                    SetGameSettingsCommand.HandleRequest(client, request);
                    break;

                //case 5:
                //    SetPlayerCapacityCommand.HandleRequest(client, request);
                //    break;

                //case 7:
                //    SetGameAttributesCommand.HandleRequest(client, request);
                //    break;

                case 9:
                    JoinGameCommand.HandleRequest(client, request);
                    break;

                //case 0xB:
                //    //Log.Warn("*GameManager->HandleRemovePlayerCommand*");
                //    //HandleRemovePlayerCommand(clientId, request, stream);
                //    break;

                case 0xF:
                    FinalizeGameCreationCommand.HandleRequest(client, request);
                    break;

                case 0x1D:
                    UpdateMeshConnectionCommand.HandleRequest(client, request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
