using System.ComponentModel.DataAnnotations;

namespace PizzaOrderFunctionApp.Data
{
    internal class PizzaDto
    {
        [Required]
        internal int PizzaType { get; set; }

        [Required]
        internal int PizzaSize { get; set; }

        internal string[] Extras { get; set; } = [];
    }
}