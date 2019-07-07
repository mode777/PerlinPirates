using System;
using System.Collections.Generic;

namespace ExampleGame
{
    public class SystemConfig
    {
        public SystemConfig(Type systemType, int updateEveryNth = 1)
        {
            SystemType = systemType;
            UpdateEveryNth = updateEveryNth;
        }

        public Type SystemType { get; }
        public int UpdateEveryNth { get; }
    }

    public class GameLoopOptions
    {
        private List<SystemConfig> _systemTypes = new List<SystemConfig>();

        public IEnumerable<SystemConfig> Systems => _systemTypes.AsReadOnly();

        public void AddSystem<T>(int updateEveryNth = 1)
        {
            _systemTypes.Add(new SystemConfig(typeof(T), updateEveryNth));
        }
    }
}