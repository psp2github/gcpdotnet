using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GcpHelloWorld.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net.NetworkInformation;

namespace GcpHelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string currentFilter, string searchString)
        {
            if (searchString != null)
            {
                try
                {
                    Ping pingIp = new Ping();
                    PingReply reply = pingIp.Send(searchString, 1000);
                    if (reply != null)
                    {
                        ViewData["Results"] = reply.Status;
                    }
                }
                catch(Exception ex)
                {
                    ViewData["Results"] = ex.ToString();
                }
            }

            
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
