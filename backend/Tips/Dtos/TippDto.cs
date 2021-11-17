using System.Collections.Generic;

namespace Tips.Dtos
{
  public class TippDto
  {
    public long TipperId { get; set; }
    public string TipperName { get; set; }
    public long P { get; set; }
    public long TipsExact { get; set; }
    public long Tips12X { get; set; }
    public List<SingleTippDto> Tipps { get; set; }
  }
}
