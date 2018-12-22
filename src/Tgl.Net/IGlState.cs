using Tgl.Net.Math;

namespace Tgl.Net.Core
{
    public interface IGlState
    {
        GL.TextureUnit ActiveTexture { get; set; }
        uint ArrayBufferBinding { get; set; }
        bool Blend { get; set; }
        Vector4 BlendColor { get; set; }
        GL.BlendingFactor BlendDstAlpha { get; set; }
        GL.BlendingFactor BlendDstRgb { get; set; }
        GL.BlendEquationModeEXT BlendEquationAlpha { get; set; }
        GL.BlendEquationModeEXT BlendEquationRgb { get; set; }
        GL.BlendingFactor BlendSrcAlpha { get; set; }
        GL.BlendingFactor BlendSrcRgb { get; set; }
        Vector4 ColorClearValue { get; set; }
        Vector4b ColorWritemask { get; set; }
        bool CullFace { get; set; }
        GL.CullFaceMode CullFaceMode { get; set; }
        uint CurrentProgram { get; set; }
        float DepthClearValue { get; set; }
        GL.DepthFunction DepthFunc { get; set; }
        Vector2 DepthRange { get; set; }
        bool DepthTest { get; set; }
        bool DepthWritemask { get; set; }
        bool Dither { get; set; }
        uint ElementArrayBufferBinding { get; set; }
        uint FramebufferBinding { get; set; }
        GL.FrontFaceDirection FrontFace { get; set; }
        GL.HintMode GenerateMipmapHint { get; set; }
        float LineWidth { get; set; }
        uint PackAlignment { get; set; }
        float PolygonOffsetFactor { get; set; }
        bool PolygonOffsetFill { get; set; }
        float PolygonOffsetUnits { get; set; }
        uint RenderbufferBinding { get; set; }
        bool SampleAlphaToCoverage { get; set; }
        Vector4i ScissorBox { get; set; }
        bool ScissorTest { get; set; }
        GL.StencilOp StencilBackFail { get; set; }
        GL.StencilFunction StencilBackFunc { get; set; }
        GL.StencilOp StencilBackPassDepthFail { get; set; }
        GL.StencilOp StencilBackPassDepthPass { get; set; }
        int StencilBackRef { get; set; }
        uint StencilBackValueMask { get; set; }
        uint StencilBackWriteMask { get; set; }
        int StencilClearValue { get; set; }
        GL.StencilOp StencilFail { get; set; }
        GL.StencilFunction StencilFuncValue { get; set; }
        GL.StencilOp StencilPassDepthFail { get; set; }
        GL.StencilOp StencilPassDepthPass { get; set; }
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