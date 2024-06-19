namespace UltraTuneTest.Server.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    #region Public methods
    public void DisplayDetails()
    {
        Console.WriteLine($"The Product details => /n Id: {Id}, Name: {Name}, Price: {Price}");
    }
    #endregion

}
