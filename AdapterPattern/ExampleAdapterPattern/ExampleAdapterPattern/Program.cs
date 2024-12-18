﻿// See https://aka.ms/new-console-template for more information
public interface ITarget
{
    string GetRequest();
}

class Adapter : ITarget
{
    private readonly Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }
    public string GetRequest()
    {
        return $"This is '{this.adaptee.GetSpecificRequest()}'";
    }
}

class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine("Adaptee interface is incompatible with the client.");
        Console.WriteLine("But with adapter client can call it's method.");

        Console.WriteLine(target.GetRequest());
    }
}
