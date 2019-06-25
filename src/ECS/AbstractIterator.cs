using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ECS
{
    internal interface IAbstractIterator : IEnumerable
    {
        void AddOrUpdate(Entity e);
        void Remove(Entity e);
    } 

    internal abstract class AbstractIterator<TResult> : IAbstractIterator, IEnumerable<TResult>
    {
        private readonly HashSet<Entity> _entities = new HashSet<Entity>();
        
        public AbstractIterator(IEnumerable<Entity> entites)
        {
            foreach (var entity in entites)
            {
                _entities.Add(entity);
            }
        }

        public void AddOrUpdate(Entity e)
        {
            if (_entities.Contains(e))
            {
                if (!IsValid(e))
                {
                    _entities.Remove(e);
                }
            }
            else
            {
                if (IsValid(e))
                {
                    _entities.Add(e);
                }
            }
        }

        public void Remove(Entity e)
        {
            _entities.Remove(e);
        }

        protected abstract bool IsValid(Entity e);
        protected abstract TResult Transform(Entity e);

        public IEnumerator<TResult> GetEnumerator()
        {
            return _entities
                .Where(IsValid)
                .Select(Transform)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}