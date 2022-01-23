using Business.Interop;
using Business.Services;
using LabCommunalServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LabCommunalServices.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IGenderService _genderService;
        private readonly ICityService _cityService;

        public ClientController(IClientService clientService, IGenderService genderService, ICityService cityService)
        {
            _clientService = clientService;
            _genderService = genderService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var clients = _clientService.GetAll();
            return View(clients);
        }
        public IActionResult Home(int id)
        {
            var client = _clientService.GetById(id);
            return View(client);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Genders = _genderService.GetAll()
                .OrderBy(a => a.ToString());
            ViewBag.Cities = _cityService.GetAll()
                .OrderBy(a => a.ToString());
            if (id == null)
                return View();
            var client = _clientService.GetById(id.Value);
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(ClientDto client)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Edit), new { id = client.Id });
            var res = _clientService.CreateOrUpdate(client);
            return RedirectToAction(nameof(Home), new { id = res.Id });
        }
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
