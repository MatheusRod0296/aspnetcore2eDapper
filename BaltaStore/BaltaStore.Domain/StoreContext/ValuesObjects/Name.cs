using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValuesObjects
{
    public class Name: Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

           // new ValidationContract().Requires().Matchs("Nome",)

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }



    }
}