﻿using Bibosio.Interfaces;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Events
{
    public record ProductCreatedEvent(Guid Id, string Sku) : IEvent;
}