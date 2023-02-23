 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.AppServices.MailVerification;
using WebSite.AppServices.Registration;
using WebSite.AppServices.Reviews;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRegistrationInfo _iRegistrationInfo;
        private readonly IMailVerification _iMailVerification;
        private readonly IReview _iReview;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IRegistrationInfo iRegistrationInfo, IMailVerification iMailVerification, IReview iReview)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _iRegistrationInfo = iRegistrationInfo;
            _iMailVerification = iMailVerification;
            _iReview = iReview;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult>  Registration()
        {
            ExternalLoginModel externalLogin = new ExternalLoginModel()
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(externalLogin);

        }
        

        [HttpPost]
        public async Task<JsonResult>  Registration(RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _iRegistrationInfo.CreateAppUser(registrationViewModel);
                if (result.Succeeded)
                {
                    var model = _iMailVerification.GenerateEmailConfirmationCode(registrationViewModel.Email);

                    return Json(new { redirectUrl = Url.Action("VerificationPage", "LogIn", model), isRedirect = true });
                }
                else
                {
                    var errors = result.Errors.ToList();
                    return Json(new { response = errors });
                }
            }   
            return Json("");
        }

        [HttpGet]
        public IActionResult Feedback([FromServices] AppDbContext _regRepository)
        {
            var feedbacks = _regRepository.Feedbacks
                .ToList();
            PageAverageStarLevel pageAverageStarLevel = _iReview.CalculateAverageStarLevel();

            return View(new FeedbackView() { Feedback = feedbacks, PageAverageStarLevel = pageAverageStarLevel});
        }

        [HttpGet]
        public IActionResult LeaveFeedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateFeedback(string feedbackName, string feedbackText, int starLevel)
        {
            var feedback = await _iReview.SubmitFeedback(feedbackName,feedbackText,starLevel);
            if (feedback!= null)
            {
                return Json(new { redirectUrl = Url.Action("Feedback"), isRedirect = true });

            }
            else
            {
                return Json("Error");
            }
            
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ContactAdministrator(string name, string email, string message)
        {
            var supportMessage = await _iReview.SubmitSupportMessage(name, email, message);
            if (supportMessage != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("ContactUs", "Home");
            }

        }

        [HttpGet]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TermsOfService()
        {
            return View();
        }

    }
}
