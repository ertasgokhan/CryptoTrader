﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.Controllers
{
    public class MemberController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Roles()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddRoles()
        {
            return View();
        }
    }
}
