using System;
using System.Collections.Generic;

namespace TipsDb
{
    public partial class Tipper
    {
        public Tipper()
        {
            MatchTips = new HashSet<MatchTip>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long P { get; set; }
        public long TipsExact { get; set; }
        public long Tips12X { get; set; }
        public string Groups { get; set; }

        public virtual ICollection<MatchTip> MatchTips { get; set; }
    }
}
