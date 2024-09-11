using BuildingBlocks.CQRS;
using Catalog.Api.Models;

namespace Catalog.Api.Features.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreteProductResult>;
public record CreteProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreteProductResult>
{
    public async Task<CreteProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        
        return new CreteProductResult(Guid.NewGuid());
    }
}