using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationApp.Cli;
using NotificationApp.Interfaces;
using NotificationApp.Services;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

services.AddSingleton<IEmailSender, EmailSender>();
services.AddSingleton<ISmsSender, SmsSender>();
services.AddSingleton<IPushSender, PushSender>();

services.AddSingleton<INotificationFacade, NotificationFacade>();

services.AddSingleton<OrderNotifyCli>();

using var host = builder.Build();
host.Services.GetRequiredService<OrderNotifyCli>().Run(args);