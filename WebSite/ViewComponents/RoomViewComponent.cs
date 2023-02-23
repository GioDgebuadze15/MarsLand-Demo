using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.EntityFramework.DbContext;
using WebSite.Models;

namespace WebSite.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly AppDbContext _regRepository;

        public RoomViewComponent(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chats = _regRepository.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == userId
                    && x.Chat.Type == ChatType.Room)
                .Select(x => x.Chat)
                .ToList();

            return View(chats);
        }
    }
}
