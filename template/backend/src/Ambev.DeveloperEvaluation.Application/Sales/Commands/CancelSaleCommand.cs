﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public record CancelSaleCommand(Guid SaleId) : IRequest;
}
