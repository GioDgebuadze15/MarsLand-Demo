using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebSite.Hubs
{
    public class PostHub:Hub
    {
        public Task JoinPost(string postId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, postId);
        }

        public Task LeavePost(string postId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, postId);
        }
    }
}
