using AS.FOS.App.Common.Application.Events;
using AS.FOS.App.Common.Events.Topics;
using AS.FOS.Order.Infrastructure.Messaging.Consumer;
using AS.FOS.Order.Infrastructure.Messaging.Publisher;
using AS.FOS.Order.Infrastructure.Saga.Machine;
using AS.FOS.Order.Saga;
using AS.FOS.Order.Saga.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AS.FOS.Order.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddScoped<IEventPublisher, MassTransitEventPublisher>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<PaymentFailedConsumer>();
            x.AddConsumer<PaymentSucceededConsumer>();
            x.SetKebabCaseEndpointNameFormatter();

            x.AddSagaStateMachine<OrderStateMachine, OrderState>()
            .AddSagaEntityFramework(config);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(config["RabbitMq:Host"], h =>
                {
                    h.Username(config["RabbitMq:Username"]!);
                    h.Password(config["RabbitMq:Password"]!);
                });

                cfg.ConfigureEndpoints(context);

                cfg.ReceiveEndpoint(Topics.PaymentOrderPaymentResponseTopic,evt =>
                {
                    evt.ConfigureConsumer<PaymentFailedConsumer>(context);
                    evt.ConfigureConsumer<PaymentSucceededConsumer>(context);
                });
            });
        });

        return services;
    }
}
