using System.ComponentModel.DataAnnotations;

namespace PizzaOrderFunctionApp.Data
{
    internal class ClientDto
    {
        [Required]
        internal string FirstName { get; set; } = "";

        [Required]
        internal string LastName { get; set; } = "";

        [Required]
        internal string PhoneNumber { get; set; } = "";

        [Required]
        internal string EmailAddress { get; set; } = "";
    }
}