using System;

using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs
{
    public class AddAdressCommand: ICommand
    {
        public Guid Id { get; set; }
        public string Street { get;  set; }

        public string Number { get; set; }

        public string Complement { get;  set; }

        public string District { get;  set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country  { get; set; }

        public string ZipCode { get; set; }

        public EAdressType Type { get; set; }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}