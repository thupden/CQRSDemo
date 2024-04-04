using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Commands.Delete
{
    public class DeleteProductCommand: IRequest<Product>
    {
        public int Id { get; set; }
    }
}
