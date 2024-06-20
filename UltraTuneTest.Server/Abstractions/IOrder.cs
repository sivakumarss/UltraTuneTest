using UltraTuneTest.Server.Entities;

namespace UltraTuneTest.Server.Abstractions
{
    public interface IOrder
    {
        decimal CalculateTotalPrice();
        ProductQuantity CreateOrder(string productName);
        void DisplayOrderDetails();
    }
}