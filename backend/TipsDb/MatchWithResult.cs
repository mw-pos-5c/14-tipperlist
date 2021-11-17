using System;
using System.Collections.Generic;

namespace TipsDb
{
    public partial class MatchWithResult
    {
        public MatchWithResult()
        {
            MatchTips = new HashSet<MatchTip>();
        }

        public long Id { get; set; }
        public byte[] Datum { get; set; }
        public string Gruppe { get; set; }
        public long Seq { get; set; }
        public long? Shot { get; set; }
        public long? Received { get; set; }
        public long? Team1Id { get; set; }
        public long? Team2Id { get; set; }

        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual ICollection<MatchTip> MatchTips { get; set; }
    }
}
