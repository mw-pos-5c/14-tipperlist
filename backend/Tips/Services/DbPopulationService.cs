using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TipsDb;

namespace Tips.Services
{
  public class DbPopulationService
  {
    private readonly TipsContext db;
    public DbPopulationService(TipsContext db)
    {
      this.db = db;
    }

    public void CheckPopulateDb()
    {
      if (!db.Tippers.Any()) PopulateTippers();
      if (!db.MatchWithResults.Any()) PopulateMatches();
      if (!db.MatchTips.Any()) PopulateMatchTips();
    }

    private void PopulateMatchTips()
    {
      Console.WriteLine("PopulateTippers");
      var random = new Random();
      int id = 1;
      foreach (var tipper in db.Tippers.ToList())
      {
        foreach (var match in db.MatchWithResults
          .Include(x => x.Team1)
          .Include(x => x.Team2)
          .ToList())
        {
          int shot = random.Next(0, 4);
          int received = random.Next(0, 4);
          Console.WriteLine($"  {tipper.Name} {match.Team1.Name}-{match.Team2.Name}: {shot}:{received}");
          db.MatchTips.Add(new MatchTip
          {
            Id = id++,
            MatchWithResult = match,
            Tipper = tipper,
            Tip12X = 0,
            TipExact = 0,
            Shot = shot,
            Received = received
          });
        }
      }
      db.SaveChanges();
    }

    private void PopulateTippers()
    {
      Console.WriteLine("PopulateTippers");
      //ID;Name;Gruppe
      //1;RobertG;Club97,Grueneis,SVAI,SVWSenioren
      var tippers = System.IO.File.ReadAllLines("tippernames.csv")
         .Skip(1)
         .Select(x => x.Split(";"))//.Select(y => y.Trim()))
         .Select(x => new Tipper
         {
           Id = int.Parse(x[0]),
           Name = x[1].Trim(),
           Groups = x[2].Trim(),
         });
      db.AddRange(tippers);
      db.SaveChanges();
    }

    private void PopulateMatches()
    {
      Console.WriteLine("PopulateMatches");
      // 0     1     2     3     4
      //Seq;Gruppe;Team1;Team2;Datum
      //1;A;Ita;Tur;12.06.2020
      var lines = System.IO.File.ReadAllLines("matches.csv")
         .Skip(1)
         .Select(x => x.Split(";"));
      var teamNames = lines.Select(x => x[2]).Union(lines.Select(x => x[3]));
      if (!db.Teams.Any()) PopulateTeams(teamNames);
      var teamMap = db.Teams.ToDictionary(x => x.Name, x => x);
      int id = 1;
      var matches = lines.Select(x => new MatchWithResult
      {
        Id = id++,
        Seq = int.Parse(x[0]),
        Gruppe = x[1].Trim(),
        Team1 = teamMap[x[2]],
        Team2 = teamMap[x[3]],
        Datum = BitConverter.GetBytes(DateTime.ParseExact(x[4], "dd.MM.yyyy", null).Ticks),
        //Datum = new System.Text.ASCIIEncoding().GetBytes(x[4]),
      });
      db.AddRange(matches);
      db.SaveChanges();
    }

    private void PopulateTeams(IEnumerable<string> teamNames)
    {
      Console.WriteLine($"PopulateTeams with {teamNames.Count()} teams");
      int id = 1;
      var teams = teamNames.OrderBy(x => x).Select(x => new Team { Name = x, Id = id++ });
      db.Teams.AddRange(teams);
      db.SaveChanges();
    }
  }
}
