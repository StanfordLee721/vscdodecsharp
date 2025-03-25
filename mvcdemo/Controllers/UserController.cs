using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mvcdemo.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        public IActionResult Login()
        {
            return Content("這是登入頁!!");
        }
    }
}