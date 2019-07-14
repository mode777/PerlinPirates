using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Obj;

namespace ExampleGame.Tutorial
{
    public class ObjLoading : IHandlesLoad
    {
        private readonly ResourceManager _resources;

        public ObjLoading(ResourceManager resources)
        {
            _resources = resources;
        }

        public void Load()
        {
            var file = _resources.LoadResource<ObjFile>("Resources/Meshes/suzanne.obj");
        }
    }
}
