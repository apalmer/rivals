using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using rivals.app.Models;
using rivals.persistence;

namespace rivals.app.Controllers
{
    public class SpikeController : Controller
    {
        private ISpikeRepo Repository { get; set; }

        public SpikeController(ISpikeRepo repo)
        {
            Repository = repo;
        }

        public IActionResult Index()
        {
            var model = new SpikeModel();
            model.Items = Repository.GetSpikeItems();
            return View(model);
        }
    }
}