using System.Reflection;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Webshop.Api.Models;

public class Product(int id, string name, decimal price, List<string> descriptions)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public decimal Price { get; } = price;
    public List<string> Descriptions { get; } = descriptions;
    public void Properties()
    {
        foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
        {
            System.Console.WriteLine($"{propertyInfo.Name}: {propertyInfo.GetValue(this)}");
        }
    }
}