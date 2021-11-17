using Microsoft.AspNetCore.Mvc;
using System;
using Tips.Dtos;
using Tips.Services;

namespace Tips.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class TipsAdminController : ControllerBase
  {
    private readonly AdminService adminService;
    public TipsAdminController(AdminService adminService)
    {
      this.adminService = adminService;
    }

    [HttpPut("{id}")]
    public MatchDto UpdateMatchResult(int id, [FromBody] MatchDto matchDto)
    {
      Console.WriteLine($"UpdateMatchResult #{id} --> {matchDto.Shot}:{matchDto.Received}");
      return adminService.UpdateMatchResult(id, matchDto);
    }

  }
}
