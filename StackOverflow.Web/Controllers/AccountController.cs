using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Autofac.Core;
using AutoMapper;
using StackOverflow.Domain.Entities;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly IMappingEngine _mappingEngine;
        readonly IReadOnlyRepository _readOrWriteRepository;

        public AccountController(IMappingEngine mappingEngine, IReadOnlyRepository readOrWriteRepository)
        {
            _mappingEngine = mappingEngine;
            _readOrWriteRepository = readOrWriteRepository;
        }

        public ActionResult Register()
        {
            return View(new AccountRegisterModel());
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", new AccountLoginModel());
            }
            return View(model);
        }

        public ActionResult Login(string email)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToAction("Index", "Question");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult PasswordRecovery()
        {
            return View(new PasswordRecovery());
        }

        public ActionResult Profile()
        {
            return View(new ProfileModel());
        }
    }
}
