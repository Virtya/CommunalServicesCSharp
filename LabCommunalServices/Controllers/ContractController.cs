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
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        private readonly ILawService _lawService;
        private readonly IClientService _clientService;
        private readonly IServiceService _serviceService;


        public ContractController(IContractService contractService, IServiceService serviceService, ILawService lawService, IClientService clientService)
        {
            _contractService = contractService;
            _lawService = lawService;
            _clientService = clientService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var contracts = _contractService.GetAll();
            return View(contracts);
        }
        public IActionResult Home(int id)
        {
            var contract = _contractService.GetById(id);
            return View(contract);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Laws = _lawService.GetAll()
                .OrderBy(a => a.ToString());
            ViewBag.Clients = _clientService.GetAll()
                .OrderBy(a => a.ToString());
            ViewBag.Services = _serviceService.GetAll()
                .OrderBy(a => a.ToString());
            if (id == null)
                return View();
            var contract = _contractService.GetById(id.Value);
            return View(contract);
        }

        [HttpPost]
        public IActionResult Edit(ContractDto contract)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Edit), new { id = contract.Id });

            var res = _contractService.CreateOrUpdate(contract);
            return RedirectToAction(nameof(Home), new { id = res.Id });
        }
        public IActionResult Delete(int id)
        {
            _contractService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
