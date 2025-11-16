using Application.CustomExceptions;
using Application.Data;
using Application.Validators;
using FluentValidation.Results;
using System.Text.Json;

namespace Application.Services
{
    public class PizzaOrderService
    {
        /// <summary>
        /// Deserializes, Validates and finally sends the received order to the API.
        /// </summary>
        public async Task<IAsyncResult> ProcessPizzaOrder(string serviceBusMessage)
        {
            PizzaOrderDto pizzaOrderDto = DeserializeMessage(serviceBusMessage);
            
            if (!TryValidateDto(pizzaOrderDto, out IEnumerable<string> errors))
            {
                throw new ValidationException(errors); 
            }

            return await SendPizzaOrderAsync(pizzaOrderDto);
        }

        private static PizzaOrderDto DeserializeMessage(string serviceBusMessage)
        {
            return JsonSerializer.Deserialize<PizzaOrderDto>(serviceBusMessage.ToString())!;
        }

        private static bool TryValidateDto(PizzaOrderDto pizzaOrderDto, out IEnumerable<string> errors)
        {
            List<ValidationResult> validationResults = [];

            //collect ValidationResults
            validationResults.Add(new PizzaOrderValidator().Validate(pizzaOrderDto));
            validationResults.Add(new ClientValidator().Validate(pizzaOrderDto.Client));
            validationResults.Add(new DeliveryValidator().Validate(pizzaOrderDto.Delivery));

            foreach (PizzaDto pizzaDto in pizzaOrderDto.Pizzas)
            {
                validationResults.Add(new PizzaValidator().Validate(pizzaDto));
            }

            //populate the output parameter with possible ErrorMessages
            errors = validationResults.SelectMany(x => x.Errors.Select(x => x.ErrorMessage));

            return validationResults.All(result => result.IsValid);
        }

        private static Task<IAsyncResult> SendPizzaOrderAsync(PizzaOrderDto pizzaOrder)
        {
            throw new NotImplementedException();
        }
    }
}
