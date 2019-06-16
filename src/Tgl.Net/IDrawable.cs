using System;
using System.Collections.Generic;
using System.Numerics;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public interface IDrawable
    {
        Shader Shader { get; }
        IEnumerable<VertexBuffer> Buffers { get; }
        IndexBuffer IndexBuffer { get; }
        IDictionary<string, Texture> Textures { get; }
        IDictionary<string, float> FloatUniforms { get; }
        IDictionary<string, Vector2> Vector2Uniforms { get; }
        IDictionary<string, Vector3> Vector3Uniforms { get; }
        IDictionary<string, Vector4> Vector4Uniforms { get; }
        IDictionary<string, Matrix2x2> Matrix2Uniforms { get; }
        IDictionary<string, Matrix3x3> Matrix3Uniforms { get; }
        IDictionary<string, Matrix4x4> Matrix4Uniforms { get; }
    }
}
