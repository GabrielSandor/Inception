namespace Inception
{
    public class DreamTimeline : Timeline
    {
        public DreamTimeline(int level, Timeline parent, int timeWarpFactor)
            : base(level, parent, timeWarpFactor)
        {
        }

        public override int EffectiveDreamTickCount => TickCount;

        public override void Tick()
        {
            TickCount++;
            SubjectiveDreamingDuration++;
        }

        protected override void ResumeFromChildDream(int ticksSpentInChildDream)
        {
            TickCount += CalculateElapsedTimeAfterResumingFromChildDream(ticksSpentInChildDream);
        }
    }
}
