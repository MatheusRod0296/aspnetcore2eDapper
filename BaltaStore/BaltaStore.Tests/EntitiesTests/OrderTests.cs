using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.EntitiesTests
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customar;
        private Order _order;

        private Product _mouse;
        private Product _keyBoard;
        private Product _chair;
        private Product _monitor;

        public OrderTests(){
            var name = new Name("Matheus", "Rodrigues");
            var document = new Document("44892048844");
            var email = new Email("teste@Email.com");
            _customar = new Customer(name, document, email,"11976364521" );
            _order = new Order(_customar);
           
            _mouse = new Product("mouse", "moouse","jpg", 100M, 10);
            _keyBoard = new Product("key", "key","jpg", 100M, 10);
            _monitor = new Product("monitor", "monitor","jpg", 100M, 10);
            _chair = new Product("chair", "chair","jpg", 100M, 10);
            
        }

        //consigo criar um novo pedido
        [TestMethod]
        public void ShoulCreateOrderWhenValid()
        {       
            Assert.AreEqual(true, _order.IsValid);
        }

        //ao criar o pedido o status deve seer criado
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //ao adicionar um novo item , a quantidade de intens dve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //Ao adcionar um novo item , deve subtratir a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedItem()
        {
            _order.AddItem(_mouse,5);

          Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }
        //ao confimar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();

            Assert.AreNotEqual("", _order.Number);
        }

        //ao pagar um pedido, o status deve SER PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();

            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }


        //dado 10 produtos devem ser duas entregas
        [TestMethod]
        public void ShouldReturnTowWhenPurchasedTenProduct()
        {
            _order.AddItem(_monitor,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
           _order.Cancel();
           Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }
        //ao cancelar o pedido deve cancelar as entregas
        [TestMethod]
        public void ShouldCanceledShippingWhenOrderCanceled()
        {
            _order.AddItem(_monitor,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.AddItem(_mouse,1);
            _order.Ship();
           
            _order.Cancel();
            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled,  item.Status);
            }
           
        }




    }
}