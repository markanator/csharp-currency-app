using CurrencyLibs.Interfaces;
using CurrencyLibs.MX;
using CurrencyLibs;
using CurrencyMVCApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System;
using CurrencyMVCApp.Models;
using System.Diagnostics;

namespace CurrencyMVCApp.Controllers
{
    public class CurrencyController : Controller
    {
        public ICurrencyRepo controllerRepo;
        public RepoViewModel viewModel;

        public CurrencyController(ICurrencyRepo repo)
        {
            //_logger = logger;
            controllerRepo = repo;
            viewModel = new RepoViewModel(controllerRepo);
        }

        // GET: CurrencyController
        public ActionResult Index()
        {
            return View(viewModel);
        }

        // GET: CurrencyController/MakeChange
        public ActionResult MakeChange()
        {
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeChange(double? amount)
        {
            if (amount != null && amount > 0)
            {
                viewModel.MakeChange((double)amount);
            }
            return View(viewModel);
        }
    }
}
