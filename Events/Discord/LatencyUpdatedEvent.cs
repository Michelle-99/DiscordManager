﻿using DCM.Interfaces;

namespace DCM.Events.Discord
{
    public class LatencyUpdatedEvent : IEvent
    {
        public LatencyUpdatedEvent(int oldLatency, int newLatency)
        {
            OldLatency = oldLatency;
            NewLatency = newLatency;
        }

        public int OldLatency { get; }
        public int NewLatency { get; }
    }
}
