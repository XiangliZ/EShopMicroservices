
using FluentValidation;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto Order)
    : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrdeerCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrdeerCommandValidator()
    {
        RuleFor(x=>x.Order.OrderName).NotEmpty().WithMessage("Name is requierd");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is requierd");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}