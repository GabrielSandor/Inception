using System;

namespace Inception
{
    public abstract class Timeline
    {
        private readonly int _timeWarpFactor;

        public int Level { get; }

        public int SubjectiveDreamingDuration { get; protected set; }

        protected Timeline Parent { get; }

        protected int TickCount { get; set; }

        public abstract int EffectiveDreamTickCount { get; }

        public Timeline(int level, Timeline parent, int timeWarpFactor)
        {
            Level = level;
            Parent = parent;
            _timeWarpFactor = timeWarpFactor;
        }

        public abstract void Tick();

        public DreamTimeline StartDreaming()
        {
            return new DreamTimeline(Level + 1, this, _timeWarpFactor);
        }

        public void WakeUp()
        {
            Parent?.ResumeFromChildDream(TickCount);
        }

        protected int CalculateElapsedTimeAfterResumingFromChildDream(int ticksSpentInChildDream)
        {
            return (int)Math.Ceiling((double)ticksSpentInChildDream / _timeWarpFactor);
        }

        protected abstract void ResumeFromChildDream(int ticksSpentInChildDream);
    }
}
