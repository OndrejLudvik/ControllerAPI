using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class MoviesController : Controller
{
    // GET
    public IActionResult Random()
    {
        var movie = new Movie() { Id = 1, Name = "Random Movie" };
        var customersList = new List<Customer>
        {
            new Customer(1,"Arnold"),
            new Customer(2,"beneš"),
            new Customer(3,"Arasdsanold"),
        };

        var viewModel = new randomMovieViewModel
        {
            Movie = movie,
            CustomerList = customersList
        };
        
        return View(viewModel);
    }
}