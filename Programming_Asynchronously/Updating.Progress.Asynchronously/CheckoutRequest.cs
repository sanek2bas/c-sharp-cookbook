﻿namespace Updating.Progress.Asynchronously
{
    public class CheckoutRequest
    {
        public Guid ShoppingCartID { get; set; }

        public string Name { get; set; }

        public string Card { get; set; }

        public string Address { get; set; }
    }
}
