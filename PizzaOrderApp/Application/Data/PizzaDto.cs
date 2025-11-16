using System.ComponentModel.DataAnnotations;

namespace Application.Data
{
    public class PizzaDto
    {
        public int PizzaType { get; set; }

        public int PizzaSize { get; set; }

        public string[] Extras { get; set; } = [];
    }
}