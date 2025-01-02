namespace Webshop.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Webshop.Api.Models;
using Webshop.Contracts.Product;
using Webshop.Api.Database;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("/products")]
    public IActionResult PostProduct(ProductRequest request)
    {
        Product product = new(id: new Random().Next(0, 10000), name: request.Name, price: request.Price, descriptions: request.Descriptions);
        DatabaseApi.WriteOrUpdateToFile(product, "CREATE");

        ProductResponse response = new(Id: product.Id, Name: product.Name, Price: product.Price, Descriptions: product.Descriptions);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, response);
    }


    [HttpGet("/products")]
    public IActionResult GetAllProducts()
    {

        List<Product>? allProducts = DatabaseApi.GetListFromFile();
        List<ProductResponse> allProductsResponse = [];
        foreach (Product item in allProducts!)
        {
            ProductResponse response = new(Id: item.Id, Name: item.Name, Price: item.Price, Descriptions: item.Descriptions);
            allProductsResponse.Add(response);
        };
        return Ok(allProductsResponse);
    }

    [HttpGet("/products/{id:int}")]
    public IActionResult GetProduct(int id)
    {
        try
        {
            {
                Product? product = DatabaseApi.ReadFromFile(id);
                ProductResponse response = new(Id: product!.Id, Name: product.Name, Price: product.Price, Descriptions: product.Descriptions);
                return Ok(response);
            }
        }
        catch (Exception ex) { return Problem(JsonSerializer.Serialize(ex)); }
    }

    [HttpPut("products/{id:int}")]
    public IActionResult UpdateProduct(int id, ProductRequest request)
    {
        Product product = new(id, request.Name, request.Price, request.Descriptions);
        DatabaseApi.WriteOrUpdateToFile(product, "UPDATE");
        return Ok(product);
    }

    [HttpDelete("products/{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        DatabaseApi.DeleteProduct(id);
        var response = new
        {
            result = $"item with id: {id} deleted!"
        };
        return Ok(response);
    }
}