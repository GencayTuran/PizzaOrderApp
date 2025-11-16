using System.ComponentModel.DataAnnotations;

namespace Application.Data
{
    public class DeliveryDto
    {
        public int DeliveryType { get; set; }

        public DateTime? DeliveryDateTime { get; set; } //empty datetime = asap delivery
    }
}