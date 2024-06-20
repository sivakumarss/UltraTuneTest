using UltraTuneTest.Server.Abstractions;

namespace UltraTuneConsole;
//Question 9 Implementation
internal class UltraTuneExternalService
{
    public IShoppingCart _cart;
    public IOrder _order;
    public IDiscountManager _discount;


    public UltraTuneExternalService(IShoppingCart cart, IOrder order, IDiscountManager discount)
    {
        _cart = cart;
        _order = order;
        _discount = discount;
    }

    public void AddingProduct()
    {
        _cart.CreateProduct();
    }

    
    public void ApplyDiscountsByPercentage()
    {
        _discount.DiscountedProductsByPercentage();
    }

    
    public void ApplyDiscountsByFixedAmount()
    {
        //Question 10
        _discount.DiscountedProductsByFixedAmount(fixedDiscount: 20, productNames: ["Car Wash", "Car mat"]);
    }

    public void CreateOrder()
    {
        _order.CreateOrder("Car Wash");
    }

    public void DisplayOrderDetails()
    {
        _order.DisplayOrderDetails();
    }

}
