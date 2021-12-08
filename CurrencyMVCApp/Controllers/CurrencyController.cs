using CurrencyLibs.Interfaces;
using CurrencyLibs.MX;
using CurrencyLibs;
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
        public ICurrencyRepo repo;
        public RepoViewModel viewModel;
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
            _logger.LogInformation(viewModel.TotalValue.ToString());
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
                viewModel.MakeChange(amount);
            }
            return RedirectToAction(nameof(this.Index));
        }
    }
}
