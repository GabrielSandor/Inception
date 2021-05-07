using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var sb = new StringBuilder();
            sb.AppendLine($"Total subjective dreaming duration: {TotalSubjectiveDreamingDuration}");
            sb.AppendLine($"Realtime dreaming duration: {RealTimeDreamingDuration}");
            foreach (var (key, value) in DurationsPerDreamLevel.OrderBy(kvp => kvp.Key))
            {
                sb.AppendLine($"Dream level {key} duration: {value}");
            }

            return sb.ToString();
        }
    }
}
