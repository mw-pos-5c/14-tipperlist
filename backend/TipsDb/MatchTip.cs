using System;
using System.Collections.Generic;

namespace TipsDb
{
    public partial class MatchTip
    {
        public long Id { get; set; }
        public long TipperId { get; set; }
        public long MatchWithResultId { get; set; }
        public long Shot { get; set; }
        public long Received { get; set; }
        public long? TipExact { get; set; }
        public long? Tip12X { get; set; }

        public virtual MatchWithResult MatchWithResult { get; set; }
        public virtual Tipper Tipper { get; set; }
    }
}
