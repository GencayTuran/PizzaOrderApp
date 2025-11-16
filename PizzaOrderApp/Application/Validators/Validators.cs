using Application.Data;
using FluentValidation;

namespace Application.Validators
{
    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator() 
        {
            RuleFor(client => client.FirstName).NotEmpty();
            RuleFor(client => client.LastName).NotEmpty();
            RuleFor(client => client.PhoneNumber).NotEmpty();
            RuleFor(client => client.EmailAddress).NotEmpty();
        }
    }

    public class DeliveryValidator : AbstractValidator<DeliveryDto> 
    {
        public DeliveryValidator()
        {
            RuleFor(d => d.DeliveryType).NotEmpty();
            RuleFor(d => d.DeliveryDateTime).GreaterThanOrEqualTo(DateTime.Now);
        }
    }

    public class PizzaValidator : AbstractValidator<PizzaDto>
    {
        public PizzaValidator()
        {
            RuleFor(p => p.PizzaType).NotEmpty();
            RuleFor(p => p.PizzaSize).NotEmpty();
        }
    }

    public class PizzaOrderValidator : AbstractValidator<PizzaOrderDto>
    {
        public PizzaOrderValidator()
        {
            RuleFor(p => p.Client).NotEmpty();
            RuleFor(p => p.Delivery).NotEmpty();
            RuleFor(p => p.Pizzas).NotEmpty();
        }
    }

}
