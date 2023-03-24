using Web_Application.Models;

namespace Web_Application.IServices
{
  public interface IProductServices
  {
    public bool CreateNewProducts(Product product);
    public bool UpdateProduct(Product product);
    public bool DeleteProduct(Guid id);
    public Product GetProductById(Guid id);
    public List<Product> GetProductByName(string name);
    public List<Product> GetAllProducts();
  }
}
