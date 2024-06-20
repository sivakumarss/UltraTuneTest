using System;


namespace UltraTuneTest.Server.Infrastructure;
//Question 3 Implementation 
public class DuplicateProductException : Exception
{
    public DuplicateProductException()
    {
    }

    public DuplicateProductException(string message)
        : base(message)
    {
    }

    public DuplicateProductException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
