using System.Collections.Generic;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public interface IGlState
    {
        IEnumerable<uint> TextureBindings { get; }
        TextureUnit ActiveTexture { get; set; }
        uint ArrayBufferBinding { get; set; }
        bool Blend { get; set; }
        Vector4 BlendColor { get; set; }
        BlendingFactor BlendDstAlpha { get; set; }
        BlendingFactor BlendDstRgb { get; set; }
        BlendEquationModeEXT BlendEquationAlpha { get; set; }
        BlendEquationModeEXT BlendEquationRgb { get; set; }
        BlendingFactor BlendSrcAlpha { get; set; }
        BlendingFactor BlendSrcRgb { get; set; }
        Vector4 ColorClearValue { get; set; }
        Vector4b ColorWritemask { get; set; }
        bool CullFace { get; set; }
        CullFaceMode CullFaceMode { get; set; }
        uint CurrentProgram { get; set; }
        float DepthClearValue { get; set; }
        DepthFunction DepthFunc { get; set; }
        Vector2 DepthRange { get; set; }
        bool DepthTest { get; set; }
        bool DepthWritemask { get; set; }
        bool Dither { get; set; }
        uint ElementArrayBufferBinding { get; set; }
        uint FramebufferBinding { get; set; }
        FrontFaceDirection FrontFace { get; set; }
        HintMode GenerateMipmapHint { get; set; }
        float LineWidth { get; set; }
        uint PackAlignment { get; set; }
        float PolygonOffsetFactor { get; set; }
        bool PolygonOffsetFill { get; set; }
        float PolygonOffsetUnits { get; set; }
        uint RenderbufferBinding { get; set; }
        bool SampleAlphaToCoverage { get; set; }
        Vector4i ScissorBox { get; set; }
        bool ScissorTest { get; set; }
        StencilOp StencilBackFail { get; set; }
        StencilFunction StencilBackFunc { get; set; }
        StencilOp StencilBackPassDepthFail { get; set; }
        StencilOp StencilBackPassDepthPass { get; set; }
        int StencilBackRef { get; set; }
        uint StencilBackValueMask { get; set; }
        uint StencilBackWriteMask { get; set; }
        int StencilClearValue { get; set; }
        StencilOp StencilFail { get; set; }
        StencilFunction StencilFuncValue { get; set; }
        StencilOp StencilPassDepthFail { get; set; }
        StencilOp StencilPassDepthPass { get; set; }
        int StencilRef { get; set; }
        bool StencilTest { get; set; }
        uint StencilValueMask { get; set; }
        uint StencilWriteMask { get; set; }
        uint TextureBinding2D { get; set; }
        uint TextureBindingCubeMap { get; set; }
        uint UnpackAlignment { get; set; }
        Vector4i Viewport { get; set; }
    }
}