using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Resources.Queries
{
    public class GetAllProductsQuery: IRequest<IEnumerable<Product>>
    {
       
    }
}
