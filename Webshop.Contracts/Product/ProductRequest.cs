namespace Webshop.Contracts.Product;

public record ProductRequest(
    string Name,
    decimal Price,
    List<string> Descriptions
);