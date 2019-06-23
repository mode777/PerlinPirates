using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ECS
{
    public class Entity
    {
        public readonly int Id;
        private readonly Dictionary<Type, object> _components;

        public Entity(int id)
        {
            Id = id;
            _components = new Dictionary<Type, object>();
        }

        public bool HasTypes(params Type[] types)
        {
            return types.All(x => _components.ContainsKey(x));
        }

        public T GetComponent<T>()
        {
            return (T)_components[typeof(T)];
        }
    }

    public class World
    {
        private readonly List<Entity> _entities;
        private readonly List<(Predicate<Entity>, Action<Entity>)> _delegates = new List<(Predicate<Entity>, Action<Entity>)>();

        public void Iterate()
        {
            foreach (var entity in _entities)
            {
                foreach (var tuple in _delegates)
                {
                    if (tuple.Item1(entity))
                    {
                        tuple.Item2(entity);
                    }
                }
            }
        }

        public void RegisterIterator<T1>(Action<int, T1> iterator)
        {
            Predicate<Entity> predicate = e => e.HasTypes(typeof(T1));
            Action<Entity> action = e => iterator(e.Id, e.GetComponent<T1>());

            _delegates.Add((predicate, action));
        }

        public void RegisterIterator<T1, T2>(Action<int, T1, T2> iterator)
        {
            Predicate<Entity> predicate = e => e.HasTypes(typeof(T1), typeof(T2));
            Action<Entity> action = e => iterator(e.Id, e.GetComponent<T1>(), e.GetComponent<T2>());

            _delegates.Add((predicate, action));
        }

        public void RegisterIterator<T1, T2, T3>(Action<int, T1, T2, T3> iterator)
        {
            Predicate<Entity> predicate = e => e.HasTypes(typeof(T1), typeof(T2));
            Action<Entity> action = e => iterator(e.Id, e.GetComponent<T1>(), e.GetComponent<T2>(), e.GetComponent<T3>());

            _delegates.Add((predicate, action));
        }

    }
}
