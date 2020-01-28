using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repository;
using BaltaStore.Domain.StoreContext.ValuesObjects;
using BaltaStore.Shared.commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.APi.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            _customerRepository = customerRepository;
            _customerHandler = customerHandler;
        }

        [HttpGet]
        [Route("v1/Customers")]
        [ResponseCache(Duration=60)]
        public IEnumerable<ListCustomerResultQuery> Get()
        {

            return _customerRepository.Get();
        }

        [HttpGet]
        [Route("v1/Customers/{id}")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration=60)]
        public GetCustomerResultQuery GetbyId(Guid id)
        {

            return _customerRepository.Get(id);
        }


        [HttpGet]
        [Route("v2/Customers/{document}")]
        public GetCustomerResultQuery GetbyDocument(Guid document)
        {

            return _customerRepository.Get(document);
        }

        [HttpGet]
        [Route("v1/Customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersResultQuery> GetOrders(Guid id)
        {

            return _customerRepository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            return _customerHandler.Handler(command);         

        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var _customar = new Customer(name, document, email, command.Phone);
            return _customar;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {

            return new { Message = "clinete removido com suceso" };
        }
    }
}