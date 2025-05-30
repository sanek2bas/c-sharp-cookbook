﻿namespace Performing.Left.Joins
{
    public class InMemoryContext
    {
        List<SalesPerson> salesPeople =
            new List<SalesPerson>
            {
                new SalesPerson
                {
                    ID = 1,
                    Address = "123 1st Street",
                    City = "First City",
                    Name = "First Person",
                    PostalCode = "45678",
                    Region = "Region #1",
                    ProductType = "Type 2"
                },
                new SalesPerson
                {
                    ID = 2,
                    Address = "234 2nd Street",
                    City = "Second City",
                    Name = "Second Person",
                    PostalCode = "56789",
                    Region = "Region #2",
                    ProductType = "Type 3"
                },
                new SalesPerson
                {
                    ID = 3,
                    Address = "345 3rd Street",
                    City = "Third City",
                    Name = "Third Person",
                    PostalCode = "67890",
                    Region = "Region #3",
                    ProductType = "Type 1"
                },
                new SalesPerson
                {
                    ID = 3,
                    Address = "678 9th Street",
                    City = "Fourth City",
                    Name = "Fourth Person",
                    PostalCode = "90123",
                    Region = "Region #1",
                    ProductType = "Type 2"
                }
            };

        List<Product> products =
            new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Product 1",
                    Price = 123.45m,
                    Type = "Type 2",
                    Region = "Region #1"
                },
                new Product
                {
                    ID = 2,
                    Name = "Product 2",
                    Price = 456.78m,
                    Type = "Type 2",
                    Region = "Region #2"
                },
                new Product
                {
                    ID = 3,
                    Name = "Product 3",
                    Price = 789.10m,
                    Type = "Type 3",
                    Region = "Region #1"
                },
                new Product
                {
                    ID = 4,
                    Name = "Product 4",
                    Price = 234.56m,
                    Type = "Type 2",
                    Region = "Region #1"
                }
            };

        public List<SalesPerson> SalesPeople => salesPeople;
        public List<Product> Products => products;
    }
}
