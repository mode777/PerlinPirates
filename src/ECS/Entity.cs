using System;
using System.Collections.Generic;
using System.Linq;

namespace ECS
{
    internal class Entity
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

        public void AddComponent<T>(T component)
        {
            _components[typeof(T)] = component;
        }

        public void RemoveComponent<T>()
        {
            _components.Remove(typeof(T));
        }

        public T1 GetComponent<T1>()
        {
            return (T1)_components[typeof(T1)];
        }

        public (T1,T2) GetComponents<T1,T2>()
        {
            return (
                (T1)_components[typeof(T1)],
                (T2)_components[typeof(T2)]
            );
        }

        public (T1, T2, T3) GetComponents<T1, T2, T3>()
        {
            return (
                (T1)_components[typeof(T1)],
                (T2)_components[typeof(T2)],
                (T3)_components[typeof(T3)]
            );
        }

        public (T1, T2, T3, T4) GetComponents<T1, T2, T3, T4>()
        {
            return (
                (T1)_components[typeof(T1)],
                (T2)_components[typeof(T2)],
                (T3)_components[typeof(T3)],
                (T4)_components[typeof(T4)]
            );
        }

        public (T1, T2, T3, T4, T5) GetComponents<T1, T2, T3, T4, T5>()
        {
            return (
                (T1)_components[typeof(T1)],
                (T2)_components[typeof(T2)],
                (T3)_components[typeof(T3)],
                (T4)_components[typeof(T4)],
                (T5)_components[typeof(T5)]
            );
        }
    }
}