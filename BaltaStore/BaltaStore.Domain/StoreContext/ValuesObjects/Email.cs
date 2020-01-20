using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValuesObjects
{
    public class Email: Notifiable
    {
        public Email(string adress)
        {
            Adress = adress;

             AddNotifications( new ValidationContract()
             .Requires()
             .IsEmail(Adress, "Email", "O email é invalido")
           );
        }

        public string Adress { get; set; }

        public override string ToString(){
            return Adress;
        }


    }
}