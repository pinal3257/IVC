using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IVC.Models;
using IVC.Return;

namespace IVC.Controllers
{
    public class HomeController : Controller
    {
        IVC.User.Domain.IWrite writeUser;

        public HomeController(IVC.User.Domain.IWrite writeUser)
        {
            this.writeUser = writeUser;
        }

        public IActionResult Index()
        {
            IVC.User.DTO.User objUser = new User.DTO.User();

            objUser.FirstName = "Dhaval";
            objUser.LastName = "Patel";
            objUser.Email = "pinalbhadanee@gmail.com";

            Response<int?> resultUser =  writeUser.InsertUpdateUser(objUser);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
