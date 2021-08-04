using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Aplicacion.ACCIONNOTAS {
    [Authorize]
    [AllowAnonymous]
    public class ChatHub : Hub {
        public override async Task OnConnectedAsync () {
            var name = Context.GetHttpContext ().Request.Query["username"];

            await Groups.AddToGroupAsync (Context.ConnectionId, name);

            await base.OnConnectedAsync ();
        }
        public override async Task OnDisconnectedAsync (Exception exception) {
            var name = Context.GetHttpContext ().Request.Query["username"];
            await Groups.RemoveFromGroupAsync (Context.ConnectionId, name);
            await base.OnDisconnectedAsync (exception);
        }
    }
}