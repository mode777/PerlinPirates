using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Entities;

namespace WorldServer.Events
{
    public enum EntityEventType
    {
        Create,
        Delete,
        Update
    }

    public class WorldEntityEvent
    {
        public WorldEntityEvent(EntityEventType type, WorldEntity entity)
        {
            Type = type;
            Entity = entity;
        }

        public EntityEventType Type { get; }
        public WorldEntity Entity { get; }
    }
}
