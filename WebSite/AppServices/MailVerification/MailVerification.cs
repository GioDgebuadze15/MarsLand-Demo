using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Enums;
using WebSite.Models;

namespace WebSite.AppServices.MailVerification
{
    public class MailVerification : IMailVerification
    {
        private readonly AppDbContext _regRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public MailVerification(AppDbContext regRepository, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _regRepository = regRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public MailVerificationModel GenerateEmailConfirmationCode(string email)
        {
            Random rand = new Random();
            var code = rand.Next(999, 10000);
            if (SendMail(email, code))
            {
                var model = new MailVerificationModel
                {
                    Email = email,
                    SentCode = GetHahedCode(code)
                };
                return model;
            }
            else
            {
                return new MailVerificationModel();
            }
        }
        public bool CompareCodes(MailVerificationModel mailVerificationModel)
        {
            string hashcode = GetHahedCode((int)mailVerificationModel.WrittenCode);
            if (mailVerificationModel.SentCode == hashcode)
                return true;
            else
                return false;


        }

        

        //sends email to user for verification and returns true if it's sent and false if not
        public bool SendMail(string email, int code)
        {
            bool isSent = false;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Web Site", "WebSiteSocialNetwork2@gmail.com"));
            message.To.Add(new MailboxAddress("User", email));
            message.Subject = "Email Verification";
            message.Body = new TextPart("plain")
            {
                Text = "Your verification code is " + code.ToString()
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("WebSiteSocialNetwork2@gmail.com", "WebSite222");
                client.Send(message);
                isSent = true;
            }
            return isSent;
        }

        public async Task<string> CheckVerificationPurpose(MailVerificationModel mailVerificationModel)
        {
            string result;
            if (CompareCodes(mailVerificationModel))
            {
                var user = await _userManager.FindByEmailAsync(mailVerificationModel.Email);

                if (mailVerificationModel.Puropse == MailVerificationPurposeEnum.EmailVerification)
                {
                    await VerifyEmail(user);
                    await _signInManager.SignInAsync(user, true);

                    result = "Verified";
                }
                else
                {
                    if (user.EmailConfirmed == false)
                    {
                        await VerifyEmail(user);
                        
                    }
                    result = "RecoverPassword";
                }
            }
            else
            {
                result = "Error";

            }
            return result;
        }

        public async Task VerifyEmail(AppUser user)
        {
            user.EmailConfirmed = true;
            _regRepository.Users.Update(user);
            await _regRepository.SaveChangesAsync();


        }

        private static string GetHahedCode(int code)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(code.ToString()));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
