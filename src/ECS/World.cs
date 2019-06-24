using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace ECS
{
    public class World
    {
        private static int _Id = 0;

        private readonly Dictionary<int, Entity> _entities = new Dictionary<int, Entity>();
        private readonly Dictionary<Type, IAbstractIterator> _enumerators = new Dictionary<Type, IAbstractIterator>();

        public int CreateEntity()
        {
            var id = Interlocked.Increment(ref _Id);
            var e = new Entity(id);
            _entities.Add(id, e);
            UpdateEnumerators(e, false);
            return id;
        }

        public void AddComponent<T>(int id, T component)
        {
            var e = _entities[id];
            e.AddComponent(component);
            UpdateEnumerators(e, false);
        }

        public void RemoveComponent<T>(int id)
        {
            var e = _entities[id];
            e.RemoveComponent<T>();
            UpdateEnumerators(e, false);
        }

        public void DestoryEntity(int id)
        {
            UpdateEnumerators(_entities[id], true);
            _entities.Remove(id);
        }

        private void UpdateEnumerators(Entity e, bool remove)
        {
            foreach (var value in _enumerators.Values)
            {
                if (remove)
                {
                    value.Remove(e);
                }
                else
                {
                    value.AddOrUpdate(e);
                }
            }
        }

        
    }
}
