using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            #region Test
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreateDate = DateTime.UtcNow, Stock = 10 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 100, CreateDate = DateTime.UtcNow, Stock = 20 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 100, CreateDate = DateTime.UtcNow, Stock = 100 },
            //});
            //await _productWriteRepository.SaveAsync();
            //Product product = await  _productReadRepository.GetByIdAsync("39b81ff7-b31e-4bbf-a58d-fa456537af6c", false);
            //product.Name = "Doğan 2";
            //await _productWriteRepository.SaveAsync(); 
            #endregion

            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "asd" });

            await _orderWriteRepository.AddAsync(new() { Description = "Deneme", Adress = "asd", CustomerId = customerId });
            await _orderWriteRepository.SaveAsync();
        }


    }

}
