using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeNet.Data;
using PracticeNet.Models;
using PracticeNet.Services;
using PracticeNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ICustomerService customService)
        {
            _logger = logger;
            _context = context;
            _customService = customService;
        }


        public IActionResult Index(CustomerViewModel customerView)
        {
           
            return View(customerView);
        }

        [HttpPost]
        public IActionResult Export()
        {
            //if (custom == null) return NotFound();


            
            byte[] fileContent;
            string fileName = "Butun musteriler excel";

            fileContent = _customService.GetCustomersForExport();

            if (fileContent != null)
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"{fileName}.xlsx");
            return RedirectToAction("Index");
        }
    }
}
    