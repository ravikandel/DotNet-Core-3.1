using AutoMapper;
using DemoApp.Common.Common;
using DemoApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Web.MappingConfigurations
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            // Default mapping when property names are same
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel,Product>();

        }
    }
}
