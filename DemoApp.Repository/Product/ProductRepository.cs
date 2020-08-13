using DemoApp.Common.Common;
using DemoApp.Repository.DbConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DemoApp.Repository.Product
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext Context;

        public ProductRepository(ProductContext _Context)
        {
            Context = _Context;
        }

        public IList<Common.Common.Product> GetAll()
        {
            return Context.Product.Where(t => t.IsActive).ToList();
        }

        public DbResponse InsertUpdate(Common.Common.Product model)
        {

            var response = new DbResponse();

            if (string.IsNullOrEmpty(model.PId.ToString()))// insert
            {
                try
                {
                    bool productCodeExists = Context.Product.Any(x => x.ProductCode == model.ProductCode);

                    if (productCodeExists)
                    {
                        response.SetError(1, "Error! Product Code Already Exists!");
                        return response;
                    }

                    model.CreatedOn = DateTime.Now;
                    model.IsActive = true;
                    Context.Product.Add(model);
                    Context.SaveChanges();
                    response.SetError(0, "Data Inserted Succesfully!");
                }
                catch (Exception ex)
                {
                    response.SetError(1, "Error! while Inserting Data!");
                }
            }
            else //update
            {
                try
                {
                    bool productCodeExists = Context.Product.Any(x => x.ProductCode == model.ProductCode && x.PId != model.PId);

                    if (productCodeExists)
                    {
                        response.SetError(1, "Error! Product Code Already Exists!");
                        return response;
                    }

                    var data = Context.Product.Where(t => t.IsActive).FirstOrDefault(t => t.PId.Equals(model.PId));

                    if (data == null)
                    {
                        response.SetError(1, "Error! while Updating Data!");
                    }
                    else
                    {
                        data.ProductCode = model.ProductCode;
                        data.ProductName = model.ProductName;
                        data.Manufacturer = model.Manufacturer;
                        data.Quantity = model.Quantity;
                        data.Rate = model.Rate;
                        data.LastModifiedOn = DateTime.Now;
                        data.IsActive = true;
                        Context.Product.Update(data);
                        Context.SaveChanges();
                        response.SetError(0, "Data Updated Succesfully!");
                    }
                }
                catch (Exception ex)
                {
                    response.SetError(1, "Error! while Updating Data!");
                }
            }

            return response;
        }

        public Common.Common.Product PopulateById(int? PId)
        {
            return Context.Product.Where(s => s.IsActive).FirstOrDefault(s => s.PId.Equals(PId));
        }

        public DbResponse Delete(int? PId)
        {
            var response = new DbResponse();
            try
            {
                bool productExists = Context.Product.Any(x => x.PId == PId);

                if (!productExists)
                {
                    response.SetError(1, "Error! Product doesnot Exists!");
                    return response;
                }

                var data = Context.Product.Where(t => t.IsActive).FirstOrDefault(t => t.PId.Equals(PId));

                if (data == null)
                {
                    response.SetError(1, "Error! Product Already Deleted!");
                }
                else
                {
                    data.LastModifiedOn = DateTime.Now;
                    data.IsActive = false;
                    Context.Product.Update(data);
                    Context.SaveChanges();
                    response.SetError(0, "Data Deleted Succesfully!");
                }
            }
            catch (Exception ex)
            {
                response.SetError(1, "Error! while Updating Data!");
            }
            return response;
        }


    }
}
