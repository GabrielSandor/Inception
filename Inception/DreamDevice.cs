using System.Collections.Generic;
using System.Linq;

namespace Inception
{
    public class DreamDevice
    {
        private readonly RealityTimeline _realityTimeline;
        private readonly Stack<DreamTimeline> _dreamTimelines;

        public DreamStats DreamStats { get; }

        public DreamDevice(int timeWarpFactor)
        {
            _realityTimeline = new RealityTimeline(timeWarpFactor);
            _dreamTimelines = new Stack<DreamTimeline>();
            DreamStats = new DreamStats();
        }

        public void ExperienceDream(string consciousnessStream)
        {
            foreach (var tickOrEvent in consciousnessStream)
            {
                switch (char.ToUpperInvariant(tickOrEvent))
                {
                    case 'T':
                        Tick();
                        break;

                    case 'D':
                        StartDreaming();
                        break;

                    case 'W':
                        WakeUp();
                        break;
                }
            }
        }

        private void WakeUp()
        {
            var dreamTimeline = _dreamTimelines.Peek();

            dreamTimeline.WakeUp();
            _dreamTimelines.Pop();

            DreamStats.RecordDurationPerTimeline(dreamTimeline.Level, dreamTimeline.EffectiveDreamTickCount);
            DreamStats.TotalSubjectiveDreamingDuration += dreamTimeline.SubjectiveDreamingDuration;

            if (ActiveTimelineIsReality())
            {
                DreamStats.RealTimeDreamingDuration = _realityTimeline.EffectiveDreamTickCount;
            }
        }

        private void StartDreaming()
        {
            _dreamTimelines.Push(GetActiveTimeline().StartDreaming());
        }

        private void Tick()
        {
            GetActiveTimeline().Tick();
        }

        private Timeline GetActiveTimeline()
        {
            return ActiveTimelineIsReality() ? _realityTimeline : _dreamTimelines.Peek();
        }

        private bool ActiveTimelineIsReality()
        {
            return !_dreamTimelines.Any();
        }
    }
}
