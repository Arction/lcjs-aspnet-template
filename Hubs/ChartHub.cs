using Microsoft.AspNetCore.SignalR;

namespace LCJS_x_ASP.Hubs
{
    public class ChartHub : Hub
    {
        public const string Url = "/chart";

        public override Task OnConnectedAsync()
        {
            string connectionID = Context.ConnectionId;
            return base.OnConnectedAsync();
        }

    }
}
