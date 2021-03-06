using System;

namespace Inception
{
    public abstract class Timeline
    {
        private readonly Timeline _parent;
        private readonly int _timeWarpFactor;

        public int Level { get; }

        public int SubjectiveDreamingDuration { get; protected set; }

        protected int TickCount { get; set; }

        protected Timeline(int level, Timeline parent, int timeWarpFactor)
        {
            Level = level;
            _parent = parent;
            _timeWarpFactor = timeWarpFactor;
        }

        public abstract void Tick();

        public DreamTimeline StartDreaming()
        {
            return new DreamTimeline(Level + 1, this, _timeWarpFactor);
        }

        public void WakeUp()
        {
            _parent?.ResumeFromChildDream(TickCount);
        }

        protected int CalculateElapsedTimeAfterResumingFromChildDream(int ticksSpentInChildDream)
        {
            return (int)Math.Ceiling((double)ticksSpentInChildDream / _timeWarpFactor);
        }

        protected abstract void ResumeFromChildDream(int ticksSpentInChildDream);
    }
}
