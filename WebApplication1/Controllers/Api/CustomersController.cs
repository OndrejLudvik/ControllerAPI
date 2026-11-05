using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly TheatreDb _context;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper,TheatreDb context)
        {
            _context = context;
            _mapper = mapper;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>>  GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers.Select(_mapper.Map<Customer, CustomerDto>));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Created($"api/customers/{customer.Id}", _mapper.Map<Customer, CustomerDto>(customer));
        }
        

        [HttpPut]
        public async Task<ActionResult<CustomerDto>> PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (existingCustomer == null)
                return NotFound();
                
            _mapper.Map(customerDto, existingCustomer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(int id)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (existingCustomer == null)
                return  NotFound();

            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}