using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("matheus", "rodrigues");
            var document = new Document("1234567");
            var email = new Email("matheus@ig.com");
            var c = new Customer(name, document, email, "119778899");

            var mouse = new Product("mouse", "rato", "image.png", 59.90M, 10);
            var teclado = new Product("teclado", "keyboard", "image.png", 519.90M, 10);
            var impressora = new Product("impressora", "printer", "image.png", 259.90M, 10);
            var cadeira = new Product("cadeira", "chair", "image.png", 459.90M, 10);

            var order = new Order(c);
            // order.AddItem(new OrderItem(mouse, 5));
            // order.AddItem(new OrderItem(teclado, 5));
            // order.AddItem(new OrderItem(cadeira, 5));
            // order.AddItem(new OrderItem(impressora, 5));


            // //realizei o pedido
            // order.Place();

            // order.Pay();

            // order.Ship();

            // order.Cancel();
        }

        // public Order CreateOrder(CreateOrderCommand command ){

        // }
    }
}
