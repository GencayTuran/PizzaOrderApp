using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using PizzaOrderFunctionApp.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [ServiceBusTrigger("orderqueue1", Connection = "ServiceBusConnection")]
        ServiceBusReceivedMessage serviceBusMessage,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", serviceBusMessage.MessageId);
        _logger.LogInformation("Message Body: {body}", serviceBusMessage.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", serviceBusMessage.ContentType);

        try
        {
            if (string.IsNullOrEmpty(serviceBusMessage.ToString()))
                throw new ArgumentNullException(nameof(serviceBusMessage));

            //deserialize
            PizzaOrderMessageDto messageDto = JsonSerializer.Deserialize<PizzaOrderMessageDto>(serviceBusMessage.ToString())!;

            //send to service


            // Complete the message
            await messageActions.CompleteMessageAsync(serviceBusMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            await messageActions.DeadLetterMessageAsync(serviceBusMessage);
        }
    }
}