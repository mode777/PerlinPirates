namespace ECS
{
    internal class DoubleIterator<T1, T2> : AbstractIterator<(int, T1, T2)>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1), typeof(T2));
        protected override (int, T1, T2) Transform(Entity e) => (e.Id, e.GetComponent<T1>(), e.GetComponent<T2>());
    }
}