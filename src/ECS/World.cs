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

            _entityQueue.Enqueue((ChangeStatus.Created, e));

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
                        _entities.Add(entity.Id, entity);
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
