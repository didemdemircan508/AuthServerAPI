using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;
using UdemyAuthServer.Core.Services;

namespace UdemyAuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {

        private readonly IServiceGeneric<Product, ProductDto> _productservice;

        public ProductController(IServiceGeneric<Product,ProductDto> productService)
        {
            _productservice = productService;
        }

        [HttpGet]

        public async Task<IActionResult> GetProducts()
        { 

            return ActionResultInstance(await _productservice.GetAllAsync());

        
        }

        [HttpPost]

        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        { 
          return ActionResultInstance(await _productservice.AddAsync(productDto));

        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        { 
          return ActionResultInstance(await _productservice.Update(productDto,productDto.Id));

        }
        //api/product/2
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        { 
          return ActionResultInstance(await _productservice.Remove(id));
        }



    }
}
