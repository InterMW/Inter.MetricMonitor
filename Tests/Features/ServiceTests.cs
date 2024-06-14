using LightBDD.Framework.Scenarios;
using LightBDD.MsTest3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Features;

[TestClass]
public partial class ServiceTests : BaseTestFrame
{
    [Scenario]
    [TestMethod]
    public async Task Metric_recieved_is_recorded()
    {
        await Runner.RunScenarioAsync(
            _ => Metric_recieved(),
            _ => Metric_was_recorded()
                );
    }
}
