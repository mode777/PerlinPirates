namespace ECS
{
    internal class TripleIterator<T1, T2, T3> : AbstractIterator<(T1, T2, T3)>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1), typeof(T2), typeof(T3));
        protected override (T1, T2, T3) Transform(Entity e) => e.GetComponents<T1, T2, T3>();
    }
}