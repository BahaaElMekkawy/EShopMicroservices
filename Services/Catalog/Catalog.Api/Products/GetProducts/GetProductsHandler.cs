using Marten.Pagination;

namespace Catalog.Api.Products.GetProducts
{
    public record GetProductsQuery(int pageNumber , int pageSize ) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session )
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(query.pageNumber , query.pageSize ,cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
