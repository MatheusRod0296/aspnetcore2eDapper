using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerhandlerTests
    {
        [TestMethod]
        public void ShouldResgisterCustomerWhenCommandIsValid(){

            var command = new CreateCustomerCommand();
            command.FirstName = "Matheus";
            command.LastName = "Matheus";
            command.Document = "44892048844";
            command.Email = "Matheus@email.com";
            command.Phone = "1199999999";

            Assert.AreEqual(true, command.Valid());

            

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
            var result = handler.Handler(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}