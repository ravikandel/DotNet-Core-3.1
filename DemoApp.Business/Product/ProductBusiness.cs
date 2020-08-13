using DemoApp.Common.Common;
using DemoApp.Repository.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Business.Product
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository repository;
        public ProductBusiness(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IList<Common.Common.Product> GetAll()
        {
            return repository.GetAll();
        }
        public DbResponse InsertUpdate(Common.Common.Product model)
        {
            return repository.InsertUpdate(model);
        }

        public Common.Common.Product PopulateById(int? PId)
        {
            return repository.PopulateById(PId);
        }
        public DbResponse Delete(int? PId)
        {
            return repository.Delete(PId);
        }

        

       
    }
}
