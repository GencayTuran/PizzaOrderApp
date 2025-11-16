using System.ComponentModel.DataAnnotations;

namespace Application.Data
{
    public class PizzaOrderDto
    {
        public ClientDto Client { get; set; } = new ClientDto();

        public IEnumerable<PizzaDto> Pizzas { get; set; } = [];

        public DeliveryDto Delivery { get; set; } = new DeliveryDto();
    }
}