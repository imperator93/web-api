using Microsoft.AspNetCore.Mvc;
using Webshop.Api.Models;
using Webshop.Contracts.Product;
using Webshop.Api.Database;
namespace Webshop.Api.Controllers;


[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("/products")]
    public IActionResult PostProduct(ProductRequest request)
    {
        Product product = new(id: 1, name: request.Name, price: request.Price, descriptions: request.Descriptions);
        DatabaseApi.WriteToFile(product);
        return Ok(product);
    }

    [HttpGet("/products/{id:int}")]
    public IActionResult GetPRoduct(int id)
    {
        Product? product = DatabaseApi.ReadFromFile(id);
        return Ok(product);
    }
}