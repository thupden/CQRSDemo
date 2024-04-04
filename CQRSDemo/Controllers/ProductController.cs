using CQRSDemo.Models;
using CQRSDemo.Resources.Commands.Create;
using CQRSDemo.Resources.Commands.Delete;
using CQRSDemo.Resources.Commands.Update;
using CQRSDemo.Resources.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return products;
        }

        [HttpGet("productId")]
        public async Task<Product> GetProductById(int productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = productId});
            return product;
        }

        [HttpPost]
        public async Task<Product> AddProductAsync(Product product)
        {
            var response = await _mediator.Send(new CreateProductCommand()
            {
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Active = product.Active,
                Price = product.Price,
            });

            return response;
        }

        [HttpPut]
        public async Task<Product> UpdateProductAsync(Product product)
        {
            var response = await _mediator.Send(new UpdateProductCommand()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Active = product.Active,
                Price = product.Price,
            });

            return response;
        }

        [HttpDelete]
        public async Task<Product> DeleteProductAsync(int productId)
        {
            var response = await _mediator.Send(new DeleteProductCommand() { Id = productId });

            return response;
        }
    }
}
