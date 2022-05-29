using OrderProcessAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessAPI.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }
        public List<ProductViewModel> Data{ get; set; }
    }
}
