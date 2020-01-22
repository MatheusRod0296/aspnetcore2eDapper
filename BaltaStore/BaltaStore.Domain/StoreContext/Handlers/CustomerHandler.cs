using System;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repository;
using BaltaStore.Domain.StoreContext.Services;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IEMailServices _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEMailServices emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handler(CreateCustomerCommand command)
        {
            //cpf existe na base
            if (_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "cpf em Uso");

            //email existe na base
            if (_customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "email em Uso");


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

            if (Invalid)
                return null;

            //persistir
            _customerRepository.Save(customer);

            //enviar Email boas vindas
            _emailService.Send(email.Adress, "matheus@Aula.com", "bem vindo", "bem vindo");

            // retornar resultado para
            return new CreateCustomerCommandResult(customer.Id, customer.Name.ToString(), customer.Email.ToString());
        }

        public ICommandResult Handler(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}