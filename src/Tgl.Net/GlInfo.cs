using System.Linq;
using Tgl.Net.Math;

namespace Tgl.Net.Core
{
    public class GlInfo
    {
        public GlInfo()
        {
            AliasedLineWidthRange = GL.GetFloat<Vector2>(GL.GetPName.GL_ALIASED_LINE_WIDTH_RANGE);
            AliasedPointSizeRange = GL.GetFloat<Vector2>(GL.GetPName.GL_ALIASED_POINT_SIZE_RANGE);
            ImplementationColorReadFormat = GL.GetInteger<GL.PixelFormat>(GL.GetPName.GL_IMPLEMENTATION_COLOR_READ_FORMAT);
            ImplementationColorReadType = GL.GetInteger<GL.PixelType>(GL.GetPName.GL_IMPLEMENTATION_COLOR_READ_TYPE);
            MaxCombinedTextureImageUnits = GL.GetInteger<uint>(GL.GetPName.GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS);
            MaxCubeMapTextureSize = GL.GetInteger<uint>(GL.GetPName.GL_MAX_CUBE_MAP_TEXTURE_SIZE);
            MaxFragmentUniformVectors = GL.GetInteger<uint>(GL.GetPName.GL_MAX_FRAGMENT_UNIFORM_VECTORS);
            MaxRenderBufferSize = GL.GetInteger<uint>(GL.GetPName.GL_MAX_RENDERBUFFER_SIZE);
            MaxTextureImageUnits = GL.GetInteger<uint>(GL.GetPName.GL_MAX_TEXTURE_IMAGE_UNITS);
            MaxTextureSize = GL.GetInteger<uint>(GL.GetPName.GL_MAX_TEXTURE_SIZE);
            MaxVaryingVectors = GL.GetInteger<uint>(GL.GetPName.GL_MAX_VARYING_VECTORS);
            MaxVertexAttribs = GL.GetInteger<uint>(GL.GetPName.GL_MAX_VERTEX_ATTRIBS);
            MaxVertexUniformVectors = GL.GetInteger<uint>(GL.GetPName.GL_MAX_VERTEX_UNIFORM_VECTORS);
            MaxViewportDims = GL.GetInteger<Vector2i>(GL.GetPName.GL_MAX_VIEWPORT_DIMS);
            MaxVertexTextureImageUnits = GL.GetInteger<uint>(GL.GetPName.GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS);
            MaxFragmentUniformVectors = GL.GetInteger<uint>(GL.GetPName.GL_MAX_FRAGMENT_UNIFORM_VECTORS);
            NumCompressedTextureFormats = GL.GetInteger<uint>(GL.GetPName.GL_NUM_COMPRESSED_TEXTURE_FORMATS);
            NumShaderBinaryFormats = GL.GetInteger<uint>(GL.GetPName.GL_NUM_SHADER_BINARY_FORMATS);
            ShaderCompiler = GL.GetBoolean<bool>(GL.GetPName.GL_SHADER_COMPILER);
            SubpixelBits = GL.GetInteger<uint>(GL.GetPName.GL_SUBPIXEL_BITS);
            CompressedTextureFormats =
                GL.GetIntegerArray(GL.GetPName.GL_COMPRESSED_TEXTURE_FORMATS, (int) NumCompressedTextureFormats)
                    .Select(x => (GL.InternalFormat) x).ToArray();
            ShaderBinaryFormats =
                GL.GetIntegerArray(GL.GetPName.GL_SHADER_BINARY_FORMATS, (int) NumShaderBinaryFormats);
        }

        public Vector2 AliasedLineWidthRange { get; }
        public Vector2 AliasedPointSizeRange { get; }
        public GL.InternalFormat[] CompressedTextureFormats { get; } 
        public GL.PixelFormat ImplementationColorReadFormat { get; }
        public GL.PixelType ImplementationColorReadType { get; }
        public uint MaxCombinedTextureImageUnits { get; }
        public uint MaxCubeMapTextureSize { get; }
        public uint MaxFragmentUniformVectors { get; }
        public uint MaxRenderBufferSize { get; }
        public uint MaxTextureImageUnits { get; }
        public uint MaxTextureSize { get; }
        public uint MaxVaryingVectors { get; }
        public uint MaxVertexAttribs { get; }
        public uint MaxVertexTextureImageUnits { get; }
        public uint MaxVertexUniformVectors { get; }
        public Vector2i MaxViewportDims { get; }
        public uint NumCompressedTextureFormats { get; }
        public uint NumShaderBinaryFormats { get; }
        public uint[] ShaderBinaryFormats { get; }
        public bool ShaderCompiler { get; }
        public uint SubpixelBits { get; }
    }
}