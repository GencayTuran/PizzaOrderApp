using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PizzaOrderFunctionApp;

public class ProcessPizzaOrderFunction
{
    private readonly ILogger<ProcessPizzaOrderFunction> _logger;

    public ProcessPizzaOrderFunction(ILogger<ProcessPizzaOrderFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ProcessPizzaOrderFunction))]
    public async Task Run(
        [ServiceBusTrigger("myqueue", Connection = "")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}