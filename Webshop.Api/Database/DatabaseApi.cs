namespace Webshop.Api.Database;
using Webshop.Api.Models;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.Json.Serialization;
using System.Text.Json;

public static class DatabaseApi
{
    static readonly string Path = "C:\\Users\\stoja\\PROJECTS\\Webshop\\Webshop.Api\\Database\\Products.txt";
    public static void WriteToFile(Product product)
    {
        if (!File.Exists(Path))
        {
            List<Product> products = [];
            products.Add(product);
            string productsJson = JsonSerializer.Serialize(products);
            File.WriteAllText(Path, productsJson);
        }
        else
        {
            string productJson = File.ReadAllText(Path);
            List<Product>? products = JsonSerializer.Deserialize<List<Product>>(productJson);
            products!.Add(product);
            string updatedProductsJson = JsonSerializer.Serialize(products);
            File.AppendAllText(Path, updatedProductsJson);
        }
    }

    public static Product? ReadFromFile(int id)
    {
        if (File.Exists(Path))
        {
            List<Product>? products = JsonSerializer.Deserialize<List<Product>>(Path);
            Product? product = products!.Find(item => item.Id == id);
            return product;
        }
        else return null;
    }
}