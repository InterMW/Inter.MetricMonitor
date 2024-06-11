using MelbergFramework.Infrastructure.InfluxDB;
using Infrastructure.RepositoryCore;
using Domain;
using Infrastructure.InfluxDB.Mappers;

namespace Infrastructure.InfluxDB.Repositories;

public class MetricMarkRepository : BaseInfluxDBRepository<MarkContext>, IMetricMarkRepository
{
    public MetricMarkRepository(MarkContext context) : base(context) { }
    public Task MarkMetricAsync(Metric metric) =>
        Context.WritePointAsync(metric.ToDataModel(),"service_data","Inter");
}
