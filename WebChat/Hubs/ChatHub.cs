using Microsoft.AspNetCore.SignalR;

namespace WebChat.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("Welcome", "Hello", 25);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SayHello()
        {
            await Clients.All.SendAsync("Welcome", "Hello", 25, new { te = "das" });
        }
    }
}
