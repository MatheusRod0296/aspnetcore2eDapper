using System;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValuesObjects;
using BaltaStore.Shared.commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
    Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAdressCommand>

    {
        public ICommandResult Handler(CreateCustomerCommand command)
        {
            //cpf existe na base

            //email existe na base

            //criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar entidade
            var customer = new Customer(name, document, email, command.Phone);

            //validar as entidades e Vos
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            //persistir

            //enviar Email boas vindas

            // retornar resultado para
            return new CreateCustomerCommandResult(Guid.NewGuid(), customer.Name.ToString(), customer.Email.ToString());
        }

        public ICommandResult Handler(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}