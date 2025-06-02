using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentApp.Cli;
using PaymentApp.Interfaces;
using PaymentApp.Services;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

services.AddSingleton<ICharger, CreditCardPayment>();
services.AddSingleton<IRefunder, CreditCardPayment>();
services.AddSingleton<ICharger, PayPalPayment>();
services.AddSingleton<IRefunder, PayPalPayment>();
services.AddSingleton<ICharger, BitcoinPayment>();

// Registrar UserNotifier
services.AddSingleton<IUserNotifier, UserNotifier>();

// Registrar OrderProvider
services.AddSingleton<IOrderProvider, SampleOrderProvider>();

services.AddSingleton<IPaymentRouter, PaymentRouter>();
services.AddSingleton<PaymentCli>();

using var host = builder.Build();
host.Services.GetRequiredService<PaymentCli>().Run(args);