using Domain;
using MelbergFramework.Infrastructure.Rabbit.Metrics;

namespace Application.Mappers;

public static class MetricMessageMapper
{
    public static Metric ToDomain(this MetricMessage message) =>
        new () 
        {
            Application = message.Application,
            TimeInMS = message.TimeInMS,
            TimeStamp = message.TimeStamp
        };
}
