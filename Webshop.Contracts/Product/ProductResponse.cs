namespace Webshop.Contracts.Product;

public record ProductResponse(
    int Id,
    string Name,
    decimal Price,
    List<string> Descriptions
);