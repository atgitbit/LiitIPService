using LiitIPService.Models;
using LiitIPService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LiitIPService.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly NorthwindContext _context;

        public AdminController(ILogger<AdminController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new AdminStartViewModel();
            //viewModel.EmployeeHeader = "Vi som jobbar här";
            //viewModel.Employees = _context.Employees.Select(e => new HomeIndexViewModel.Employee
            //{
            //    EmployeeId = e.EmployeeId,
            //    EmployeeFirstName = e.FirstName,
            //    EmployeeLastName = e.LastName,
            //    EmployeeTitle = e.Title,

            //}).ToList();

            return View(viewModel);
        }
        public IActionResult SearchUser()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult DeleteUser()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
