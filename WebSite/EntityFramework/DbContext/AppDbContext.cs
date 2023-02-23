using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSite.Cores;
using WebSite.Models;
using WebSite.Models.Comments;

namespace WebSite.EntityFramework.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .Ignore(x => x.TwoFactorEnabled);

            builder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId });

            builder.Entity<FriendUser>()
                .HasKey(x => new { x.FriendRequestId, x.UserId });

            builder.Entity<PostImageModel>()
                .HasKey(x => x.PostId);








        }

        public DbSet<UserInfo> UserAdditionalInfo { get; set; }
        public DbSet<ProfileImageModel> ProfileImages { get; set; }
        public DbSet<CoverImageModel> CoverImages { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<FriendRequests> FriendRequests { get; set; }
        public DbSet<FriendUser> FriendUsers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImageModel> PostImages { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ContactAdministrator> SupportMessages { get; set; }

    }
}
