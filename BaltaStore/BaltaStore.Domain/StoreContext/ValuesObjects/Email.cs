using FluentValidator;

namespace BaltaStore.Domain.StoreContext.ValuesObjects
{
    public class Email: Notifiable
    {
        public Email(string adress)
        {
            Adress = adress;
        }

        public string Adress { get; set; }

        public override string ToString(){
            return Adress;
        }


    }
}