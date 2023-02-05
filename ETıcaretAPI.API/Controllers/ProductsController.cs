using ETıcaretAPI.Application.Repositories;
using ETıcaretAPI.Application.ViewModels.Products;
using ETıcaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net;
using System.Net.WebSockets;

namespace ETıcaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        //private readonly IOrderWriteRepository _orderWriteRepository;
        //private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            //_orderWriteRepository = orderWriteRepository;
            //_customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new(){Id=Guid.NewGuid(), Name="Product 4", Price=100, CreatedDate=DateTime.UtcNow, Stock=10},
            //    new(){Id=Guid.NewGuid(), Name="Product 5", Price=200, CreatedDate=DateTime.UtcNow, Stock=20},
            //    new(){Id=Guid.NewGuid(), Name="Product 6", Price=300, CreatedDate=DateTime.UtcNow, Stock=30}


            //    });
            //Product p = await _productReadRepository.GetByIdAsync("8018d3d8-09a5-4a9d-9769-1da8b136b920");
            //p.Name = "Sema";
            //var count = await _productWriteRepository.SaveAsync();
            //await _productWriteRepository.AddAsync(new() { Name="C Product", Price= 1500F, Stock=10, CreatedDate= DateTime.UtcNow });
            //await _productWriteRepository.SaveAsync();
            /*var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Name = "SemaNur", Id= customerId });*/
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara "});
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara Pursaklar" });
            //await _orderWriteRepository.SaveAsync();
            //await _customerWriteRepository.SaveAsync();
            return Ok(_productReadRepository.GetAll(false));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    //IActionResult kullanma nedeni: Her tipte veri dönderir eğer döndereceğin
        //    //veri tipi belli değilse IActionResult kullanılmalıdır.
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return  Ok(await _productReadRepository.GetByIdAsync(id,false));
           
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }


    }
}
