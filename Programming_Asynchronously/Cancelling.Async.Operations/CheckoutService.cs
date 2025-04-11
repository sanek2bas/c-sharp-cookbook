public class CheckoutService
{
    public async ValueTask<string> StartAsync(CheckoutRequest request)
    {
        return await Task.FromResult(
            $"Checkout Complete for Shopping " +
            $"Basket: {request.ShoppingCartID}");
    }
}