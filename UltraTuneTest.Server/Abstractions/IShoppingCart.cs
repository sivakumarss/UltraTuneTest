using UltraTuneTest.Server.Entities;

namespace UltraTuneTest.Server.Abstractions;

public interface IShoppingCart
{
    Product CreateProduct();
    void DeleteProduct(Guid productId);
    List<Product> GetProducts();

    decimal GetTotalPrice();
    List<Product> GetProductsByName(string name);
    List<Product> GetProductsByPriceRange(decimal minPrice , decimal maxPrice);

    Task SaveProductsToFileAsync();
    Task LoadProductsFromFileAsync();

}
