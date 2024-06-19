using System;


namespace UltraTuneTest.Server.Infrastructure;

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
