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
        private readonly ConcurrentDictionary<Type, IAbstractIterator> _enumerators = new ConcurrentDictionary<Type, IAbstractIterator>();
        private readonly Queue<(ChangeStatus, Entity)> _entityQueue = new Queue<(ChangeStatus, Entity)>();

        public int CreateEntity()
        {
            var id = Interlocked.Increment(ref _Id);
            var e = new Entity(id);
            _entities.Add(e.Id, e);
            _entityQueue.Enqueue((ChangeStatus.Created, e));

            return id;
        }

        public void AddComponent<T>(int id, T component)
        {
            var e = _entities[id];
            e.AddComponent(component);
            _entityQueue.Enqueue((ChangeStatus.Changed, e));
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
            UpdateEnumerators(e, false);
        }

        public void DestoryEntity(int id)
        {
            UpdateEnumerators(_entities[id], true);
            _entities.Remove(id);
        }

        public IEnumerable<(int, T1)> Enumerate<T1>()
        {
            return _enumerators
                .GetOrAdd(typeof(T1), new SingleIterator<T1>(_entities.Values))
                .Cast<(int, T1)>();
        }

        public IEnumerable<(int, T1, T2)> Enumerate<T1, T2>()
        {
            return _enumerators
                .GetOrAdd(typeof((T1, T2)), new DoubleIterator<T1, T2>(_entities.Values))
                .Cast<(int, T1, T2)>();
        }

        public IEnumerable<(int, T1, T2, T3)> Enumerate<T1, T2, T3>()
        {
            return _enumerators
                .GetOrAdd(typeof((T1, T2, T3)), new TripleIterator<T1, T2, T3>(_entities.Values))
                .Cast<(int, T1, T2, T3)>();
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

        public void ApplyChanges()
        {
            while (_entityQueue.Count > 0)
            {
                var (type, entity) = _entityQueue.Dequeue();

                switch (type)
                {
                    case ChangeStatus.Created:
                        UpdateEnumerators(entity, false);
                        break;
                    case ChangeStatus.Deleted:
                        UpdateEnumerators(entity, true);
                        break;
                    case ChangeStatus.Changed:
                        UpdateEnumerators(entity, false);
                        break;
                }
            }
        }

        
    }
}
