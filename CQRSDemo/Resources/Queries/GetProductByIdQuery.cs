using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Queries
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
    }
}
