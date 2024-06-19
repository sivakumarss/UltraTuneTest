using UltraTuneTest.Server.Abstractions;
using UltraTuneTest.Server.Entities;
using UltraTuneTest.Server.Infrastructure;

namespace UltraTuneTest.Server.Operations;

public class DiscountManager
{
    public IShoppingCart _cart;

    public DiscountManager(IShoppingCart cart)
    {
        _cart = cart;
    }

    public List<Product> DiscountedProducts()
    {
        List<Product> discountProducts = new();

        var products = _cart.GetProducts();

        var percentage = decimal.Parse(ApplicationConfiguration.GetValueByKey(Constant.DiscountPercentage));

        if(products.Any(p => p.Price > decimal.Parse(Constant.ThresholdPrice)))
        {
            products.ForEach(p =>
            {
                p.Price = p.Price * percentage / 100;
                discountProducts.Add(p);
            });
        }

        return discountProducts;
    }

}
