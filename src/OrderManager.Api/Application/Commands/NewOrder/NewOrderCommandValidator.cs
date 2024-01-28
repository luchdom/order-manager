using FluentValidation;

namespace OrderManager.Api.Application.Commands.NewOrder;

public class NewOrderCommandValidator : AbstractValidator<NewOrderCommand>
{
    private NewOrderCommandValidator()
    {
        RuleFor(x => x.OrderItems).NotEmpty();
        RuleForEach(x => x.OrderItems)
            .Must((order, orderItem) => orderItem.Quantity > 0)
            .WithMessage("Order item quantity should be more than zero")
            .Must((order, orderItem) => orderItem.ProductId > 0)
            .WithMessage("Product is invalid");
    }

}
