namespace Inception
{
    public class RealityTimeline : Timeline
    {
        private int DreamTickCount { get; set; }

        public virtual int EffectiveDreamTickCount => DreamTickCount;

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
