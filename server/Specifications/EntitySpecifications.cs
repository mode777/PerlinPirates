using Endobit.DomainDrivenDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Entities;

namespace WorldServer.Specifications
{
    public class ChunkSpecification : BaseSpecification<WorldEntity>
    {
        public ChunkSpecification(int x, int y)
        {
            AddCriteria(e => e.ChunkX == x && e.ChunkY == y);
        }
    }
}
