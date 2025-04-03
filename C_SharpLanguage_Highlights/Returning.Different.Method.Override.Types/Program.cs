﻿internal class Program
{
    private static void Main(string[] args)
    {
        Communications comm = new();
        MailingAddress mailAddr = comm.GetAddress("Person A");
        Console.WriteLine(mailAddr);
        Shipping ship = new();
        ShippingAddress shipAddr = ship.GetAddress("Person B");
        Console.WriteLine(shipAddr);
    }
}