using Application.Data;
using Application.Services;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace PizzaOrderFunctionApp;

public class PizzaOrderFunction(
    ILogger<PizzaOrderFunction> logger,
    PizzaOrderService pizzaOrderService)
{
    private readonly ILogger<PizzaOrderFunction> _logger = logger;
    private readonly PizzaOrderService _pizzaOrderService = pizzaOrderService;

    [Function(nameof(PizzaOrderFunction))]
    public async Task Run(
        [ServiceBusTrigger("orderqueue1", Connection = "ServiceBusConnection")]
        ServiceBusReceivedMessage serviceBusMessage,
        ServiceBusMessageActions messageActions)
    {
        try
        {
            if (string.IsNullOrEmpty(serviceBusMessage.ToString()))
                throw new ArgumentNullException(nameof(serviceBusMessage));

            await _pizzaOrderService.ProcessPizzaOrder(serviceBusMessage.ToString());

            await messageActions.CompleteMessageAsync(serviceBusMessage);
            _logger.LogInformation($"Completed ServiceBus Message with ID {serviceBusMessage.MessageId} .");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            await messageActions.DeadLetterMessageAsync(serviceBusMessage);
        }
    }
}