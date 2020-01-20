using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand: Notifiable, ICommand
    {
        public Guid Costumer { get; set; }

        public IList<OrderItemCommand> OrderItems { get; set; }

        public PlaceOrderCommand()
        {
            
            OrderItems = new List<OrderItemCommand>();
        }

        public bool Valid()
        {
              AddNotifications(new ValidationContract()
            .Requires()
            .HasLen(Costumer.ToString(), 36, nameof(Costumer), "Identificador invalido")
            .IsGreaterThan(OrderItems.Count, 0, nameof(OrderItems), "nenhum item do pedido foi encontrado")
            
         );

         return Valid();
        }
    }

    public class OrderItemCommand{
        public Guid Product { get; set; }

        public decimal Qauntity { get; set; }
    } 

}