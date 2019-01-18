using System.IO;
using System.Reflection;
using Tgl.Net.Helpers;

namespace Tgl.Net
{
    public class ShaderBuilder
    {
        private readonly IGlState _state;

        public ShaderBuilder(IGlState state)
        {
            _state = state;
        }

        internal string VertexSource { get; private set; }
        internal string FragmentSource { get; private set; }
                
        public ShaderBuilder HasVertexString(string shader)
        {
            VertexSource = shader;
            return this;
        }

        public ShaderBuilder HasFragmentString(string shader)
        {
            FragmentSource = shader;
            return this;
        }

        public Shader Build()
        {
            var shader = new Shader(_state);

            if(FragmentSource != null && VertexSource != null)
            {
                shader.CompileAndLink(VertexSource, FragmentSource);
            }

            return shader;
        }
    }
}