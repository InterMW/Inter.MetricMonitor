using MelbergFramework.Infrastructure.InfluxDB;
using Microsoft.Extensions.Options;

namespace Infrastructure.InfluxDB;

public class MarkContext :  DefaultContext
{
    public MarkContext(
        IStandardClientFactory factory,
        IOptions<InfluxDBOptions<MarkContext>> options) 
        : base(factory, options.Value){}
} 
