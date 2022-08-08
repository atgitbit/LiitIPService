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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.EmployeeHeader = "Vi som jobbar här";
            viewModel.Employees = _context.Employees.Select(e => new HomeIndexViewModel.Employee
            {
                EmployeeId = e.EmployeeId,
                EmployeeFirstName = e.FirstName,
                EmployeeLastName = e.LastName,
                EmployeeTitle = e.Title,

            }).ToList();

            return View(viewModel);
        }
        public IActionResult SearchProduct(string q, string sortField, string sortOrder, int page = 1)
        {
            var viewModel = new ProductSearchViewModel();
            var query = _context.Products.Where(p => q == null || p.ProductName.Contains(q) || p.ProductId.Equals(q));


            if (string.IsNullOrEmpty(sortField))
                sortField = "Namn";
            if (string.IsNullOrEmpty(sortOrder))
                sortField = "asc";

            if (sortField == "Id")
            {
                if (sortOrder == "asc")
                    query = query.OrderBy(c => c.ProductId);
                else
                    query = query.OrderByDescending(c => c.ProductId);
            }
            if (sortField == "Namn")
            {
                if (sortOrder == "asc")
                    query = query.OrderBy(c => c.ProductName);
                else
                    query = query.OrderByDescending(c => c.ProductName);
            }
            if (sortField == "ProduktPris")
            {
                if (sortOrder == "asc")
                    query = query.OrderBy(c => c.UnitPrice);
                else
                    query = query.OrderByDescending(c => c.UnitPrice);
            }

            int totalRowCount = query.Count();
            int pageSize = 50;
            var pageCount = (double)totalRowCount / pageSize;
            viewModel.TotalPages = (int)Math.Ceiling(pageCount);

            int resultToSkip = (page - 1) * pageSize;
            query = query.Skip(resultToSkip).Take(pageSize);
            viewModel.Products = query.Select(product => new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductTitle = product.ProductName,
                ProductPrice = (decimal)product.UnitPrice
            }).ToList();


            viewModel.q = q;
            viewModel.SortField = sortField;
            viewModel.SortOrder = sortOrder;
            viewModel.Page = page;
            viewModel.OppositeSortOrder = sortOrder == "asc" ? "desc" : "asc";


            return View(viewModel);
        }
        public IActionResult SelectProduct()
        {
            var viewModel = new SelectProductViewModel();
           // var p = _context.Products.Include(p => c.Dispositions).First(a => a.CustomerId == id);
            //var d = _context.Dispositions.Include(d => d.Account).First(d=>d.)

            //viewModel.CustomerNumber = c.CustomerId.ToString();
            //viewModel.PersonalNumber = c.NationalId;
            //viewModel.Name = c.Givenname;
            //viewModel.Adress = c.Streetaddress;
            //viewModel.City = c.City;

            //viewModel.TotalBalanceOnAll = 

            return View(viewModel);
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
