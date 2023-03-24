using Web_Application.Models;

namespace Web_Application.IServices
{
  public interface ICartServices
  {
    public bool CreateNewCarts(Cart Cart);
    public bool UpdateCart(Cart Cart);
    public bool DeleteCart(Guid id);
    public Cart GetCartById(Guid id);
    // public List<Cart> GetCartByName(string name);
    public List<Cart> GetAllCarts();
  }
}
