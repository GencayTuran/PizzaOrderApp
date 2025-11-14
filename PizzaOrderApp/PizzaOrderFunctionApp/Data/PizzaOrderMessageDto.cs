using System.ComponentModel.DataAnnotations;

namespace PizzaOrderFunctionApp.Data
{
    internal class PizzaOrderMessageDto
    {
        [Required]
        internal ClientDto Client { get; set; } = new ClientDto();

        [Required]
        internal IEnumerable<PizzaDto> Pizzas { get; set; } = [];

        [Required]
        internal DeliveryDto Delivery { get; set; } = new DeliveryDto();
    }
}