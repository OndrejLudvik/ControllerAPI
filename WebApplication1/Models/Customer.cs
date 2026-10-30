using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebApplication1.Models;

public class Customer 
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public bool IsSubscribedToNewsletter { get; set; }
    
    public MembershipType MembershipType { get; set; }
    
    [Display(Name = "Membership Type")]
    public byte MembershipTypeId { get; set; }

    
    
};