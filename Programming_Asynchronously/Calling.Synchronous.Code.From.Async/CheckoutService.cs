namespace Calling.Synchronous.Code.From.Async
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
        
        private async Task<bool> ValidateAddressAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        private async Task<bool> ValidateCreditAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        private async Task<bool> GetShoppingCartAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        private async Task FinalizeCheckoutAsync()
        {
            await Task.CompletedTask;
        }
    }
}
