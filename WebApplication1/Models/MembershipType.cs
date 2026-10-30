namespace WebApplication1.Models;

public class MembershipType
{
    public byte Id { get; set; }

    public string Name { get; set; }
    
    public short SignUpfee { get; set; }
    
    public byte DurationInMonths { get; set; }
    
    public byte DiscountRate { get; set; }
    
    public ICollection<Customer> Customer { get; set; }
}