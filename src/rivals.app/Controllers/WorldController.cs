using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rivals.app.Models;
using rivals.logic.Session;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rivals.app.Controllers
{
    [Authorize]
    public class WorldController : Controller
    {
        private UserSessionManager _userSessionManager;
        
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        { 
            var model = new WorldModel();
            var session = await _userSessionManager.StartSession(User.Identity.Name, "World");
            model.UserSessionID = session.ID;
            return View(model);
        }

        public WorldController(UserSessionManager userSessionManager)
        {
            _userSessionManager = userSessionManager;
        }
    }
}
