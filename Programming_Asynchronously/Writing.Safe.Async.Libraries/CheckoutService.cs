namespace Writing.Safe.Async.Libraries
{
    public class CheckoutService
    {
        public async Task<string> StartAsync()
        {
            await ValidateAddressAsync().ConfigureAwait(false);
            await ValidateCreditAsync().ConfigureAwait(false);
            await GetShoppingCartAsync().ConfigureAwait(false);
            await FinalizeCheckoutAsync().ConfigureAwait(false);
            return "Checkout Complete";
        }

        private async Task ValidateAddressAsync()
        {
            // perform address validation
        }

        private async Task ValidateCreditAsync()
        {
            // ensure credit is good
        }

        private async Task GetShoppingCartAsync()
        {
            // get contents of shopping cart
        }

        private async Task FinalizeCheckoutAsync()
        {
            // complete checkout transaction
        }
    }
}
