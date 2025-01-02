namespace Webshop.Api.Database;

using Webshop.Api.Models;
using System.IO;
using System.Text.Json;

public static class DatabaseApi
{
    public static List<Product>? GetListFromFile()
    {
        try
        {
            string listJson = File.ReadAllText(Path);
            return JsonSerializer.Deserialize<List<Product>>(listJson)!;
        }
        catch (Exception) { return null; }
    }
    private static readonly string Path = "C:\\Users\\stoja\\PROJECTS\\Webshop\\Webshop.Api\\Database\\Products.txt";
    public static void WriteOrUpdateToFile(Product product, string action)
    {
        if (!File.Exists(Path) || new FileInfo(Path).Length == 0)
        {
            try
            {

                List<Product> products = [];
                products.Add(product);
                string productsJson = JsonSerializer.Serialize(products);
                File.WriteAllText(Path, productsJson);
            }
            catch (Exception) { }
        }
        else
        {
            try
            {
                List<Product>? products = GetListFromFile();

                if (action == "CREATE")
                    products!.Add(product);
                else if (action == "UPDATE")
                {
                    int index = products!.FindIndex(item => item.Id == product.Id);
                    products[index] = product;
                }

                string updatedProductsJson = JsonSerializer.Serialize(products);
                File.WriteAllText(Path, updatedProductsJson);
            }
            catch (Exception) { }
        }
    }

    public static Product? ReadFromFile(int id)
    {
        if (File.Exists(Path))
        {
            try
            {
                List<Product>? products = GetListFromFile();
                Product? product = products!.Find(item => item.Id == id);
                return product;
            }
            catch (Exception) { return null; }
        }
        else return null;
    }

    public static void DeleteProduct(int id)
    {
        try
        {
            List<Product>? products = GetListFromFile();
            products?.RemoveAt(products.FindIndex(item => item.Id == id));
            File.WriteAllText(Path, JsonSerializer.Serialize(products));
        }
        catch (Exception) { }
    }

}