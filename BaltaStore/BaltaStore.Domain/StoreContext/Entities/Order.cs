using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order: Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer costumer)
        {
            Costumer = costumer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();

        }
        
        public Customer Costumer { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public DateTime CreateDate { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();     

        public void AddItem(Product product, decimal quantity){
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }


        // CRiar um pedido
        public void Place()
        {
            //Gera o numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //Validar

            if(_items.Count == 0)
                AddNotification("Order", "esse pedido não possui itens");
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }



        //Enviar um pedido
        public void Ship()
        {

            //quebra as entregar , a cada 5 produstos 1 entrega           
            var qtsEntregas = _items.Count / 5 < 1 ? 1 : _items.Count / 5;
            for (int i = 0; i < qtsEntregas; i++)
            {
                var d = new Delivery(DateTime.Now.AddDays(5));
                //envia a entrega
                d.Ship();
                //adiciona a entrega ao pedido
                _deliveries.Add(d);
            }


        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }


        //Cancelar um pedido







    }
}