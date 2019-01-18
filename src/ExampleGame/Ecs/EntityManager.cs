using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace ExampleGame.Ecs
{
    public class EntityManager
    {
        private static Lazy<EntityManager> instance = new Lazy<EntityManager>(() 
            => new EntityManager(), true);

        public static EntityManager Current => instance.Value;

        
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<int, IComponent>>
            _store = new ConcurrentDictionary<Type, ConcurrentDictionary<int, IComponent>>(2, 32);

        private int entityCtr = 0;
        
        private EntityManager()
        {
        }

        public void RegisterComponent<T>()
            where T : IComponent
        {
            _store.TryAdd(typeof(T), new ConcurrentDictionary<int, IComponent>(2, 1024));
        }


        public int CreateEntity()
        {
            return Interlocked.Increment(ref entityCtr);
        }

        public void DestroyEntity(int entity)
        {
            foreach (var pair in _store)
            {
                pair.Value.TryRemove(entity, out var _);
            }
        }

        public void AddComponent<T>(int entity, IComponent component)
            where T : IComponent
        {
            if(_store.TryGetValue(typeof(T), out var dict))
            {
                dict.TryAdd(entity, component);
            }
        }

        public void RemoveComponent<T>(int entity)
            where T : IComponent
        {
            if (_store.TryGetValue(typeof(T), out var dict))
            {
                dict.TryRemove(entity, out var _);
            }
        }

        public bool GetComponent<T>(int entity, out T component)
            where T : class, IComponent
        {
            if (_store.TryGetValue(typeof(T), out var dict))
            {                
                dict.TryGetValue(entity, out var c);
                component = (T)c;
                return true;
            }
            component = null;
            return false;
        }

        public bool GetComponents<T1, T2>(int entity, out T1 component1, out T2 component2)
            where T1 : class, IComponent
            where T2 : class, IComponent
        {
            component1 = null;
            component2 = null;
            return GetComponent(entity, out component1) 
                && GetComponent(entity, out component2);
        }

        public bool GetComponents<T1, T2, T3>(int entity, 
            out T1 component1, 
            out T2 component2, 
            out T3 component3)
            where T1 : class, IComponent
            where T2 : class, IComponent
            where T3 : class, IComponent
        {
            component1 = null;
            component2 = null;
            component3 = null;
            return GetComponent(entity, out component1)
                && GetComponent(entity, out component2)
                && GetComponent(entity, out component3);
        }

        public bool GetComponents<T1, T2, T3, T4>(int entity,
            out T1 component1,
            out T2 component2,
            out T3 component3,
            out T4 component4)
            where T1 : class, IComponent
            where T2 : class, IComponent
            where T3 : class, IComponent
            where T4 : class, IComponent
        {
            component1 = null;
            component2 = null;
            component3 = null;
            component4 = null;
            return GetComponent(entity, out component1)
                && GetComponent(entity, out component2)
                && GetComponent(entity, out component3)
                && GetComponent(entity, out component4);
        }

        public IReadOnlyDictionary<int, T> QueryComponents<T>()
        {
            if(_store.TryGetValue(typeof(T), out var d))
            {
                return d.ToDictionary(x => x.Key, x => (T)x.Value);
            }

            return null;
        } 
    }
}
