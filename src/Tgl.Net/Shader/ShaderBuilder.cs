using System.IO;
using System.Reflection;
using Tgl.Net.Helpers;
using Tgl.Net.State;

namespace Tgl.Net.Shader
{
    public class ShaderBuilder
    {
        private readonly IGlState _state;

        internal ShaderBuilder(IGlState state)
        {
            _state = state;
        }

        internal string VertexSource { get; private set; }
        internal string FragmentSource { get; private set; }

        public ShaderBuilder HasVertexFile(string path)
        {
            return HasVertexString(File.ReadAllText(path));
        }

        public ShaderBuilder HasVertexString(string shader)
        {
            VertexSource = shader;
            return this;
        }

        public ShaderBuilder HasVertexResource(string path)
        {
            return HasVertexString(
                ResourceHelpers.GetResourceString(Assembly.GetCallingAssembly(), path));
        }

        public ShaderBuilder HasFragmentResource(string path)
        {
            return HasFragmentString(
                ResourceHelpers.GetResourceString(Assembly.GetCallingAssembly(), path));

        }

        public ShaderBuilder HasFragmentFile(string path)
        {
            return HasFragmentString(File.ReadAllText(path));
        }

        public ShaderBuilder HasFragmentString(string shader)
        {
            FragmentSource = shader;
            return this;
        }

        public Shader Build()
        {
            return new Shader(_state, this);
        }
    }
}