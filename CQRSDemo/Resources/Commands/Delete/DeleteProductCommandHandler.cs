using CQRSDemo.Data;
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly ProductDbContext _context;

        public DeleteProductCommandHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if(product is null)
            {
                return default;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
