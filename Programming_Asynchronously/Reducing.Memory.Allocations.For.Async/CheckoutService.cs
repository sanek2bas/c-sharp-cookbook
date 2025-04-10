namespace Reducing.Memory.Allocations.For.Async
{
    public class CheckoutService
    {
        public async ValueTask<string> StartAsync()
        {
            await ValidateAddressAsync();
            await ValidateCreditAsync();
            await GetShoppingCartAsync();
            await FinalizeCheckoutAsync();
            return "Checkout Complete";
        }

        private async ValueTask ValidateAddressAsync()
        {
            // perform address validation
        }

        private async ValueTask ValidateCreditAsync()
        {
            // ensure credit is good
        }
        
        private async ValueTask GetShoppingCartAsync()
        {
            // get contents of shopping cart
        }
        
        private async ValueTask FinalizeCheckoutAsync()
        {
            // complete checkout transaction
        }
    }
}
