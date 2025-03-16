using Basket.API.Data;
using Basket.API.Models;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResult(ShoppingCart Cart);
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var baskte = await repository.GetBasket(query.UserName);
            return new GetBasketResult(baskte);
        }
    }
}
