using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValuesObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.APi.Controllers
{
    public class CustomerController: Controller
    {
        [HttpGet]
        [Route("Customers")]
        public List<Customer> Get(){
            var name = new Name("Matheus", "Rodrigues");
            var document = new Document("44892048844");
            var email = new Email("teste@Email.com");
            var _customar = new Customer(name, document, email,"11976364521" );
            

            return new List<Customer>{_customar};
        }

        [HttpGet]
        [Route("Customers/{id}")]
        public Customer GetbyId(Guid id){
            var name = new Name("Matheus", "Rodrigues");
            var document = new Document("44892048844");
            var email = new Email("teste@Email.com");
            var _customar = new Customer(name, document, email,"11976364521" );

            return _customar;
        }

        [HttpGet]
        [Route("Customers/{id}/orders")]
        public List<Order> GetOrders(Guid id){

            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command){
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var _customar = new Customer(name, document, email,command.Phone );
            return _customar;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var _customar = new Customer(name, document, email,command.Phone );
            return _customar;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete(){
            
            return new { Message= "clinete removido com suceso"};
        }
    }
}