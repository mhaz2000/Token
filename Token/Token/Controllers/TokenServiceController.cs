using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Token.Models;
using Token.Srvices;
using Token.TokenGeneration;

namespace Token.Controllers
{
    public class TokenServiceController : Controller
    {
        //repository for crud operation
        private readonly IUserRepository userRepository = new UserRepository();

        // GET: TokenService
        public ActionResult GetToken()
        {
            return View();
        }

        //show token by username and password
        [HttpPost]
        public ActionResult GetToken([Bind(Include = "Username,Password")] UserDto user)
        {
            User Res = null;
            //checks if username is empty
            if (!string.IsNullOrWhiteSpace(user.Username))
                Res = userRepository.GetUserMyUserName(user.Username);

            //checks if any user was found or not.
            if (Res is null)
            {
                ViewBag.Message = "Not Exist!";
                return View(user);
            }

            //checks user password
            if (Res.Password == user.Password)
                ViewBag.Token = GenerateToken.tokenGenerate(Res);
            else
                ViewBag.Message = "Wrong Password!";

            return View(user);
        }


        public ActionResult GetInfo()
        {
            return View();
        }

        //show user information by a given token
        [HttpPost]
        public ActionResult GetInfo(string Token)
        {
            var Result = GenerateToken.TokenToInfo(Token);

            //checks if any result eas found or not.
            if (Result.Count==0)
                ViewBag.Message = "Token is not valid!";
            else
                ViewBag.Info = Result;

            return View();
        }
    }
}