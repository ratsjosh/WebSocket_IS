using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketApplication.Controllers
{
    public class SocketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}