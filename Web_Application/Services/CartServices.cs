using Web_Application.IServices;
using Web_Application.Models;

namespace Web_Application.Services
{
  public class CartServices : ICartServices
  {
    ShopDbContext _dbConText;
    public CartServices()
    {
      _dbConText = new ShopDbContext();
    }
    public bool CreateNewCarts(Cart Cart)
    {
      try
      {
        _dbConText.Carts.Add(Cart);
        _dbConText.SaveChanges();
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }

    public bool DeleteCart(Guid id)
    {
      try
      {
        var _Cart = _dbConText.Carts.Find(id);
        _dbConText.Carts.Remove(_Cart);
        _dbConText.SaveChanges();
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }
    public bool UpdateCart(Cart Cart)
    {
      try
      {
        var _Cart = _dbConText.Carts.Find(Cart.UserId);
        _Cart.Description = Cart.Description;
        _dbConText.Carts.Update(_Cart);
        _dbConText.SaveChanges();
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }
    public List<Cart> GetAllCarts()
    {
      return _dbConText.Carts.ToList();
    }

    public Cart GetCartById(Guid id)
    {
      return _dbConText.Carts.FirstOrDefault(p => p.UserId == id);
    }
  }
}
