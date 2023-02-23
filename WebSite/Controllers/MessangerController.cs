using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSite.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebSite.EntityFramework.DbContext;
using WebSite.Hubs;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize]
    public class MessangerController : BaseController
    {
        private readonly IChatRepository _repo;
        private readonly UserManager<AppUser> _userManager;

        public MessangerController(IChatRepository repo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            var chats = _repo.GetChats(GetUserId());

            return View(chats);
        }

        public IActionResult Find([FromServices] AppDbContext _regRepository)
        {
            var users = _regRepository.Users
                .Where(x => x.Id != User.GetUserId())
                .ToList();

            return View(users);
        }

        public IActionResult Private()
        {
            var chats = _repo.GetPrivateChats(GetUserId());

            return View(chats);
        }

        public async Task<IActionResult> CreatePrivateRoom(string userId)
        {
            var id = await _repo.CreatePrivateRoom(GetUserId(), userId, User.Identity.Name);

            return RedirectToAction("Chat", new { id });
        }

        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            return View(_repo.GetChat(GetUserId(), id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            await _repo.CreateRoom(name, GetUserId());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(int id)
        {
            await _repo.JoinRoom(id, GetUserId());

            return RedirectToAction("Chat", "Messanger", new { id = id });
        }

        public async Task<IActionResult> SendMessage(
            int roomId,
            string message,
            [FromServices] IHubContext<ChatHub> chat)
        {
            var Message = await _repo.CreateMessage(roomId, message, User.Identity.Name);

            await chat.Clients.Group(roomId.ToString())
                .SendAsync("ReceiveMessage", new
                {
                    Text = Message.Text,
                    Name = Message.Name,
                    Timestamp = Message.Timestamp.ToString("hh:mm MM/dd")
                });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> LeaveChat(int Id)
        {
            await _repo.LeaveRoom(Id, GetUserId());
            return RedirectToAction("Index", new { Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int Id)
        {
            await _repo.DeleteRoom(Id, GetUserId());
            return RedirectToAction("Index", new { Id });
        }

        [HttpPost]
        public async Task<IActionResult> EditRoomName(int Id, string newName)
        {
            await _repo.EditRoomName(Id, GetUserId(), newName);
            return RedirectToAction("Chat", new { Id });
        }

        [HttpPost]
        public async Task<IActionResult> FindUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user.Id == GetUserId())
            {
                return RedirectToAction("Find");
            }
            else if (user != null)
            {
                return RedirectToAction("CreatePrivateRoom", new { userId = user.Id});
            }
            else
            {
                return RedirectToAction("Find");
            }
        }

    }
}
