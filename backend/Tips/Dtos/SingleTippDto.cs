namespace Tips.Dtos
{
  public class SingleTippDto
  {
    public long MatchWithResultId { get; set; }
    public long Seq { get; set; }
    public long Shot { get; set; }
    public long Received { get; set; }
    public long? TipExact { get; set; }
    public long? Tip12X { get; set; }
  }
}
