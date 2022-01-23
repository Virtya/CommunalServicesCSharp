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
    public class PaymentDocumentController : Controller
    {
        private readonly IPaymentDocService _payDocService;
        private readonly IClientService _clientService;
        private readonly IContractService _contractService;

        public PaymentDocumentController(IPaymentDocService payDocService, IClientService clientService, IContractService contractService)
        {
            _payDocService = payDocService;
            _clientService = clientService;
            _contractService = contractService;
        }

        public IActionResult Index()
        {
            var payDocs = _payDocService.GetAll();
            return View(payDocs);
        }
        public IActionResult Home(int id)
        {
            var payDoc = _payDocService.GetById(id);
            return View(payDoc);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Clients = _clientService.GetAll()
                .OrderBy(a => a.ToString());
            ViewBag.Contracts = _contractService.GetAll()
                .OrderBy(a => a.ToString());
            if (id == null)
                return View();
            var payDoc = _payDocService.GetById(id.Value);
            return View(payDoc);
        }

        [HttpPost]
        public IActionResult Edit(PaymentDocDto paymentDoc)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Edit), new { id = paymentDoc.Id });
            var res = _payDocService.CreateOrUpdate(paymentDoc);
            return RedirectToAction(nameof(Home), new { id = res.Id });
        }
        public IActionResult Delete(int id)
        {
            _payDocService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
