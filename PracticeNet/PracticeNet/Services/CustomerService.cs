using ClosedXML.Excel;
using PracticeNet.Data;
using PracticeNet.Models;
using PracticeNet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticeNet.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public byte[] GetCustomersForExport()
        {
            IList<Customer> customers = _context.Customers.ToList();
            if (customers == null)
            {
                return null;
            }
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Butun musteriler");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Ad";
            worksheet.Cell(1, 3).Value = "Soyad";
            worksheet.Cell(1, 4).Value = "Dogum tarixi";

            for (int i = 1; i <= customers.Count; i++)
            {
                Customer customer = customers[i - 1];
                worksheet.Cell(i + 1, 1).Value = customer?.Id;
                worksheet.Cell(i + 1, 2).Value = customer?.Name;
                worksheet.Cell(i + 1, 3).Value = customer?.Surname;
                worksheet.Cell(i + 1, 4).Value = customer?.BirthDate;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }

    public interface ICustomerService
    {
       
        byte[] GetCustomersForExport();

    }

}