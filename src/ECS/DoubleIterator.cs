namespace ECS
{
    internal class DoubleIterator<T1, T2> : AbstractIterator<(T1, T2)>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1), typeof(T2));
        protected override (T1, T2) Transform(Entity e) => e.GetComponents<T1, T2>();
    }
}