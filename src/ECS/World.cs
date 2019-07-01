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
        private readonly Dictionary<string, int> _names = new Dictionary<string, int>();

        public int CreateEntity()
        {
            var id = Interlocked.Increment(ref _Id);
            var e = new Entity(id);
            _entities.Add(id, e);
            return id;
        }

        public int CreateEntity<T1>(T1 component)
        {
            var id = CreateEntity();
            AddComponent(id, component);

            return id;
        }

        public int CreateEntity<T1,T2>(T1 component, T2 component2)
        {
            var id = CreateEntity();
            AddComponent(id, component);
            AddComponent(id, component2);

            return id;
        }

        public int CreateEntity<T1, T2, T3>(T1 component, T2 component2, T3 component3)
        {
            var id = CreateEntity();
            AddComponent(id, component);
            AddComponent(id, component2);
            AddComponent(id, component3);

            return id;
        }

        public void AddComponent<T>(int id, T component)
        {
            var e = _entities[id];
            e.AddComponent(component);
        }

        public T Component<T>(int id)
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

        public IEnumerable<(int, T1, T2)> Enumerate<T1,T2>()
        {
            return _entities.Values
                .Where(e => e.HasTypes(typeof(T1), typeof(T2)))
                .Select(e => (e.Id, e.GetComponent<T1>(), e.GetComponent<T2>()));
        }

        public IEnumerable<(int, T1, T2, T3)> Enumerate<T1, T2, T3>()
        {
            return _entities.Values
                .Where(e => e.HasTypes(typeof(T1), typeof(T2), typeof(T3)))
                .Select(e => (e.Id, e.GetComponent<T1>(), e.GetComponent<T2>(), e.GetComponent<T3>()));
        }

        public void NameEntity(int id, string name)
        {
            _names[name] = id;
        }

        public int IdForName(string name)
        {
            if (_names.TryGetValue(name, out var id))
            {
                return id;
            }

            throw new KeyNotFoundException(name);
        }
    }
}
