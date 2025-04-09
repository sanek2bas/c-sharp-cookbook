using System;

namespace Creating.Async.Console.Applications;

public class CheckoutService
{
    public async Task<string> StartAsync()
    {
        await ValidateAddressAsync();
        await ValidateCreditAsync();
        await GetShoppingCartAsync();
        await FinalizeCheckoutAsync();
        
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
