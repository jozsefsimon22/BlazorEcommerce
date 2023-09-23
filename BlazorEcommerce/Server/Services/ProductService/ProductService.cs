namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;

        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = _context.Products.ToList();

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            var response = new ServiceResponse<Product>()
            {
                Data = product
            };

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not found.";
            }
            return response;
        }
    }
}
