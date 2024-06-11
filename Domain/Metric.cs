namespace Domain;
public class Metric
{
    public long TimeInMS { get; set; }
    public string Application { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}
