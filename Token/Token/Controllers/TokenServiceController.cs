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
        private readonly IUserRepository _userRepository = new UserRepository();

        // GET: TokenService
        public ActionResult GetToken()
        {
            return View();
        }

        //show token by username and password
        [HttpPost]
        public ActionResult GetToken([Bind(Include = "Username,Password")] UserDto user)
        {
            User result = null;
            //checks if username is empty
            if (!string.IsNullOrWhiteSpace(user.UserName))
                result = _userRepository.GetUserMyUserName(user.UserName);

            //checks if any user was found or not.
            if (result is null)
            {
                ViewBag.Message = "Not Exist!";
                return View(user);
            }

            //checks user password
            if (result.Password == user.PassWord)
                ViewBag.Token = GenerateToken.TokenGenerate(result);
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
        public ActionResult GetInfo(string token)
        {
            try
            {
                var result = GenerateToken.TokenToInfo(token);

                //checks if any result eas found or not.
                if (result.Count == 0)
                    ViewBag.Message = "Token is not valid!";
                else
                    ViewBag.Info = result;

                
            }
            catch (Exception)
            {
                ViewBag.Info = null;
                ViewBag.Message = "Token is not valid!";
            }
            return View();
        }
    }
}