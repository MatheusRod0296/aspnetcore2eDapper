using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValuesObjects;

namespace BaltaStore.Tests.valueObjects
{
    [TestClass]
    public class Documenttests
    {
        [TestMethod]
        //should = deve
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = new Document("12345678911");
            Assert.AreEqual(false, document.IsValid);
             Assert.AreEqual(1, document.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {

            var document = new Document("44892048844");
            Assert.AreEqual(true, document.IsValid);
            Assert.AreEqual(0, document.Notifications.Count);
        }
    }
}