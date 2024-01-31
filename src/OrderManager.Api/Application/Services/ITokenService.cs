using OrderManager.Api.Domain.AggregateModels.UserAggregate;

namespace OrderManager.Api.Application.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}