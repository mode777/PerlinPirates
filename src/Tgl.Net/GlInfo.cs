using System.Drawing;
using System.Linq;
using System.Numerics;
using Tgl.Net.Bindings;
using Tgl.Net.Math;
using static Tgl.Net.Bindings.GL;

namespace Tgl.Net
{
    public class GlInfo
    {
        public GlInfo()
        {
            AliasedLineWidthRange = GetFloat<Vector2>(GetPName.GL_ALIASED_LINE_WIDTH_RANGE);
            AliasedPointSizeRange = GetFloat<Vector2>(GetPName.GL_ALIASED_POINT_SIZE_RANGE);
            ImplementationColorReadFormat = GetInteger<PixelFormat>(GetPName.GL_IMPLEMENTATION_COLOR_READ_FORMAT);
            ImplementationColorReadType = GetInteger<PixelType>(GetPName.GL_IMPLEMENTATION_COLOR_READ_TYPE);
            MaxCombinedTextureImageUnits = GetInteger<uint>(GetPName.GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS);
            MaxCubeMapTextureSize = GetInteger<uint>(GetPName.GL_MAX_CUBE_MAP_TEXTURE_SIZE);
            MaxFragmentUniformVectors = GetInteger<uint>(GetPName.GL_MAX_FRAGMENT_UNIFORM_VECTORS);
            MaxRenderBufferSize = GetInteger<uint>(GetPName.GL_MAX_RENDERBUFFER_SIZE);
            MaxTextureImageUnits = GetInteger<uint>(GetPName.GL_MAX_TEXTURE_IMAGE_UNITS);
            MaxTextureSize = GetInteger<uint>(GetPName.GL_MAX_TEXTURE_SIZE);
            MaxVaryingVectors = GetInteger<uint>(GetPName.GL_MAX_VARYING_VECTORS);
            MaxVertexAttribs = GetInteger<uint>(GetPName.GL_MAX_VERTEX_ATTRIBS);
            MaxVertexUniformVectors = GetInteger<uint>(GetPName.GL_MAX_VERTEX_UNIFORM_VECTORS);
            MaxViewportDims = GetInteger<Point>(GetPName.GL_MAX_VIEWPORT_DIMS);
            MaxVertexTextureImageUnits = GetInteger<uint>(GetPName.GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS);
            MaxFragmentUniformVectors = GetInteger<uint>(GetPName.GL_MAX_FRAGMENT_UNIFORM_VECTORS);
            NumCompressedTextureFormats = GetInteger<uint>(GetPName.GL_NUM_COMPRESSED_TEXTURE_FORMATS);
            NumShaderBinaryFormats = GetInteger<uint>(GetPName.GL_NUM_SHADER_BINARY_FORMATS);
            ShaderCompiler = GetBoolean<bool>(GetPName.GL_SHADER_COMPILER);
            SubpixelBits = GetInteger<uint>(GetPName.GL_SUBPIXEL_BITS);
            CompressedTextureFormats =
                GetIntegerArray(GetPName.GL_COMPRESSED_TEXTURE_FORMATS, (int) NumCompressedTextureFormats)
                    .Select(x => (InternalFormat) x).ToArray();
            ShaderBinaryFormats =
                GetIntegerArray(GetPName.GL_SHADER_BINARY_FORMATS, (int) NumShaderBinaryFormats);
        }

        public Vector2 AliasedLineWidthRange { get; }
        public Vector2 AliasedPointSizeRange { get; }
        public InternalFormat[] CompressedTextureFormats { get; } 
        public PixelFormat ImplementationColorReadFormat { get; }
        public PixelType ImplementationColorReadType { get; }
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
        public Point MaxViewportDims { get; }
        public uint NumCompressedTextureFormats { get; }
        public uint NumShaderBinaryFormats { get; }
        public uint[] ShaderBinaryFormats { get; }
        public bool ShaderCompiler { get; }
        public uint SubpixelBits { get; }
    }
}