using Infrastructure.InfluxDB;
using MelbergFramework.ComponentTesting.InfluxDB;
using MelbergFramework.ComponentTesting.Rabbit;
using MelbergFramework.Infrastructure.InfluxDB;
using MelbergFramework.Infrastructure.Rabbit.Messages;
using MelbergFramework.Infrastructure.Rabbit.Metrics;
using MelbergFramework.Infrastructure.Rabbit.Translator;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Features;

public partial class ServiceTests : BaseTestFrame 
{
    public async Task Metric_recieved()
    {
        var mockTranslator = (MockTranslator<MetricMessage>)
            GetClass<IJsonToObjectTranslator<MetricMessage>>();
        mockTranslator.Messages.Add(
                new MetricMessage()
                {
                    TimeInMS = 1, 
                    TimeStamp = DateTime.MaxValue,
                    Application = "test"
                });
        await GetMetricService().ConsumeMessageAsync(new Message(), CancellationToken.None);
    }

    public async Task Metric_was_recorded()
    {
        var config = GetClass<IOptions<InfluxDBOptions<MarkContext>>>();
        var context = GetClass<IStandardClientFactory>().GetClient(config.Value.Uri);
        var mockContext = (MockInfluxDBClient) context;
        Assert.AreEqual(1, mockContext.Written.Count );
    }
}
