﻿using DCM.Interfaces;
using Discord.WebSocket;

namespace DCM.Events.Discord
{
    public class CurrentUserUpdatedEvent : IEvent
    {
        public CurrentUserUpdatedEvent(SocketSelfUser oldUser, SocketSelfUser newUser)
        {
            OldUser = oldUser;
            NewUser = newUser;
        }

        public SocketSelfUser OldUser { get; }
        public SocketSelfUser NewUser { get; }
    }
}
