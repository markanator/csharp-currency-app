using CurrencyLib.Interfaces;
using CurrencyLib.MX;
using CurrencyMVCApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System;

namespace CurrencyMVCApp.Controllers
{
    public class CurrencyController : Controller
    {
        ICurrencyRepo repo { get; set; }
        RepoViewModel viewModel { get; set; }
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
            repo = new MXCurrencyRepo();
            viewModel = new RepoViewModel(repo);
        }

        // GET: CurrencyController
        public ActionResult Index()
        {
            return View(viewModel);
        }

        // GET: CurrencyController/Details/5
        public ActionResult MakeChange()
        {
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeChange(double amount)
        {
            if (amount > 0)
            {
                _logger.LogInformation(amount.ToString());
                viewModel.MakeChange(Convert.ToDouble(amount));
            }
            return RedirectToAction(nameof(this.Index));
        }
    }
}
