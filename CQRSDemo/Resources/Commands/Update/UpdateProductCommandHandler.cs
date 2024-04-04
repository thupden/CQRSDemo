using CQRSDemo.Data;
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ProductDbContext _context;

        public UpdateProductCommandHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                return default;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Price = request.Price;

            await _context.SaveChangesAsync();

            return product;

        }
    }
}
