﻿
using FluentValidation;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order)
    :ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is requierd");
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is requierd");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is requierd");
    }
}
