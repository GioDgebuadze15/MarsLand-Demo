using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Models;

namespace WebSite.Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext _regRepository;
        private readonly UserManager<AppUser> _userManager;

        public ChatRepository(AppDbContext regRepository, UserManager<AppUser> userManager)
        {
            _regRepository = regRepository;
            _userManager = userManager;
        }

        public async Task<Message> CreateMessage(int chatId, string message, string userId)
        {
            var Message = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = userId,
                Timestamp = DateTime.Now
            };

            _regRepository.Messages.Add(Message);
            await _regRepository.SaveChangesAsync();

            return Message;
        }

        public async Task<int> CreatePrivateRoom(string rootId, string targetId, string creatorName)
        {
            var targetUser = _userManager.FindByIdAsync(targetId).Result;
            int chatId = FindPrivateChat(rootId, targetId);

            if (chatId == 0)
            {
                var chat = new Chat
                {
                    Type = ChatType.Private,
                    Name = creatorName + " -- " + targetUser.UserName

                };
                
                chat.Users.Add(new ChatUser
                {
                    UserId = targetId
                });

                chat.Users.Add(new ChatUser
                {
                    UserId = rootId
                });

                _regRepository.Chats.Add(chat);

                await _regRepository.SaveChangesAsync();

                return chat.Id;
            }
            else
            {
                return chatId;
            }
        }

        public async Task CreateRoom(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
                Role = UserRole.Admin
            });

            _regRepository.Chats.Add(chat);

            await _regRepository.SaveChangesAsync();
        }

        public Chat GetChat(string userId, int id)
        {
            return _regRepository.Chats
                                     .Include(x => x.Users)
                                        .ThenInclude(x => x.User)
                                     .Where(x => x.Users.Any(y => y.UserId == userId)).Include(x => x.Messages)
                                     .FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<Chat> GetChats(string userId)
        {
            return _regRepository.Chats
                .Include(x => x.Users)
                .Where(x => x.Type != ChatType.Private && !x.Users
                    .Any(y => y.UserId == userId))
                .ToList();
        }

        public IEnumerable<Chat> GetPrivateChats(string userId)
        {
            return _regRepository.Chats
                   .Include(x => x.Users)
                       .ThenInclude(x => x.User)
                   .Where(x => x.Type == ChatType.Private
                       && x.Users
                           .Any(y => y.UserId == userId))
                   .ToList();
        }

        public async Task JoinRoom(int chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                ChatId = chatId,
                UserId = userId,
                Role = UserRole.Member
            };

            _regRepository.ChatUsers.Add(chatUser);

            await _regRepository.SaveChangesAsync();
        }

        public int FindPrivateChat(string rootId, string targetId)
        {
            int chatId = 0;
            var privateChats = _regRepository.Chats
                                            .Include(x => x.Users)
                                                .ThenInclude(x => x.User)
                                            .Where(x => x.Type == ChatType.Private
                                                && x.Users.Any(y => y.UserId == rootId)
                                                && x.Users.Any(y => y.UserId == targetId))
                                            .FirstOrDefault();
            if (privateChats != null)
            {
                chatId = privateChats.Id;
            }
            return chatId;
        }

        public async Task LeaveRoom(int chatId, string userId)
        {
            var chatUser = _regRepository.ChatUsers
                                        .Where(x => x.ChatId == chatId && x.UserId == userId)
                                        .Where(x => x.Role != UserRole.Admin)
                                        .FirstOrDefault();
            if (chatUser != null)
            {
                _regRepository.ChatUsers.Remove(chatUser);
                await _regRepository.SaveChangesAsync();
            }

        }

        public async Task DeleteRoom(int chatId, string userId)
        {
            var chat = _regRepository.Chats
                                   .Where(x => x.Type == ChatType.Room)
                                        .Where(x => x.Users
                                   .Any(y => y.UserId == userId && y.Role == UserRole.Admin))
                                   .FirstOrDefault(x=>x.Id == chatId);


            if (chat != null)
            {
                _regRepository.Chats.Remove(chat);
                await _regRepository.SaveChangesAsync();
            }


        }

        public async Task EditRoomName(int chatId, string userId, string newName)
        {
            var chat = _regRepository.Chats
                                   .Where(x => x.Type == ChatType.Room)
                                        .Where(x => x.Users
                                   .Any(y => y.UserId == userId && y.Role == UserRole.Admin))
                                   .FirstOrDefault(x => x.Id == chatId);


            if (chat != null)
            {
                chat.Name = newName;

                _regRepository.Entry(chat).State = EntityState.Modified;
                await _regRepository.SaveChangesAsync();
            }


        }

       
    }
}
