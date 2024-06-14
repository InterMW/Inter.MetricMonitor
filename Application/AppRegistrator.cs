using Application.Pillars;
using MelbergFramework.Application;
using MelbergFramework.Infrastructure.Rabbit;
using MelbergFramework.Infrastructure.InfluxDB;
using Infrastructure.InfluxDB.Repositories;
using Infrastructure.RepositoryCore;
using MelbergFramework.Infrastructure.Rabbit.Metrics;
using Infrastructure.InfluxDB;
using DomainService;

namespace Application;

public class AppRegistrator : Registrator
{
    public override void RegisterServices(IServiceCollection services)
    {
        RabbitModule.RegisterMicroConsumer<
            MetricProcessor,
            MetricMessage>(services, false);

        services.AddTransient<IMetricDomainService,MetricDomainService>();

        InfluxDBDependencyModule.LoadInfluxDBRepository<IMetricMarkRepository,MetricMarkRepository,MarkContext>(services);
    }
}
