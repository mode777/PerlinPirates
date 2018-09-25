using Endobit.DomainDrivenDesign;
using Endobit.DomainDrivenDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorldServer.Entities;
using WorldServer.Events;

namespace WorldServer.EventHandlers
{
    public class WorldEntityEventHandler : IEventHandler<WorldEntityEvent>
    {
        private readonly IRepository<WorldEntity> _repo;

        public WorldEntityEventHandler(IRepository<WorldEntity> repo)
        {
            _repo = repo;
        }

        public async Task Handle(WorldEntityEvent ev, CancellationToken cancellationToken)
        {
            switch (ev.Type)
            {
                case EntityEventType.Create:
                    {
                        await _repo.AddAsync(ev.Entity);
                    }
                    break;
                case EntityEventType.Delete:
                    {
                        var old = _repo.GetByKey(ev.Entity.ChunkX, ev.Entity.ChunkY, ev.Entity.X, ev.Entity.Y);
                        await _repo.DeleteAsync(old);
                    }
                    break;
                case EntityEventType.Update:
                    {
                        var old = _repo.GetByKey(ev.Entity.ChunkX, ev.Entity.ChunkY, ev.Entity.X, ev.Entity.Y);
                        old.Update(ev.Entity.EntityId);
                        await _repo.UpdateAsync(old);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
