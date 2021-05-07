using System.Collections.Generic;

namespace Inception
{
    public class DreamStats
    {
        public int TotalSubjectiveDreamingDuration { get; set; }

        public int RealTimeDreamingDuration { get; set; }

        public IDictionary<int, int> DurationsPerDreamLevel { get; } = new Dictionary<int, int>();

        public int DreamLevels => DurationsPerDreamLevel.Count;

        public void RecordDurationPerTimeline(int level, int tickCount)
        {
            if (!DurationsPerDreamLevel.ContainsKey(level))
            {
                DurationsPerDreamLevel.Add(level, tickCount);
            }
            else
            {
                DurationsPerDreamLevel[level] += tickCount;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
