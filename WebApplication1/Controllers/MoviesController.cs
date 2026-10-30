using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class MoviesController : Controller
{
    // GET
    public IActionResult Random()
    {
        var movie = new Movie() { Name = "Random Movie" };
        var customersList = new List<Customer>
        {
            new Customer { Name = "Arnold", IsSubscribedToNewsletter = true },
            new Customer { Name = "Černý", IsSubscribedToNewsletter = false },
            new Customer { Name = "Negr", IsSubscribedToNewsletter = true }
        };

        var viewModel = new randomMovieViewModel
        {
            Movie = movie,
            CustomerList = customersList
        };
        
        return View(viewModel);
    }
}