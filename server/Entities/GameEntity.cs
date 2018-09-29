using System;
using WorldServer.ValueObjects;

namespace WorldServer.Entities
{
    public class GameEntity<T> : WorldEntity
        where T : GameObject
    {
        private Lazy<T> _payload;

        private GameEntity()
            : base()
        {
            _payload = new Lazy<T>(() => GetPayload<T>());
        }

        public GameEntity(string id, int x, int y, T payload)
            : base(id,
                x / WorldConstants.ChunkColumns, 
                y / WorldConstants.ChunkRows, 
                (byte)(x % WorldConstants.ChunkColumns),
                (byte)(y % WorldConstants.ChunkRows), 
                payload)
        {
            _payload = new Lazy<T>(() => GetPayload<T>());
        }

        public T Payload => _payload.Value;
    }
}