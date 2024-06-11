using Domain;

namespace Infrastructure.RepositoryCore;

public interface IMetricMarkRepository
{
    Task MarkMetricAsync(Metric metric);
}
