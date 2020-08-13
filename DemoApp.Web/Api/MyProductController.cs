using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoApp.Business.Product;
using DemoApp.Common.Common;
using DemoApp.Web.Filter;
using DemoApp.Web.Library;
using DemoApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApp.Web.Api
{

    [Route("api/[controller]")]
    [ApiController]

    [ApiKeyAuth]
    public class MyProductController : ControllerBase
    {
        IProductBusiness business;
        private readonly IMapper mapper;
        public MyProductController(IMapper _mapper, IProductBusiness _business)
        {
            business = _business;
            mapper = _mapper;


        }
        /// <summary>
        /// Get all Products.
        /// </summary>
        // GET: api/<ProductController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            ApiResponse apiResponse = new ApiResponse();
            DbResponse dbResponse = new DbResponse();
            try
            {
                var _result = business.GetAll();
                IEnumerable<ProductViewModel> result = mapper.Map<IEnumerable<ProductViewModel>>(_result);
                dbResponse.SetError(0, "Success!");
                apiResponse.Result = dbResponse;
                apiResponse.ProductViewModelList = result;
            }
            catch (Exception ex)
            {

                dbResponse.SetError(1, ex.Message.ToString());
                apiResponse.Result = dbResponse;
            }
            return apiResponse;
        }

        /// <summary>
        /// Get a specific Product.
        /// </summary>
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            ApiResponse apiResponse = new ApiResponse();
            DbResponse dbResponse = new DbResponse();
            try
            {
                var _result = business.PopulateById(id);
                IEnumerable<ProductViewModel> result = mapper.Map<IEnumerable<ProductViewModel>>(_result);

                dbResponse.SetError(0, "Success!");
                apiResponse.Result = dbResponse;
                apiResponse.ProductViewModelList = result;
            }
            catch (Exception ex)
            {

                dbResponse.SetError(1, ex.Message.ToString());
                apiResponse.Result = dbResponse;
            }
            return apiResponse;
        }

        /// <summary>
        /// Create a specific Product.
        /// </summary>
        // POST api/<ProductController>
         
        [HttpPost]
        
        public ApiResponse Post([FromBody] ProductViewModel model)
        {
            ApiResponse apiResponse = new ApiResponse();
            DbResponse dbResponse = new DbResponse();
            try
            {
                Product data = mapper.Map<Product>(model);
                dbResponse = business.InsertUpdate(data);
                apiResponse.Result = dbResponse;
            }
            catch (Exception ex)
            {

                dbResponse.SetError(1, ex.Message.ToString());
                apiResponse.Result = dbResponse;
            }
            return apiResponse;
        }

        /// <summary>
        /// Update a specific Product.
        /// </summary>
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]

        public ApiResponse Put(int id, [FromBody] ProductViewModel model)
        {

            ApiResponse apiResponse = new ApiResponse();
            DbResponse dbResponse = new DbResponse();
            try
            {
                if (id == model.PId)
                {
                    Product data = mapper.Map<Product>(model);
                    dbResponse = business.InsertUpdate(data);
                    apiResponse.Result = dbResponse;
                }
                else
                {
                    dbResponse.SetError(1, "Invalid Id!");
                    apiResponse.Result = dbResponse;
                }

            }
            catch (Exception ex)
            {

                dbResponse.SetError(1, ex.Message.ToString());
                apiResponse.Result = dbResponse;
            }
            return apiResponse;

        }

        /// <summary>
        /// Deletes a specific Product.
        /// </summary>
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]

        public ApiResponse Delete(int id)
        {

            ApiResponse apiResponse = new ApiResponse();
            DbResponse dbResponse = new DbResponse();
            try
            {
                dbResponse = business.Delete(id);
                apiResponse.Result = dbResponse;

            }
            catch (Exception ex)
            {

                dbResponse.SetError(1, ex.Message.ToString());
                apiResponse.Result = dbResponse;
            }
            return apiResponse;
        }
    }
}
