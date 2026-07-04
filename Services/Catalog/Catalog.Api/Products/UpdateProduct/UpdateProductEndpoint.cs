namespace Catalog.Api.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (ISender sender, UpdateProductRequest request) => 
            {
                var command = new UpdateProductCommand(request.Id, request.Name, request.Category, request.Description, request.ImageFile, request.Price);

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            }).WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update product")
            .WithDescription("Update product");
        }
    }
}
