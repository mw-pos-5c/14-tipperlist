using System;
using System.Collections.Generic;

namespace TipsDb
{
    public partial class Team
    {
        public Team()
        {
            MatchWithResultTeam1 = new HashSet<MatchWithResult>();
            MatchWithResultTeam2 = new HashSet<MatchWithResult>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MatchWithResult> MatchWithResultTeam1 { get; set; }
        public virtual ICollection<MatchWithResult> MatchWithResultTeam2 { get; set; }
    }
}
