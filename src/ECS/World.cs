using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace ECS
{
    public class World
    {
        private enum ChangeStatus
        {
            Created,
            Deleted,
            Changed
        }

        private static int _Id = 0;

        private readonly Dictionary<int, Entity> _entities = new Dictionary<int, Entity>();
        
        public int CreateEntity()
        {
            var id = Interlocked.Increment(ref _Id);
            var e = new Entity(id);
            _entities.Add(id, e);
            return id;
        }

        public void AddComponent<T>(int id, T component)
        {
            var e = _entities[id];
            e.AddComponent(component);
        }

        public T GetComponent<T>(int id)
        {
            var e = _entities[id];
            return e.GetComponent<T>();
        }

        public void RemoveComponent<T>(int id)
        {
            var e = _entities[id];
            e.RemoveComponent<T>();
        }

        public void DestoryEntity(int id)
        {
            _entities.Remove(id);
        }

        public IEnumerable<(int, T1)> Enumerate<T1>()
        {
            return _entities.Values
                .Where(e => e.HasTypes(typeof(T1)))
                .Select(e => (e.Id, e.GetComponent<T1>()));
        }
    }
}
