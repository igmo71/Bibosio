﻿using Microsoft.Extensions.Hosting;

namespace Bibosio.ProductsModule.Infrastructure.EventBus.Kafka
{
    internal class KafkaProductUpdatedConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}