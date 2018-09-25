using Endobit.DomainDrivenDesign;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorldServer.Aggregates;
using WorldServer.Entities;
using WorldServer.Specifications;

namespace WorldServer.Services
{
    public class ChunkManager
    {
        private static readonly ConcurrentDictionary<(int, int), (int, Chunk)> _cache 
            = new ConcurrentDictionary<(int, int), (int, Chunk)>();

        private readonly IPublisher _publisher;
        private readonly IRepository<WorldEntity> _repo;
        private readonly FractalService _fractal;

        public ChunkManager(FractalService fractal, IPublisher publisher, IRepository<WorldEntity> repo)
        {
            _fractal = fractal;
            _repo = repo;
            _publisher = publisher;
        }

        public async Task<Chunk> AcquireChunkAsync(int x, int y)
        {
            if(_cache.TryGetValue((x,y), out var tuple))
            {
                Interlocked.Increment(ref tuple.Item1);
                return tuple.Item2;
            }
            else
            {
                // TODO: Use Mutex
                var entities = await _repo.ListAsync(new ChunkSpecification(x, y));
                var chunk = new Chunk(_fractal, _publisher, entities, x, y);

                _cache[(x, y)] = (1, chunk);

                return chunk;
            }
        }

        public async Task<Chunk> GetChunkAsync(int x, int y)
        {
            // TODO: use mutex
            if(_cache.TryGetValue((x,y), out var tuple))
            {
                return tuple.Item2;
            }
            else
            {
                return await AcquireChunkAsync(x, y);
            }
        }

        public void ReleaseChunkAsync(int x, int y)
        {
            // TODO: use mutex
            if (_cache.TryGetValue((x, y), out var tuple))
            {
                Interlocked.Decrement(ref tuple.Item1);
                if (tuple.Item1 < 1)
                    _cache.TryRemove((x, y), out var _);
            }
        }

    }
}
