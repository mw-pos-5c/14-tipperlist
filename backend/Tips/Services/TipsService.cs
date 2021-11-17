using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tips.Dtos;
using TipsDb;

namespace Tips.Services
{
  public class TipsService
  {
    private readonly TipsContext db;
    private readonly DbPopulationService dbPopulationService;

    public TipsService(TipsContext db, DbPopulationService dbPopulationService)
    {
      this.db = db;
      this.dbPopulationService = dbPopulationService;
    }

    public List<TipperDto> TipperNames()
    {
      dbPopulationService.CheckPopulateDb();
      return db.Tippers
        .OrderBy(x => x.Name)
        .Select(x => new TipperDto().CopyPropertiesFrom(x))
        .ToList();
    }

    public List<MatchDto> MatchResults()
    {
      return db.MatchWithResults
        .Include(x => x.Team1)
        .Include(x => x.Team2)
        .ToList()
        .Select(x =>
        {
          var dto = new MatchDto
          {
            Team1Name = x.Team1.Name,
            Team2Name = x.Team2.Name,
          }.CopyPropertiesFrom(x);
          return dto;
        })
        .ToList();
    }

    public TippDto Tipps(int tipperId)
    {
      var tipper = db.Tippers.Single(x => x.Id == tipperId);
      var tippDto = new TippDto
      {
        TipperName = tipper.Name,
        TipperId = tipper.Id,
        Tipps = db.MatchTips
        .Include(x => x.MatchWithResult)
        .Where(x => x.Tipper.Id == tipperId)
        .ToList()
        .Select(x =>
        {
          var dto = new SingleTippDto().CopyPropertiesFrom(x);
          dto.Seq = x.MatchWithResult.Seq;
          return dto;
        }).ToList()
      }.CopyPropertiesFrom(tipper);
      return tippDto;
    }

    
  }
}
