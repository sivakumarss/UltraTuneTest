using System.Xml.Linq;
using UltraTuneTest.Server.Abstractions;
using UltraTuneTest.Server.Entities;
using UltraTuneTest.Server.Infrastructure;

namespace UltraTuneTest.Server.Operations;
//Question 7 Implementation
public class Order : IOrder
{
    public IShoppingCart _cart;

    public List<ProductQuantity> ProductOrders { get; set; }

    public Order(IShoppingCart cart)
    {
        _cart = cart;
    }


    public ProductQuantity CreateOrder(string productName)
    {
        ProductQuantity productQuantity = new();

        var product = _cart.GetProductsByName(productName).FirstOrDefault();

        productQuantity.Quantity = 1;
        productQuantity.Price = product.Price;
        productQuantity.Name = product.Name;
        productQuantity.Id = product.Id;

        ProductOrders.Add(productQuantity);
        return productQuantity;
    }

    public decimal CalculateTotalPrice()
    {
        var totalPrice = 0.0M;

        totalPrice += CreateOrder("Car Wash").Price;
        totalPrice += CreateOrder("Car Mat").Price;
        totalPrice += CreateOrder("Engine oil").Price;


        return totalPrice;
    }



    public void DisplayOrderDetails()
    {
        ProductOrders.ForEach(o =>
        {
            Console.WriteLine($"The Product details => /n Id: {o.Id}, Name: {o.Name}, Price: {o.Price}");
        });
        Console.WriteLine($"Total Price: {CalculateTotalPrice}");
    }
}
