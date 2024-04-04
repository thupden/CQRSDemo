using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Commands.Create
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; } = true;
        public decimal Price { get; set; }
    }
}
