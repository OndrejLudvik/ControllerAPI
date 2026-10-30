using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class CustomersController : Controller
{
    readonly TheatreDb _context;
    public CustomersController(TheatreDb context)
    {
        _context = context;
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    public IActionResult Index()
    {
        var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        return View(customers);
    }

    public IActionResult Details(int? id)
    {
        var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        if (customer == null) 
            return NotFound();
        
        return View(customer);
    }

    public IActionResult New()
    {
        var membershipTypes = _context.MembershipType.ToList();
        var viewModel = new CustomerFormViewModel
        {
            Customer = new Customer(),
            MembershipTypes = membershipTypes
        };
        
        return View("CustomerForm", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Customer customer)
    {
        if (customer.Id == 0)
           await _context.Customers.AddAsync(customer);
        else
        {
            var existingCustomer = await _context.Customers.SingleAsync(c => c.Id == customer.Id);
            existingCustomer.Name =  customer.Name; 
            existingCustomer.IsSubscribedToNewsletter =  customer.IsSubscribedToNewsletter;
            existingCustomer.MembershipType =  customer.MembershipType;
            existingCustomer.MembershipTypeId =  customer.MembershipTypeId;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Customers");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        if (customer == null)
            return NotFound();
        var viewModel = new CustomerFormViewModel
        {
            Customer = customer,
            MembershipTypes = _context.MembershipType.ToList()
        };
        
        return View("CustomerForm", viewModel);
    }
}