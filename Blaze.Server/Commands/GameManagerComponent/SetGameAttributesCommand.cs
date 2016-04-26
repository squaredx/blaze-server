using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class SetGameAttributesCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];
            var attributes = (TdfMap)request.Data["ATTR"];

            //Update each attribute
            foreach (var item in attributes.Map)
            {
                GameManager.Games[gameID.Value].Attributes[item.Key] = item.Value;
            }

            Log.Info(string.Format("Client {0} set game {1} attributes", request.Client.ID, gameID.Value));

            request.Reply();

            var data = new List<Tdf>
            {
                new TdfMap("ATTR", TdfBaseType.String, TdfBaseType.String, attributes.Map),
                new TdfInteger("GID", gameID.Value)
            };

            request.Reply(0, data);
        }
    }
}
