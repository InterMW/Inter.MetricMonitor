using Domain;
using Infrastructure.RepositoryCore;

namespace DomainService;

public interface IMetricDomainService
{
    Task MarkMetricAsync(Metric metric);
}

public class MetricDomainService : IMetricDomainService
{
    private readonly IMetricMarkRepository _metricMarkRepository;
    public MetricDomainService(IMetricMarkRepository metricMarkRepository)
    {
        _metricMarkRepository = metricMarkRepository;
    }

    public Task MarkMetricAsync(Metric metric) =>
        _metricMarkRepository.MarkMetricAsync(metric);
}
