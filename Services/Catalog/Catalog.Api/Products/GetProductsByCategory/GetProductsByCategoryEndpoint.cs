namespace Catalog.Api.Products.GetProductsByCategory
{
    public record GetProductsByCategoryRequest();
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender,string category) => 
            {
                var query = new GetProductsByCategoryQuery(category);

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductsByCategoryResponse>();

                return Results.Ok(response);
            }).WithName("GetProductsByCategory")
            .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK) 
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get products by category")
            .WithDescription("Get products by category");
        }
    }
}
