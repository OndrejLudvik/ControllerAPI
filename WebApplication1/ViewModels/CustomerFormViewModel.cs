using WebApplication1.Models;

namespace WebApplication1.ViewModels;

public class CustomerFormViewModel
{
    public IEnumerable<MembershipType> MembershipTypes { get; set; }
    public Customer Customer { get; set; }
}