using Application.Mappers;
using DomainService;
using MelbergFramework.Infrastructure.Rabbit.Consumers;
using MelbergFramework.Infrastructure.Rabbit.Messages;
using MelbergFramework.Infrastructure.Rabbit.Metrics;
using MelbergFramework.Infrastructure.Rabbit.Translator;

namespace Application.Pillars;

public class MetricProcessor : IStandardConsumer
{
    private readonly IJsonToObjectTranslator<MetricMessage> _translator;
    private readonly IMetricDomainService _service;

    public MetricProcessor(
            IMetricDomainService service,
            IJsonToObjectTranslator<MetricMessage> translator)
    {
        _service = service;
        _translator = translator;
    }

    public Task ConsumeMessageAsync(Message message, CancellationToken ct) =>
        _service.MarkMetricAsync(
                _translator.Translate(message).ToDomain());
}
