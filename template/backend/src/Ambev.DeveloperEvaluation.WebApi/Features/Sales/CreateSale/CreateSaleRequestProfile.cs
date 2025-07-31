using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestProfile : Profile
    {
        public CreateSaleRequestProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>();
            CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        }
    }
}
