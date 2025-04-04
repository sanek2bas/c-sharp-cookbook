﻿using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public static ServiceProvider Container;

    readonly Lazy<InvoiceRepository> InvoiceRep =
        new Lazy<InvoiceRepository>();

    readonly Lazy<IInvoiceRepository> InvoiceRepFactory =
        new Lazy<IInvoiceRepository>(CreateInvoiceRepositoryInstance);

    readonly Lazy<IInvoiceRepository> InvoiceRepIoC =
        new Lazy<IInvoiceRepository>(CreateInvoiceRepositoryFromIoC);

    private static IInvoiceRepository CreateInvoiceRepositoryInstance()
    {
        return new InvoiceRepository();
    }

    private static IInvoiceRepository CreateInvoiceRepositoryFromIoC()
    {
        return Container.GetRequiredService<IInvoiceRepository>();
    }

    static void Main()
    {
        Container = new ServiceCollection().
                        AddTransient<IInvoiceRepository, InvoiceRepository>().
                        BuildServiceProvider();
        new Program().Run();
    }

    void Run()
    {
        IInvoiceRepository viaLazyDefault = InvoiceRep.Value;
        viaLazyDefault.AddInvoiceCategory("Via Lazy Default \n");

        IInvoiceRepository viaLazyFactory = InvoiceRepFactory.Value;
        viaLazyFactory.AddInvoiceCategory("Via Lazy Factory \n");

        IInvoiceRepository viaLazyIoC = InvoiceRepIoC.Value;
        viaLazyIoC.AddInvoiceCategory("Via Lazy IoC \n");
    }
}