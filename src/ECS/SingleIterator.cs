using System.Collections.Generic;

namespace ECS
{
    internal class SingleIterator<T1> : AbstractIterator<(int, T1)>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1));
        protected override (int, T1) Transform(Entity e) => (e.Id, e.GetComponent<T1>());

        public SingleIterator(IEnumerable<Entity> entites) : base(entites)
        {
        }
    }
}