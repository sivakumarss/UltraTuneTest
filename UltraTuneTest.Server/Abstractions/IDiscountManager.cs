using UltraTuneTest.Server.Entities;

namespace UltraTuneTest.Server.Abstractions;

public interface IDiscountManager
{
    List<Product> DiscountedProductsByPercentage();
    List<Product> DiscountedProductsByFixedAmount(decimal fixedDiscount, string[] productNames);
}