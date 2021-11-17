using System;
using System.Linq;
using Tips.Dtos;
using TipsDb;

namespace Tips.Services
{
  public class AdminService
  {
    private readonly TipsContext db;

    public AdminService(TipsContext db)
    {
      this.db = db;
    }

    public MatchDto UpdateMatchResult(long id, MatchDto matchDto)
    {
      var match = db.MatchWithResults.Single(x => x.Id == id);
      if (match.Shot != null && match.Received != null)
      {
        throw new InvalidOperationException($"Match #{id} already played {matchDto.Shot}:{matchDto.Received}");
      }
      match.Shot = matchDto.Shot;
      match.Received = matchDto.Received;
      db.SaveChanges();
	  //TODO: calculate Points, TipsExact and Tips12x for every Tipper
      return new MatchDto().CopyPropertiesFrom(match);
    }
  }
}