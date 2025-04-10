namespace Updating.Progress.Asynchronously
{
    public class CheckoutService
    {
        public async ValueTask<string> StartAsync(CheckoutRequest request)
        {
            return
                $"Checkout Complete for Shopping " +
                $"Basket: {request.ShoppingCartID}";
        }
    }
}
