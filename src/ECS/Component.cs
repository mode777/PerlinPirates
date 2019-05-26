namespace ECS
{
    public class Component
    {
        public Component(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; }
    }
}