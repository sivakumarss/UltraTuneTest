﻿using System.Linq;
using UltraTuneTest.Server.Abstractions;
using UltraTuneTest.Server.Entities;
using UltraTuneTest.Server.Infrastructure;

namespace UltraTuneTest.Server.Operations;

public class DiscountManager : IDiscountManager
{
    public IShoppingCart _cart;

    public DiscountManager(IShoppingCart cart)
    {
        _cart = cart;
    }

    //Question 5 Implementation 
    public List<Product> DiscountedProductsByPercentage()
    {
        List<Product> discountProducts = new();

        var products = _cart.GetProducts();

        var percentage = decimal.Parse(ApplicationConfiguration.GetValueByKey(Constant.DiscountPercentage));

        if (products.Any(p => p.Price > decimal.Parse(Constant.ThresholdPrice)))
        {
            products.ForEach(p =>
            {
                p.Price = p.Price * percentage / 100;
                discountProducts.Add(p);
            });
        }

        return discountProducts;
    }

    //Question 10 Implementation
    public List<Product> DiscountedProductsByFixedAmount(decimal fixedDiscount, string[] productNames)
    {
        List<Product> discountProducts = new();

        var products = _cart.GetProducts();

        products.ForEach(p =>
        {
            if (productNames.Any(n => n == p.Name))
            {
                p.Price = p.Price * fixedDiscount / 100;
                discountProducts.Add(p);
            }

        });

        return discountProducts;
    }

}
