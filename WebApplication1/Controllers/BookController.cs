﻿using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
