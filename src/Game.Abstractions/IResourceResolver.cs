using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Abstractions
{
    public interface IResourceResolver
    {
        Stream Resolve(string resourceId);
    }
}
