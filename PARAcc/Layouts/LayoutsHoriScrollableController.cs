﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARSAcc.Layouts
{
    public class LayoutsHoriScrollableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
