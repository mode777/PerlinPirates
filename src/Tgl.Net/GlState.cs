using System.Collections.Generic;
using System.Linq;
using Tgl.Net.Bindings;
using Tgl.Net.Math;
using static Tgl.Net.Bindings.GL;

namespace Tgl.Net
{
    public class GlState : IGlState
    {
        public GlState()
        {
            Info = new GlInfo();
            TextureBindingAccessor = new TextureBindingAccessor(Info.MaxCombinedTextureImageUnits);
        }

        public GlInfo Info { get; }

        public virtual IEnumerable<uint> TextureBindings => TextureBindingAccessor;
        public TextureBindingAccessor TextureBindingAccessor { get; }

        public virtual TextureUnit ActiveTexture
        {
            get => GetInteger<TextureUnit>(GetPName.GL_ACTIVE_TEXTURE);
            set => glActiveTexture(value);
        }
        
        public virtual uint ArrayBufferBinding
        {
            get => GetInteger<uint>(GetPName.GL_ARRAY_BUFFER_BINDING);
            set => glBindBuffer(BufferTargetARB.GL_ARRAY_BUFFER, value);
        }

        public virtual bool Blend
        {
            get => glIsEnabled(EnableCap.GL_BLEND);
            set => SetEnabled(EnableCap.GL_BLEND, value);
        }

        public virtual Vector4 BlendColor
        {
            get => GetFloat<Vector4>(GetPName.GL_BLEND_COLOR);
            set => glBlendColor(value.X, value.Y, value.Z, value.W);
        }

        public virtual BlendingFactor BlendDstAlpha
        {
            get => GetInteger<BlendingFactor>(GetPName.GL_BLEND_DST_ALPHA);
            set => glBlendFuncSeparate(BlendSrcRgb, BlendDstRgb, BlendSrcAlpha, value);
        }

        public virtual BlendingFactor BlendDstRgb
        {
            get => GetInteger<BlendingFactor>(GetPName.GL_BLEND_DST_RGB);
            set => glBlendFuncSeparate(BlendSrcRgb, value, BlendSrcAlpha, BlendDstAlpha);
        }

        public virtual BlendEquationModeEXT BlendEquationAlpha
        {
            get => GetInteger<BlendEquationModeEXT>(GetPName.GL_BLEND_EQUATION_ALPHA);
            set => glBlendEquationSeparate(BlendEquationRgb, value);
        }

        public virtual BlendEquationModeEXT BlendEquationRgb
        {
            get => GetInteger<BlendEquationModeEXT>(GetPName.GL_BLEND_EQUATION_RGB);
            set => glBlendEquationSeparate(value, BlendEquationAlpha);
        }

        public virtual BlendingFactor BlendSrcAlpha
        {
            get => GetInteger<BlendingFactor>(GetPName.GL_BLEND_SRC_ALPHA);
            set => glBlendFuncSeparate(BlendSrcRgb, BlendDstRgb, value, BlendDstAlpha);
        }

        public virtual BlendingFactor BlendSrcRgb
        {
            get => GetInteger<BlendingFactor>(GetPName.GL_BLEND_SRC_RGB);
            set => glBlendFuncSeparate(value, BlendDstRgb, BlendSrcAlpha, BlendDstAlpha);
        }

        public virtual Vector4 ColorClearValue
        {
            get => GetFloat<Vector4>(GetPName.GL_COLOR_CLEAR_VALUE);
            set => glClearColor(value.X, value.Y, value.Z, value.W);
        }

        public virtual Vector4b ColorWritemask
        {
            get => GetBoolean<Vector4b>(GetPName.GL_COLOR_WRITEMASK);
            set => glColorMask(value.X, value.Y, value.Z, value.W);
        }

        public virtual bool CullFace
        {
            get => glIsEnabled(EnableCap.GL_CULL_FACE);
            set => SetEnabled(EnableCap.GL_CULL_FACE, value);
        }

        public virtual CullFaceMode CullFaceMode
        {
            get => GetInteger<CullFaceMode>(GetPName.GL_CULL_FACE_MODE);
            set => glCullFace(value);
        }

        public virtual uint CurrentProgram
        {
            get => GetInteger<uint>(GetPName.GL_CURRENT_PROGRAM);
            set => glUseProgram(value);
        }

        public virtual float DepthClearValue
        {
            get => GetFloat<float>(GetPName.GL_DEPTH_CLEAR_VALUE);
            set => glClearDepthf(value);
        }

        public virtual DepthFunction DepthFunc
        {
            get => GetInteger<DepthFunction>(GetPName.GL_DEPTH_FUNC);
            set => glDepthFunc(value);
        }

        public virtual Vector2 DepthRange
        {
            get => GetFloat<Vector2>(GetPName.GL_DEPTH_RANGE);
            set => glDepthRangef(value.X, value.Y);
        }

        public virtual bool DepthTest
        {
            get => glIsEnabled(EnableCap.GL_DEPTH_TEST);
            set => SetEnabled(EnableCap.GL_DEPTH_TEST, value);
        }

        public virtual bool DepthWritemask
        {
            get => GetBoolean<bool>(GetPName.GL_DEPTH_WRITEMASK);
            set => glDepthMask(value);
        }

        public virtual bool Dither
        {
            get => glIsEnabled(EnableCap.GL_DITHER);
            set => SetEnabled(EnableCap.GL_DITHER, value);
        }

        public virtual uint ElementArrayBufferBinding
        {
            get => GetInteger<uint>(GetPName.GL_ELEMENT_ARRAY_BUFFER_BINDING);
            set => glBindBuffer(BufferTargetARB.GL_ELEMENT_ARRAY_BUFFER, value);
        }

        public virtual uint FramebufferBinding
        {
            get => GetInteger<uint>(GetPName.GL_FRAMEBUFFER_BINDING);
            set => glBindFramebuffer(FramebufferTarget.GL_FRAMEBUFFER, value);
        }

        public virtual FrontFaceDirection FrontFace
        {
            get => GetInteger<FrontFaceDirection>(GetPName.GL_FRONT_FACE);
            set => glFrontFace(value);
        }

        public virtual HintMode GenerateMipmapHint
        {
            get => GetInteger<HintMode>(GetPName.GL_GENERATE_MIPMAP_HINT);
            set => glHint(HintTarget.GL_GENERATE_MIPMAP_HINT, value);
        }

        public virtual float LineWidth
        {
            get => GetFloat<float>(GetPName.GL_LINE_WIDTH);
            set => glLineWidth(value);
        }

        public virtual uint PackAlignment
        {
            get => GetInteger<uint>(GetPName.GL_PACK_ALIGNMENT);
            set => glPixelStorei(PixelStoreParameter.GL_PACK_ALIGNMENT, (int)value);
        }

        public virtual float PolygonOffsetFactor
        {
            get => GetFloat<float>(GetPName.GL_POLYGON_OFFSET_FACTOR);
            set => glPolygonOffset(value, PolygonOffsetUnits);
        }

        public virtual bool PolygonOffsetFill
        {
            get => glIsEnabled(EnableCap.GL_POLYGON_OFFSET_FILL);
            set => SetEnabled(EnableCap.GL_POLYGON_OFFSET_FILL, value);
        }

        public virtual float PolygonOffsetUnits
        {
            get => GetFloat<float>(GetPName.GL_POLYGON_OFFSET_UNITS);
            set => glPolygonOffset(PolygonOffsetFactor, value);
        }

        public virtual uint RenderbufferBinding
        {
            get => GetInteger<uint>(GetPName.GL_RENDERBUFFER_BINDING);
            set => glBindRenderbuffer(RenderbufferTarget.GL_RENDERBUFFER, value);
        }

        public virtual bool SampleAlphaToCoverage
        {
            get => GetBoolean<bool>(GetPName.GL_SAMPLE_ALPHA_TO_COVERAGE);
            set => SetEnabled(EnableCap.GL_SAMPLE_ALPHA_TO_COVERAGE, value);
        }

        public virtual Vector4i ScissorBox
        {
            get => GetInteger<Vector4i>(GetPName.GL_SCISSOR_BOX);
            set => glScissor(value.X, value.Y, value.Z, value.W);
        }

        public virtual bool ScissorTest
        {
            get => glIsEnabled(EnableCap.GL_SCISSOR_TEST);
            set => SetEnabled(EnableCap.GL_SCISSOR_TEST, value);
        }

        public virtual StencilOp StencilBackFail
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_BACK_FAIL);
            set => glStencilOpSeparate(StencilFaceDirection.GL_BACK, value, StencilPassDepthFail, StencilBackPassDepthPass);
        }

        public virtual StencilFunction StencilBackFunc
        {
            get => GetInteger<StencilFunction>(GetPName.GL_STENCIL_BACK_FUNC);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_BACK, value, StencilBackRef, StencilBackValueMask);
        }

        public virtual StencilOp StencilBackPassDepthFail
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_BACK_PASS_DEPTH_FAIL);
            set => glStencilOpSeparate(StencilFaceDirection.GL_BACK, StencilBackFail, value, StencilBackPassDepthPass);
        }

        public virtual StencilOp StencilBackPassDepthPass
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_BACK_PASS_DEPTH_PASS);
            set => glStencilOpSeparate(StencilFaceDirection.GL_BACK, StencilBackFail, StencilBackPassDepthFail, value);
        }

        public virtual int StencilBackRef
        {
            get => GetInteger<int>(GetPName.GL_STENCIL_BACK_REF);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_BACK, StencilBackFunc, value, StencilBackValueMask);
        }

        public virtual uint StencilBackValueMask
        {
            get => GetInteger<uint>(GetPName.GL_STENCIL_BACK_VALUE_MASK);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_BACK, StencilBackFunc, StencilBackRef, value);
        }

        public virtual uint StencilBackWriteMask
        {
            get => GetInteger<uint>(GetPName.GL_STENCIL_BACK_WRITEMASK);
            set => glStencilMaskSeparate(StencilFaceDirection.GL_BACK, value);
        }

        public virtual int StencilClearValue
        {
            get => GetInteger<int>(GetPName.GL_STENCIL_CLEAR_VALUE);
            set => glClearStencil(value);
        }

        public virtual StencilOp StencilFail
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_FAIL);
            set => glStencilOpSeparate(StencilFaceDirection.GL_FRONT, value, StencilPassDepthFail, StencilPassDepthPass);
        }

        public virtual StencilFunction StencilFuncValue
        {
            get => GetInteger<StencilFunction>(GetPName.GL_STENCIL_FUNC);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_FRONT, value, StencilRef, StencilValueMask);
        }

        public virtual StencilOp StencilPassDepthFail
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_PASS_DEPTH_FAIL);
            set => glStencilOpSeparate(StencilFaceDirection.GL_FRONT, StencilFail, value, StencilPassDepthPass);
        }

        public virtual StencilOp StencilPassDepthPass
        {
            get => GetInteger<StencilOp>(GetPName.GL_STENCIL_PASS_DEPTH_PASS);
            set => glStencilOpSeparate(StencilFaceDirection.GL_FRONT, StencilFail, StencilPassDepthFail, value);
        }

        public virtual int StencilRef
        {
            get => GetInteger<int>(GetPName.GL_STENCIL_REF);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_FRONT, StencilFuncValue, value, StencilValueMask);
        }

        public virtual bool StencilTest
        {
            get => glIsEnabled(EnableCap.GL_STENCIL_TEST);
            set => SetEnabled(EnableCap.GL_STENCIL_TEST, value);
        }

        public virtual uint StencilValueMask
        {
            get => GetInteger<uint>(GetPName.GL_STENCIL_VALUE_MASK);
            set => glStencilFuncSeparate(StencilFaceDirection.GL_FRONT, StencilFuncValue, StencilRef, value);
        }

        public virtual uint StencilWriteMask
        {
            get => GetInteger<uint>(GetPName.GL_STENCIL_WRITEMASK);
            set => glStencilMaskSeparate(StencilFaceDirection.GL_FRONT, value);
        }

        public virtual uint TextureBinding2D
        {
            get => GetInteger<uint>(GetPName.GL_TEXTURE_BINDING_2D);
            set => glBindTexture(TextureTarget.GL_TEXTURE_2D, value);
        }

        public virtual uint TextureBindingCubeMap
        {
            get => GetInteger<uint>(GetPName.GL_TEXTURE_BINDING_CUBE_MAP);
            set => glBindTexture(TextureTarget.GL_TEXTURE_CUBE_MAP, value);
        }

        public virtual uint UnpackAlignment
        {
            get => GetInteger<uint>(GetPName.GL_UNPACK_ALIGNMENT);
            set => glPixelStorei(PixelStoreParameter.GL_UNPACK_ALIGNMENT, (int)value);
        }

        public virtual Vector4i Viewport
        {
            get => GetInteger<Vector4i>(GetPName.GL_VIEWPORT);
            set => glViewport(value.X, value.Y, value.Z, value.W);
        }

        public virtual void BlendFuncSeparate(BlendingFactor blendSrcRgb,
            BlendingFactor blendDstRgb,
            BlendingFactor blendSrcAlpha,
            BlendingFactor blendDstAlpha)
        {
            glBlendFuncSeparate(blendSrcRgb, 
                blendDstRgb, 
                blendSrcAlpha, 
                blendDstAlpha);
        }

        public virtual void BlendFunc(BlendingFactor blendSrc,
            BlendingFactor blendDst)
        {
            glBlendFunc(blendSrc, blendDst);
        }

        public virtual void BlendEquationSeparate(BlendEquationModeEXT blendEquationRgb,
            BlendEquationModeEXT blendEquationAlpha)
        {
            glBlendEquationSeparate(blendEquationRgb, blendEquationAlpha);
        }

        public virtual void BlendEquation(BlendEquationModeEXT blendEquation)
        {
            glBlendEquation(blendEquation);
        }

        public virtual void PolygonOffset(float factor, float units)
        {
            glPolygonOffset(factor, units);
        }

        public virtual void StencilOpSeparate(StencilFaceDirection direction,
            StencilOp stencilFail,
            StencilOp depthFail,
            StencilOp pass)
        {
            glStencilOpSeparate(direction, stencilFail, depthFail, pass);
        }

        public virtual void StencilOp(StencilOp stencilFail,
            StencilOp depthFail,
            StencilOp pass)
        {
            glStencilOp(stencilFail, depthFail, pass);
        }

        public virtual void StencilFuncSeparate(StencilFaceDirection direction,
            StencilFunction func, int @ref, uint mask)
        {
            glStencilFuncSeparate(direction, func, @ref, mask);
        }

        public virtual void StencilFunc(StencilFunction func, 
            int @ref, uint mask)
        {
            glStencilFunc(func, @ref, mask);
        }
    }
}