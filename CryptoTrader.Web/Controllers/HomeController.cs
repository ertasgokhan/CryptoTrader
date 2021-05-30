using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoTrader.Web.Models;
using Hangfire;
using CryptoTrader.Web.BackgroundJobs;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.Enums;
using CryptoTrader.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CryptoTrader.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager { get; }
        private SignInManager<AppUser> _signInManager { get; }

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            //RecurringJobs.ReportingJob();

            //ApiClient apiClient = new ApiClient("PrX05PfE29cfXV9YyKwj3zrMadaC4jF7dr4UWoKid5RgQ1WsPsNJD8KLP56g3AwF", "fEOFqMgvXj8ew37Qp12ZpfxlFynmxYNEneNtJVPKQWvs3dvt0LkNNEzQ6660ubiT");
            //BinanceClient binanceClient = new BinanceClient(apiClient);

            //List<Candlestick> tempCandlestick = new List<Candlestick>();

            //tempCandlestick = binanceClient.GetCandleSticks("BNBUSDT", TimeInterval.Hours_1, DateTime.Now.AddMonths(-1), DateTime.Now, 1000).Result.ToList();

            //var accountInfos = binanceClient.GetAccountInfo().Result;
            if (User.Identity.Name != null)
                return RedirectToAction("Index", "Member");
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginViewModel.PassWord, loginViewModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (TempData["ReturnUrl"] != null)
                            return Redirect(TempData["ReturnUrl"].ToString());
                        else
                            return RedirectToAction("Index", "Member");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid E-Mail or Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid E-Mail or Password");
                }
            }

            return View("Index", loginViewModel);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = userViewModel.UserName;
                appUser.Email = userViewModel.Email;
                appUser.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(appUser, userViewModel.PassWord);

                if (result.Succeeded)
                {
                    TempData["RegisterSucceeded"] = true;
                    return RedirectToAction("SignUp");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(userViewModel);
        }

        public IActionResult LogIn(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        public IActionResult ForgotPassword(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
