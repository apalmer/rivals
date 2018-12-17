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
        private IRepo<domain.Spike.SpikeItem> Repository { get; set; }

        public SpikeController(IRepo<domain.Spike.SpikeItem> repo)
        {
            Repository = repo;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SpikeCollectionModel();
            model.Items = await Repository.GetAll();
            return View(model);
        }

        // GET: Default/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var model = new SpikeModel();
            model.Item = await Repository.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new SpikeModel();

            return View(model);
        }

        // POST: Default/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpikeModel model)
        {
            try
            {
                // TODO: Add insert logic here
                await Repository.Insert(model.Item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Default/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var model = new SpikeModel();
            model.Item = await Repository.GetById(id);
            return View(model);
        }

        // POST: Default/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SpikeModel model)
        {
            try
            {
                // TODO: Add update logic here
                await Repository.Update(model.Item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Default/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var model = new SpikeModel();
            model.Item = await Repository.GetById(id);

            return View(model);
        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, SpikeModel model)
        {
            try
            {
                // TODO: Add delete logic here
                await Repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}