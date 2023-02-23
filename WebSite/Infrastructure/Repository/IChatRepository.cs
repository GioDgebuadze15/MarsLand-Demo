using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Models;

namespace WebSite.Infrastructure
{
    public interface IChatRepository
    {
        Chat GetChat(string userId, int id);
        Task CreateRoom(string name, string userId);
        Task JoinRoom(int chatId, string userId);
        IEnumerable<Chat> GetChats(string userId);
        Task<int> CreatePrivateRoom(string rootId, string targetId, string creatorName);
        IEnumerable<Chat> GetPrivateChats(string userId);

        Task<Message> CreateMessage(int chatId, string message, string userId);

        int FindPrivateChat(string rootId, string targetId);

        Task LeaveRoom(int chatId, string userId);
        Task DeleteRoom(int chatId, string userId);
        Task EditRoomName(int chatId, string userId, string newName);

        //UserInfo FindUser(string username);
    }
}
