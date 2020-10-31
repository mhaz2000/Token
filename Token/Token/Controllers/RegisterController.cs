using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Token.Context;
using Token.Models;
using Token.Srvices;

namespace Token.Controllers
{
    public class RegisterController : Controller
    {
        //repository for crud operations
        private readonly IUserRepository _userRepository = new UserRepository();


        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        //create new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Name,Fmaily,Email,Phone,Password")] User user)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {

                bool result = _userRepository.AddUser(user);
                //checks if email, phone or email is repetitve or not
                if (!result)
                {
                    ViewBag.Error = "Email,Phone or UserName is repetitive!";
                    return View(user);
                }
                _userRepository.Save();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }



        protected override void Dispose(bool disposing)
        {
            _userRepository.Dispose();
        }
    }
}
