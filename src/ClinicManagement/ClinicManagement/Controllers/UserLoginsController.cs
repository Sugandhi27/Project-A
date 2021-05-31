using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.Extensions.Logging;
using ClinicManagement.Service;

namespace ClinicManagement.Controllers
{
    public class UserLoginsController : Controller
    {
        public readonly ILogger<UserLoginsController> _logger;
        public readonly ILogin<UserLogin> _repo;
        public readonly ClinicContext _context;
        public UserLoginsController(ILogger<UserLoginsController> logger, ILogin<UserLogin> repo, ClinicContext context)
        {
            _logger = logger;
            _repo = repo;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UserLogin> userLogin = _repo.GetAll().ToList();
            return View(userLogin);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserLogin login)
        {
            _repo.Add(login);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin login)
        {
            var obj = _repo.UserLogin(login);
            try
            {
                if (_context.RegisterTable.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault() != null)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    TempData["Message"] = "You’ve entered an incorrect UserName or Password";
                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)

            {
                _logger.LogDebug(e.Message);

            }
            return RedirectToAction("Error");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}
