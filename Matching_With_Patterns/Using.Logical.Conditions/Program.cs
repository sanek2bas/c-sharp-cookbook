﻿using Using.Logical.Conditions;

internal class Program
{
    const int SilverPoints = 5000;
    const int GoldPoints = 20000;

    const int May = 5;
    const int Sep = 9;
    const int Dec = 12;

    private static void Main(string[] args)
    {
        foreach (var customer in GetCustomers())
        {
            decimal discount = GetDiscount(customer);
            Console.WriteLine(discount);
        }
    }

    private static List<Customer> GetCustomers() =>
        new List<Customer>
        {
            new Customer
            {
                Points = 25000,
                Month = 1
            },
            new Customer
            {
                Points = 10000,
                Month = 12
            },
            new Customer
            {
                Points = 10000,
                Month = 11
            },
            new Customer
            {
                Points = 1000,
                Month = 2
            }
        };

    private static decimal GetDiscount(Customer customer) =>
        (customer.Points, customer.Month) switch
        {
            ( >= GoldPoints, not Dec and > Sep or < May) => 0.15m,
            ( >= GoldPoints, Dec) => 0.10m,
            ( >= SilverPoints, not (Dec or <= Sep and >= May)) => 0.05m,
            _ => 0.0m
        };
}