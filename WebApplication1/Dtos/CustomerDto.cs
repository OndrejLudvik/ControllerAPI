using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Dtos;

public class CustomerDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a name")]
    [StringLength(50)]
    public string Name { get; set; }
    
    public bool IsSubscribedToNewsletter { get; set; }

    public byte MembershipTypeId { get; set; }
    
    //[Min18IfMember]
    public DateOnly? BirthDate { get; set; }
}