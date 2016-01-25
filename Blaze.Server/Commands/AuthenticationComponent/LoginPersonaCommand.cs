using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class LoginPersonaCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} logging in to persona {1}", client.ID, client.User.Name));

            var data = new List<Tdf>
            {
                new TdfInteger("BUID", client.User.ID),
                new TdfInteger("FRST", 0),
                new TdfString("KEY", ""),
                new TdfInteger("LLOG", Utils.GetUnixTime()),
                new TdfString("MAIL", client.User.Email),
                new TdfStruct("PDTL", new List<Tdf>
                {
                    new TdfString("DSNM", client.User.Name),
                    new TdfInteger("LAST", Utils.GetUnixTime()),
                    new TdfInteger("PID", client.User.ID),
                    new TdfInteger("STAS", 2),
                    new TdfInteger("XREF", 0),
                    new TdfInteger("XTYP", (ulong)ExternalRefType.Unknown)
                }),
                new TdfInteger("UID", (ulong)client.ID)
            };

            client.Reply(request, 0, data);

            UserAddedNotification.Notify(client, client.User.ID, client.User.Name);
            UserUpdatedNotification.Notify(client, client.User.ID);
        }
    }
}
