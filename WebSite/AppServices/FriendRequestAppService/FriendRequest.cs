using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Enums;
using WebSite.Models;

namespace WebSite.AppServices.FriendRequestAppService
{
    public class FriendRequest : IFriendRequest
    {
        private readonly AppDbContext _regRepository;

        public FriendRequest(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }

        public async Task<bool> SendFriendRequest(string senderUserId, string receiverUserId)
        {
            

            if (!AlreadyExists(senderUserId,receiverUserId))
            {
                var frienRequest = new FriendRequests
                {
                    RequestTime = DateTime.Now,
                    FriendStatus = FriendRequestEnum.NotAnswered

                };
                frienRequest.FriendUsers.Add(new FriendUser
                {
                    UserId = senderUserId,
                    Role = FriendRequestRoleEnum.Sender
                });
                frienRequest.FriendUsers.Add(new FriendUser
                {
                    UserId = receiverUserId,
                    Role = FriendRequestRoleEnum.Receiver
                });

                _regRepository.Add(frienRequest);
                await _regRepository.SaveChangesAsync();
                return true;
            }
            return false;

        }




        public List<FriendRequests> SentFriendRequestsOutput(string userId)
        {
            var requests = _regRepository.FriendRequests
                                .Where(x => x.FriendStatus == FriendRequestEnum.NotAnswered)
                                .Include(x => x.FriendUsers.Where(x => x.Role == FriendRequestRoleEnum.Receiver))
                                    .ThenInclude(x => x.User)
                                        .ThenInclude(x => x.UserInfo)
                                            .ThenInclude(x => x.ProfileImage)
                                .ToList();
            if (requests.Count == 0)
            {
                return new List<FriendRequests>();
            }
            else
            {
                return requests;
            }

        }

        public List<FriendRequests> ReceivedFriendRequestsOutput(string userId)
        {
            var requests = _regRepository.FriendRequests
                                .Where(x => x.FriendStatus == FriendRequestEnum.NotAnswered && x.FriendUsers.Any(y => y.UserId == userId))
                                    .Include(x => x.FriendUsers.Where(x => x.Role == FriendRequestRoleEnum.Sender && x.UserId != userId))
                                        .ThenInclude(x => x.User)
                                        .ThenInclude(x => x.UserInfo)
                                            .ThenInclude(x => x.ProfileImage)
                                .ToList();
            if (requests.Count == 0)
            {
                return new List<FriendRequests>();
            }
            else
            {
                return requests;
            }
        }


        public async Task<bool> AcceptFriendRequest(int id)
        {
            var request = _regRepository.FriendRequests.Where(x => x.Id == id && x.FriendStatus == FriendRequestEnum.NotAnswered).FirstOrDefault();

            if (request != null)
            {
                request.FriendStatus = FriendRequestEnum.Approved;
                request.ResponseTime = DateTime.Now;

                _regRepository.Entry(request).State = EntityState.Modified;

                await _regRepository.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<bool> DeclineFriendRequest(int id)
        {
            var request = _regRepository.FriendRequests.Where(x => x.Id == id && x.FriendStatus == FriendRequestEnum.NotAnswered).FirstOrDefault();

            if (request != null)
            {
                request.FriendStatus = FriendRequestEnum.Rejected;
                request.ResponseTime = DateTime.Now;

                _regRepository.Entry(request).State = EntityState.Modified;
                await _regRepository.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> CancelFriendRequest(int id)
        {
            var request = _regRepository.FriendRequests.Where(x => x.Id == id && x.FriendStatus == FriendRequestEnum.NotAnswered)
                                            .Include(x => x.FriendUsers).FirstOrDefault();

            if (request != null)
            {
                _regRepository.FriendRequests.Remove(request);
                await _regRepository.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }


        }


        public async Task<bool> RemoveFriend(int id)
        {
            var request = _regRepository.FriendRequests.Where(x => x.Id == id && x.FriendStatus == FriendRequestEnum.Approved)
                                            .Include(x => x.FriendUsers).FirstOrDefault();

            if (request != null)
            {
                _regRepository.FriendRequests.Remove(request);
                await _regRepository.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }


        private bool AlreadyExists(string senderUserId, string receiverUserId)
        {
            var result = _regRepository.FriendRequests.Include(x => x.FriendUsers)
                                                    .ThenInclude(x => x.User).Where(x => x.FriendUsers.Any(y => y.UserId == senderUserId)
                                                                                                    && x.FriendUsers.Any(y => y.UserId == receiverUserId))
                                                    .FirstOrDefault();
            if(result != null)
            {
                return true;
            }
            return false;
        }
    }
}
