using System.ComponentModel.DataAnnotations;

namespace PizzaOrderFunctionApp.Data
{
    internal class DeliveryDto
    {
        [Required]
        public int DeliveryType { get; set; }

        public DateTime? DeliveryDateTime { get; set; } //empty datetime = asap delivery
    }
}