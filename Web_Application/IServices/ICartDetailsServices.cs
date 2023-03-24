using Web_Application.Models;

namespace Web_Application.IServices
{
  public interface ICartDetailsServices
  {
    public bool CreateNewCartDetails(CartDetail CartDetail);
    public bool UpdateCartDetail(CartDetail CartDetail);
    public bool DeleteCartDetail(Guid id);
    public CartDetail GetCartDetailById(Guid id);
    // public List<CartDetail> GetCartDetailByName(string name);
    public List<CartDetail> GetAllCartDetails();
  }
}
