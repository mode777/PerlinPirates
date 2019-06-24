namespace ECS
{
    internal class SingleIterator<T1> : AbstractIterator<T1>
    {
        protected override bool IsValid(Entity e) => e.HasTypes(typeof(T1));
        protected override T1 Transform(Entity e) => e.GetComponent<T1>();
    }
}