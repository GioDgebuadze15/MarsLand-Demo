using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;

namespace WebSite.AppServices.FriendRequestAppService
{
    public interface IFriendRequest
    {
        Task<bool> SendFriendRequest(string senderUserId, string receiverUserId);

        List<FriendRequests> SentFriendRequestsOutput(string userId);
        List<FriendRequests> ReceivedFriendRequestsOutput(string userId);

        Task<bool> AcceptFriendRequest(int id);
        Task<bool> DeclineFriendRequest(int id);
        Task<bool> CancelFriendRequest(int id);

        Task<bool> RemoveFriend(int id);
    }
}
