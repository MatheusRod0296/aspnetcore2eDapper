using BaltaStore.Domain.StoreContext.Commands.CustumerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCostumerTests
    {
        [TestMethod]
        public void ShouldValidateCommandIsValid(){

            var command = new CreateCustomerCommand();
            command.FirstName = "Matheus";
            command.LastName = "Matheus";
            command.Document = "12345123451";
            command.Email = "Matheus@email.com";
            command.Phone = "1199999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}