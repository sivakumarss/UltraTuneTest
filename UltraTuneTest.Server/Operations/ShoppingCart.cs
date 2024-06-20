using System.Text.Json;
using UltraTuneTest.Server.Abstractions;
using UltraTuneTest.Server.Entities;
using UltraTuneTest.Server.Infrastructure;

namespace UltraTuneTest.Server.Operations;

public class ShoppingCart : IShoppingCart
{

    //Question 2 Implementation  -- Start

    public Product CreateProduct()
    {
        //Here just added a dummy record.
        Product product = new()
        {
            Id = Guid.NewGuid(),
            Name = "Car Wax",
            Price = 19.90M
        };

        try
        {
            var products = GenerateDummyProductList();
            // In Reality it will call a repository method to connect to DB or other Data sources



            if (products.Any(p => p.Id != product.Id))
            {
                products.Add(product);
            }
            else
            {
                throw new DuplicateProductException(); //Question 3 Implementation 
            }

        }
        catch (Exception)
        {

            throw;
        }


        return product;
    }

    public void DeleteProduct(Guid productId)
    {
        var products = new List<Product>();
        // In Reality it will call a repository method to connect to DB or other Data sources

        products.Remove(products.FirstOrDefault(p => p.Id == productId));
    }

    public List<Product> GetProducts()
    {

        return GenerateDummyProductList();
    }

    //Question 2 Implementation  -- End

    //----------------------------------------------------------------------------

    //Question 4 Implementation 
    public decimal GetTotalPrice()
    {
        var totalPrice = 0.0M;
        var products = GetProducts();

        products.ForEach(product =>
        {
            totalPrice += product.Price;
        });


        return totalPrice;
    }


    public List<Product> GetProductsByName(string name)
    {
        return GetProducts().Where(p => p.Name == name).ToList();
    }
    //Question 6 Implementation these two methods above and below
    public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return GetProducts().Where(p => p.Price > minPrice && p.Price < maxPrice).ToList();
    }



    public async Task SaveProductsToFileAsync()
    {
        var products = GetProducts();

        await using FileStream createStream = File.Create(Constant.FileName);
        await JsonSerializer.SerializeAsync(createStream, products);

    }
    //Question 8 Implementation these two methods above and below
    public async Task LoadProductsFromFileAsync()
    {
        List<Product> products = new();
        using FileStream openStream = File.OpenRead(Constant.FileName);
        products = await JsonSerializer.DeserializeAsync<List<Product>>(openStream);
    }


    #region Private Methods

    private List<Product> GenerateDummyProductList()
    {
        var products = new List<Product>();
        products.Add(new Product { Id = Guid.NewGuid(), Name = "Car Wash", Price = 12.50M });
        products.Add(new Product { Id = Guid.NewGuid(), Name = "Car Mat", Price = 69.90M });

        return products;
    }
    #endregion


}
