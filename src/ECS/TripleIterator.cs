using System.Collections.Generic;

namespace ECS
{
    internal class TripleIterator<T1, T2, T3> : AbstractIterator<(int, T1, T2, T3)>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1), typeof(T2), typeof(T3));
        protected override (int, T1, T2, T3) Transform(Entity e) => (e.Id, e.GetComponent<T1>(), e.GetComponent<T2>(), e.GetComponent<T3>());

        public TripleIterator(IEnumerable<Entity> entites) : base(entites)
        {
        }
    }
}