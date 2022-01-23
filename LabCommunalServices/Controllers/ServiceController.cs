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
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var services = _serviceService.GetAll();
            return View(services);
        }
        public IActionResult Home(int id)
        {
            var client = _serviceService.GetById(id);
            return View(client);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View();
            var client = _serviceService.GetById(id.Value);
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(ServiceDto service)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Edit), new { id = service.Id });
            var res = _serviceService.CreateOrUpdate(service);
            return RedirectToAction(nameof(Home), new { id = res.Id });
        }
        public IActionResult Delete(int id)
        {
            _serviceService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
