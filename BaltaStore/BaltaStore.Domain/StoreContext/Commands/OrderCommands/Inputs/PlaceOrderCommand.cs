using System;
using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Custumer { get; set; }
    }
}