using Web_Application.Models;
namespace Web_Application.IServices
{
  public interface IBillDetailsServices
  {
    public bool CreateNewBillDetails(BillDetails BillDetails);
    public bool UpdateBillDetails(BillDetails BillDetails);
    public bool DeleteBillDetails(Guid id);
    public BillDetails GetBillDetailsById(Guid id);
    // public List<BillDetails> GetBillDetailsByName(string name);
    public List<BillDetails> GetAllBillDetails();
  }
}
