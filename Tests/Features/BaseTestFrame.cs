using Application;
using Application.Pillars;
using Infrastructure.InfluxDB;
using LightBDD.MsTest3;
using MelbergFramework.Application;
using MelbergFramework.ComponentTesting.Rabbit;
using MelbergFramework.Infrastructure.Rabbit.Metrics;
using MelbergFramework.Infrastructure.Rabbit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests.Features;

public class BaseTestFrame : FeatureFixture
{
    public BaseTestFrame()
    {
        App = MelbergHost.CreateHost<AppRegistrator>()
            .AddServices(_ => 
            {
                _.PrepareConsumer<MetricProcessor>(); 
                _.OverrideTranslator<MetricMessage>();
                MockInfluxDBDependencyModule.MockInfluxDBContext<MarkContext>(_);
            })
            .AddControllers()
            .Build();
    }
    public WebApplication App;

    public T GetClass<T>() => (T)App
        .Services
        .GetRequiredService(typeof(T));
    
    public RabbitMicroService<MetricProcessor> GetMetricService() =>
        (RabbitMicroService<MetricProcessor>)App
            .Services
            .GetServices<IHostedService>()
            .Where(_ => 
                    _.GetType() == typeof(RabbitMicroService<MetricProcessor>))
            .First();

}
