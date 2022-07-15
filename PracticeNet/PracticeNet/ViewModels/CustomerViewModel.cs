using PracticeNet.Models;
using System.Collections.Generic;

namespace PracticeNet.ViewModels
{
    public class CustomerViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public Task Task { get; set; }
    }
}
