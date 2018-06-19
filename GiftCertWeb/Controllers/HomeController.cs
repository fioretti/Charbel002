﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GiftCertWeb.Models;
using NToastNotify;

namespace GiftCertWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            //Testing Default Methods
            //Success
            _toastNotification.AddSuccessToastMessage();
            //Info
            _toastNotification.AddInfoToastMessage("This is an info message");
            //Warning
            _toastNotification.AddWarningToastMessage("This is a warning message");
            //Wrror
            _toastNotification.AddErrorToastMessage();

            //_toastNotification.AddToastMessage("Custom Title", "My Custom Message", ToastEnums.ToastType.Success, new ToastOption()
            //{
            //    PositionClass = ToastPositions.BottomLeft
            //});
            return View();
        }

        public IActionResult About()
        {
            //_toastNotification.AddToastMessage("Success About Title", "My About Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
            //{
            //    PositionClass = ToastPositions.BottomFullWidth
            //});

            return View();
        }

        public IActionResult Contact()
        {
            //_toastNotification.AddToastMessage("Redirected...", "You were redirected from Contact Page.", ToastEnums.ToastType.Info, new ToastOption()
            //{
            //    PositionClass = ToastPositions.TopCenter
            //});
            return RedirectToAction("About"); ;
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("ERROR", "There was something wrong with this request.");
            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
