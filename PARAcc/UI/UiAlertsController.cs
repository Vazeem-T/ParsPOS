﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARSAcc.UI
{
    public class UiAlertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
