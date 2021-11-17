using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tips.Dtos;
using Tips.Services;

namespace Tips.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class TipsController : ControllerBase
  {
    private readonly TipsService tipsService;
    public TipsController(TipsService tipsService)
    {
      this.tipsService = tipsService;
    }

    [HttpGet]
    public List<TipperDto> TipperNames()
    {
      Console.WriteLine("TipperNames");
      return tipsService.TipperNames();
    }

    [HttpGet]
    public List<MatchDto> MatchResults()
    {
      Console.WriteLine("MatchResults");
      return tipsService.MatchResults();
    }

    [HttpGet("{tipperId}")]
    public TippDto Tipps(int tipperId)
    {
      Console.WriteLine($"Tipps for tipper {tipperId}");
      return tipsService.Tipps(tipperId);

    }

  }
}
