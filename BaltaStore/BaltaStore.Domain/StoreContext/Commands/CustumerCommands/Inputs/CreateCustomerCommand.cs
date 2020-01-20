using BaltaStore.Shared.commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        //fail Fail validation
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
            .HasMinLen(FirstName, 3, nameof(FirstName), "O nome deve  conter pelo menso 3 caracteres")
            .HasMaxLen(FirstName, 40, nameof(FirstName), "O nome deve  conter menos de 40 caracteres")
            .HasMinLen(LastName, 3, nameof(LastName), "O sobrenome deve  conter pelo menso 3 caracteres")
            .HasMaxLen(LastName, 40, nameof(LastName), "O sobrenome deve  conter menos de 40 caracteres")
            .IsEmail(Email, "Email", "O email é invalido")
            .HasLen(Document, 11, "Document", "CPF Invalido")
         );

         return base.IsValid;

        }
    }
}