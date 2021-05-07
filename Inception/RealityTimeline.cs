namespace Inception
{
    public class RealityTimeline : Timeline
    {
        public int DreamTickCount { get; private set; }

        public override int EffectiveDreamTickCount => DreamTickCount;

        public RealityTimeline(int timeWarpFactor) : base(0, null, timeWarpFactor)
        {
        }

        public override void Tick()
        {
            TickCount++;
        }

        protected override void ResumeFromChildDream(int ticksSpentInChildDream)
        {
            var elapsedTime = CalculateElapsedTimeAfterResumingFromChildDream(ticksSpentInChildDream);

            TickCount += elapsedTime;
            DreamTickCount += elapsedTime;
        }
    }
}
