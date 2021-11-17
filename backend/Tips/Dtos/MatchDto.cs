using System;

namespace Tips.Dtos
{
  public class MatchDto
  {
    public long Id { get; set; }
    public byte[] Datum { private get; set; }
    private DateTime Date => new DateTime().AddTicks(BitConverter.ToInt64(Datum, 0));
    public string DateString => $"{Date:dd.MM.yyyy}";
    //public long DateTicks => BitConverter.ToInt64(Datum, 0);
    public string Gruppe { get; set; }
    public long Seq { get; set; }
    public long? Shot { get; set; }
    public long? Received { get; set; }
    public long Team1Id { get; set; }
    public long Team2Id { get; set; }
    public string Team1Name { get; set; }
    public string Team2Name { get; set; }
  }
}
