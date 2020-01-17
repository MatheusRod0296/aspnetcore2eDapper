using FluentValidator;

namespace BaltaStore.Domain.StoreContext.ValuesObjects
{
    public class Document: Notifiable
    {
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }

        public override string ToString(){
            return Number;
        }

    }
}