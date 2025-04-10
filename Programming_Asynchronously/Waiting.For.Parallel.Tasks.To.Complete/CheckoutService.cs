namespace Waiting.For.Parallel.Tasks.To.Complete
{
    public class CheckoutService
    {
        public async Task<string> StartAsync()
        {
            var checkoutTasks =
            new List<Task<(string, bool)>>
            {
                ValidateAddressAsync(),
                ValidateCreditAsync(),
                GetShoppingCartAsync()
            };

            Task<(string method, bool result)[]> allTasks =
                Task.WhenAll(checkoutTasks);

            if (allTasks.IsCompletedSuccessfully)
            {
                WhenAllResult whenAllResult = GetResultsAsync(allTasks);
                await FinalizeCheckoutAsync(whenAllResult);
                return "Checkout Complete";
            }
            else
            {
                throw allTasks.Exception;
            }
        }

        private WhenAllResult GetResultsAsync(
            Task<(string method, bool result)[]> allTasks)
        {
            var whenAllResult = new WhenAllResult();
            foreach (var (method, result) in allTasks.Result)
                switch (method)
                {
                    case nameof(ValidateAddressAsync):
                        whenAllResult.IsValidAddress = result;
                        break;
                    case nameof(ValidateCreditAsync):
                        whenAllResult.IsValidCredit = result;
                        break;
                    case nameof(GetShoppingCartAsync):
                        whenAllResult.HasShoppingCart = result;
                        break;
                }
            return whenAllResult;
        }

        private async Task<(string, bool)> ValidateAddressAsync()
        {
            //throw new ArgumentException("Testing!");
            return await Task.FromResult(
                (nameof(ValidateAddressAsync), true));
        }

        private async Task<(string, bool)> ValidateCreditAsync()
        {
            return await Task.FromResult(
                (nameof(ValidateCreditAsync), true));
        }

        private async Task<(string, bool)> GetShoppingCartAsync()
        {
            return await Task.FromResult(
                (nameof(GetShoppingCartAsync), true));
        }

        private async Task<bool> FinalizeCheckoutAsync(WhenAllResult result)
        {
            Console.WriteLine(
                $"{nameof(WhenAllResult.IsValidAddress)}: " +
                $"{result.IsValidAddress}");
            Console.WriteLine(
                $"{nameof(WhenAllResult.IsValidCredit)}: " +
                $"{result.IsValidCredit}");
            Console.WriteLine(
                $"{nameof(WhenAllResult.HasShoppingCart)}: " +
                $"{result.HasShoppingCart}");
            bool success = true;
            return await Task.FromResult(success);
        }

        private class WhenAllResult
        {
            public bool IsValidAddress { get; set; }
            public bool IsValidCredit { get; set; }
            public bool HasShoppingCart { get; set; }
        }
    }
}
