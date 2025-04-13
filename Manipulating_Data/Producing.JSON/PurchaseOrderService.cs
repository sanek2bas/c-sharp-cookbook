using System.Text.Json;

public class PurchaseOrderService
{
    public void View(PurchaseOrder po)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string poJson = JsonSerializer.Serialize(po, jsonOptions);
        //send http request
        Console.WriteLine(poJson);
    }
}