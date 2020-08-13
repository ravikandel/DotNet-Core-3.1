using DemoApp.Common.Common;
using DemoApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Web.Library
{
    public class ApiResponse
    {
        public DbResponse Result { get; set; }
        public IEnumerable<ProductViewModel> ProductViewModelList { get; set; }
    }
}
