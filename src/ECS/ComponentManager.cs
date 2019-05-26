using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace ECS
{
    public class ComponentManager
    {
        private readonly Dictionary<Type, Dictionary<int, Component>> _components;
        
        public ComponentManager(IEnumerable<Type> componentTypes)
        {
            _components = componentTypes.ToDictionary(x => x, x => new Dictionary<int, Component>());
        }

        public void AddComponent<TComponent>(TComponent component) where TComponent : Component
        {
            if(_components.TryGetValue(typeof(TComponent), out var dict))
            {
                dict[component.EntityId] = component;
            }
            else
            {
                throw new InvalidDataException("Type not found");
            }
        }

        public IEnumerable<TComponent> EnumerateComponents<TComponent>() where TComponent : Component
        {
            if (_components.TryGetValue(typeof(TComponent), out var dict))
            {
                return dict.Select(x => (TComponent)x.Value);
            }
            else
            {
                throw new InvalidDataException("Type not found");
            }
        }

        public TComponent GetSibling<TComponent>(Component component) where TComponent : Component
        {
            if (_components.TryGetValue(typeof(TComponent), out var dict))
            {
                return (TComponent)dict[component.EntityId];
            }
            else
            {
                throw new InvalidDataException("Type not found");
            }
        }
    }
}
