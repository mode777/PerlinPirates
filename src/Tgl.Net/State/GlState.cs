using System.Collections.Generic;
using Tgl.Net.Bindings;
using Tgl.Net.Buffer;
using Tgl.Net.Math;
using Tgl.Net.Shader;
using Tgl.Net.Texture;

namespace Tgl.Net.State
{
    public class GlState : IGlState
    {
        public GlState()
        {
            Info = new GlInfo();
            TextureBindingAccessor = new TextureBindingAccessor(Info.MaxCombinedTextureImageUnits);
        }

        public GlInfo Info { get; }

        public IEnumerable<uint> TextureBindings => TextureBindingAccessor;
        public TextureBindingAccessor TextureBindingAccessor { get; }

        public virtual GL.TextureUnit ActiveTexture
        {
            get => GL.GetInteger<GL.TextureUnit>(GL.GetPName.GL_ACTIVE_TEXTURE);
            set => GL.glActiveTexture(value);
        }
        
        public virtual uint ArrayBufferBinding
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_ARRAY_BUFFER_BINDING);
            set => GL.glBindBuffer(GL.BufferTargetARB.GL_ARRAY_BUFFER, value);
        }

        public virtual bool Blend
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_BLEND);
            set => GL.SetEnabled(GL.EnableCap.GL_BLEND, value);
        }

        public virtual Vector4 BlendColor
        {
            get => GL.GetFloat<Vector4>(GL.GetPName.GL_BLEND_COLOR);
            set => GL.glBlendColor(value.X, value.Y, value.Z, value.W);
        }

        public virtual GL.BlendingFactor BlendDstAlpha
        {
            get => GL.GetInteger<GL.BlendingFactor>(GL.GetPName.GL_BLEND_DST_ALPHA);
            set => GL.glBlendFuncSeparate(BlendSrcRgb, BlendDstRgb, BlendSrcAlpha, value);
        }

        public virtual GL.BlendingFactor BlendDstRgb
        {
            get => GL.GetInteger<GL.BlendingFactor>(GL.GetPName.GL_BLEND_DST_RGB);
            set => GL.glBlendFuncSeparate(BlendSrcRgb, value, BlendSrcAlpha, BlendDstAlpha);
        }

        public virtual GL.BlendEquationModeEXT BlendEquationAlpha
        {
            get => GL.GetInteger<GL.BlendEquationModeEXT>(GL.GetPName.GL_BLEND_EQUATION_ALPHA);
            set => GL.glBlendEquationSeparate(BlendEquationRgb, value);
        }

        public virtual GL.BlendEquationModeEXT BlendEquationRgb
        {
            get => GL.GetInteger<GL.BlendEquationModeEXT>(GL.GetPName.GL_BLEND_EQUATION_RGB);
            set => GL.glBlendEquationSeparate(value, BlendEquationAlpha);
        }

        public virtual GL.BlendingFactor BlendSrcAlpha
        {
            get => GL.GetInteger<GL.BlendingFactor>(GL.GetPName.GL_BLEND_SRC_ALPHA);
            set => GL.glBlendFuncSeparate(BlendSrcRgb, BlendDstRgb, value, BlendDstAlpha);
        }

        public virtual GL.BlendingFactor BlendSrcRgb
        {
            get => GL.GetInteger<GL.BlendingFactor>(GL.GetPName.GL_BLEND_SRC_RGB);
            set => GL.glBlendFuncSeparate(value, BlendDstRgb, BlendSrcAlpha, BlendDstAlpha);
        }

        public virtual Vector4 ColorClearValue
        {
            get => GL.GetFloat<Vector4>(GL.GetPName.GL_COLOR_CLEAR_VALUE);
            set => GL.glClearColor(value.X, value.Y, value.Z, value.W);
        }

        public virtual Vector4b ColorWritemask
        {
            get => GL.GetBoolean<Vector4b>(GL.GetPName.GL_COLOR_WRITEMASK);
            set => GL.glColorMask(value.X, value.Y, value.Z, value.W);
        }

        public virtual bool CullFace
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_CULL_FACE);
            set => GL.SetEnabled(GL.EnableCap.GL_CULL_FACE, value);
        }

        public virtual GL.CullFaceMode CullFaceMode
        {
            get => GL.GetInteger<GL.CullFaceMode>(GL.GetPName.GL_CULL_FACE_MODE);
            set => GL.glCullFace(value);
        }

        public virtual uint CurrentProgram
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_CURRENT_PROGRAM);
            set => GL.glUseProgram(value);
        }

        public virtual float DepthClearValue
        {
            get => GL.GetFloat<float>(GL.GetPName.GL_DEPTH_CLEAR_VALUE);
            set => GL.glClearDepthf(value);
        }

        public virtual GL.DepthFunction DepthFunc
        {
            get => GL.GetInteger<GL.DepthFunction>(GL.GetPName.GL_DEPTH_FUNC);
            set => GL.glDepthFunc(value);
        }

        public virtual Vector2 DepthRange
        {
            get => GL.GetFloat<Vector2>(GL.GetPName.GL_DEPTH_RANGE);
            set => GL.glDepthRangef(value.X, value.Y);
        }

        public virtual bool DepthTest
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_DEPTH_TEST);
            set => GL.SetEnabled(GL.EnableCap.GL_DEPTH_TEST, value);
        }

        public virtual bool DepthWritemask
        {
            get => GL.GetBoolean<bool>(GL.GetPName.GL_DEPTH_WRITEMASK);
            set => GL.glDepthMask(value);
        }

        public virtual bool Dither
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_DITHER);
            set => GL.SetEnabled(GL.EnableCap.GL_DITHER, value);
        }

        public virtual uint ElementArrayBufferBinding
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_ELEMENT_ARRAY_BUFFER_BINDING);
            set => GL.glBindBuffer(GL.BufferTargetARB.GL_ELEMENT_ARRAY_BUFFER, value);
        }

        public virtual uint FramebufferBinding
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_FRAMEBUFFER_BINDING);
            set => GL.glBindFramebuffer(GL.FramebufferTarget.GL_FRAMEBUFFER, value);
        }

        public virtual GL.FrontFaceDirection FrontFace
        {
            get => GL.GetInteger<GL.FrontFaceDirection>(GL.GetPName.GL_FRONT_FACE);
            set => GL.glFrontFace(value);
        }

        public virtual GL.HintMode GenerateMipmapHint
        {
            get => GL.GetInteger<GL.HintMode>(GL.GetPName.GL_GENERATE_MIPMAP_HINT);
            set => GL.glHint(GL.HintTarget.GL_GENERATE_MIPMAP_HINT, value);
        }

        public virtual float LineWidth
        {
            get => GL.GetFloat<float>(GL.GetPName.GL_LINE_WIDTH);
            set => GL.glLineWidth(value);
        }

        public virtual uint PackAlignment
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_PACK_ALIGNMENT);
            set => GL.glPixelStorei(GL.PixelStoreParameter.GL_PACK_ALIGNMENT, (int)value);
        }

        public virtual float PolygonOffsetFactor
        {
            get => GL.GetFloat<float>(GL.GetPName.GL_POLYGON_OFFSET_FACTOR);
            set => GL.glPolygonOffset(value, PolygonOffsetUnits);
        }

        public virtual bool PolygonOffsetFill
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_POLYGON_OFFSET_FILL);
            set => GL.SetEnabled(GL.EnableCap.GL_POLYGON_OFFSET_FILL, value);
        }

        public virtual float PolygonOffsetUnits
        {
            get => GL.GetFloat<float>(GL.GetPName.GL_POLYGON_OFFSET_UNITS);
            set => GL.glPolygonOffset(PolygonOffsetFactor, value);
        }

        public virtual uint RenderbufferBinding
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_RENDERBUFFER_BINDING);
            set => GL.glBindRenderbuffer(GL.RenderbufferTarget.GL_RENDERBUFFER, value);
        }

        public virtual bool SampleAlphaToCoverage
        {
            get => GL.GetBoolean<bool>(GL.GetPName.GL_SAMPLE_ALPHA_TO_COVERAGE);
            set => GL.SetEnabled(GL.EnableCap.GL_SAMPLE_ALPHA_TO_COVERAGE, value);
        }

        public virtual Vector4i ScissorBox
        {
            get => GL.GetInteger<Vector4i>(GL.GetPName.GL_SCISSOR_BOX);
            set => GL.glScissor(value.X, value.Y, value.Z, value.W);
        }

        public virtual bool ScissorTest
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_SCISSOR_TEST);
            set => GL.SetEnabled(GL.EnableCap.GL_SCISSOR_TEST, value);
        }

        public virtual GL.StencilOp StencilBackFail
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_BACK_FAIL);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_BACK, value, StencilPassDepthFail, StencilBackPassDepthPass);
        }

        public virtual GL.StencilFunction StencilBackFunc
        {
            get => GL.GetInteger<GL.StencilFunction>(GL.GetPName.GL_STENCIL_BACK_FUNC);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_BACK, value, StencilBackRef, StencilBackValueMask);
        }

        public virtual GL.StencilOp StencilBackPassDepthFail
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_BACK_PASS_DEPTH_FAIL);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_BACK, StencilBackFail, value, StencilBackPassDepthPass);
        }

        public virtual GL.StencilOp StencilBackPassDepthPass
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_BACK_PASS_DEPTH_PASS);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_BACK, StencilBackFail, StencilBackPassDepthFail, value);
        }

        public virtual int StencilBackRef
        {
            get => GL.GetInteger<int>(GL.GetPName.GL_STENCIL_BACK_REF);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_BACK, StencilBackFunc, value, StencilBackValueMask);
        }

        public virtual uint StencilBackValueMask
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_STENCIL_BACK_VALUE_MASK);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_BACK, StencilBackFunc, StencilBackRef, value);
        }

        public virtual uint StencilBackWriteMask
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_STENCIL_BACK_WRITEMASK);
            set => GL.glStencilMaskSeparate(GL.StencilFaceDirection.GL_BACK, value);
        }

        public virtual int StencilClearValue
        {
            get => GL.GetInteger<int>(GL.GetPName.GL_STENCIL_CLEAR_VALUE);
            set => GL.glClearStencil(value);
        }

        public virtual GL.StencilOp StencilFail
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_FAIL);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_FRONT, value, StencilPassDepthFail, StencilPassDepthPass);
        }

        public virtual GL.StencilFunction StencilFuncValue
        {
            get => GL.GetInteger<GL.StencilFunction>(GL.GetPName.GL_STENCIL_FUNC);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_FRONT, value, StencilRef, StencilValueMask);
        }

        public virtual GL.StencilOp StencilPassDepthFail
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_PASS_DEPTH_FAIL);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_FRONT, StencilFail, value, StencilPassDepthPass);
        }

        public virtual GL.StencilOp StencilPassDepthPass
        {
            get => GL.GetInteger<GL.StencilOp>(GL.GetPName.GL_STENCIL_PASS_DEPTH_PASS);
            set => GL.glStencilOpSeparate(GL.StencilFaceDirection.GL_FRONT, StencilFail, StencilPassDepthFail, value);
        }

        public virtual int StencilRef
        {
            get => GL.GetInteger<int>(GL.GetPName.GL_STENCIL_REF);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_FRONT, StencilFuncValue, value, StencilValueMask);
        }

        public virtual bool StencilTest
        {
            get => GL.glIsEnabled(GL.EnableCap.GL_STENCIL_TEST);
            set => GL.SetEnabled(GL.EnableCap.GL_STENCIL_TEST, value);
        }

        public virtual uint StencilValueMask
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_STENCIL_VALUE_MASK);
            set => GL.glStencilFuncSeparate(GL.StencilFaceDirection.GL_FRONT, StencilFuncValue, StencilRef, value);
        }

        public virtual uint StencilWriteMask
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_STENCIL_WRITEMASK);
            set => GL.glStencilMaskSeparate(GL.StencilFaceDirection.GL_FRONT, value);
        }

        public virtual uint TextureBinding2D
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_TEXTURE_BINDING_2D);
            set => GL.glBindTexture(GL.TextureTarget.GL_TEXTURE_2D, value);
        }

        public virtual uint TextureBindingCubeMap
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_TEXTURE_BINDING_CUBE_MAP);
            set => GL.glBindTexture(GL.TextureTarget.GL_TEXTURE_CUBE_MAP, value);
        }

        public virtual uint UnpackAlignment
        {
            get => GL.GetInteger<uint>(GL.GetPName.GL_UNPACK_ALIGNMENT);
            set => GL.glPixelStorei(GL.PixelStoreParameter.GL_UNPACK_ALIGNMENT, (int)value);
        }

        public virtual Vector4i Viewport
        {
            get => GL.GetInteger<Vector4i>(GL.GetPName.GL_VIEWPORT);
            set => GL.glViewport(value.X, value.Y, value.Z, value.W);
        }

        public virtual void BlendFuncSeparate(GL.BlendingFactor blendSrcRgb,
            GL.BlendingFactor blendDstRgb,
            GL.BlendingFactor blendSrcAlpha,
            GL.BlendingFactor blendDstAlpha)
        {
            GL.glBlendFuncSeparate(blendSrcRgb, 
                blendDstRgb, 
                blendSrcAlpha, 
                blendDstAlpha);
        }

        public virtual void BlendFunc(GL.BlendingFactor blendSrc,
            GL.BlendingFactor blendDst)
        {
            GL.glBlendFunc(blendSrc, blendDst);
        }

        public virtual void BlendEquationSeparate(GL.BlendEquationModeEXT blendEquationRgb,
            GL.BlendEquationModeEXT blendEquationAlpha)
        {
            GL.glBlendEquationSeparate(blendEquationRgb, blendEquationAlpha);
        }

        public virtual void BlendEquation(GL.BlendEquationModeEXT blendEquation)
        {
            GL.glBlendEquation(blendEquation);
        }

        public virtual void PolygonOffset(float factor, float units)
        {
            GL.glPolygonOffset(factor, units);
        }

        public virtual void StencilOpSeparate(GL.StencilFaceDirection direction,
            GL.StencilOp stencilFail,
            GL.StencilOp depthFail,
            GL.StencilOp pass)
        {
            GL.glStencilOpSeparate(direction, stencilFail, depthFail, pass);
        }

        public virtual void StencilOp(GL.StencilOp stencilFail,
            GL.StencilOp depthFail,
            GL.StencilOp pass)
        {
            GL.glStencilOp(stencilFail, depthFail, pass);
        }

        public virtual void StencilFuncSeparate(GL.StencilFaceDirection direction,
            GL.StencilFunction func, int @ref, uint mask)
        {
            GL.glStencilFuncSeparate(direction, func, @ref, mask);
        }

        public virtual void StencilFunc(GL.StencilFunction func, 
            int @ref, uint mask)
        {
            GL.glStencilFunc(func, @ref, mask);
        }

        public virtual void Clear(GL.ClearBufferMask mask)
        {
            GL.glClear(mask);
        }

        public virtual void DrawArrays(GL.PrimitiveType type, int first, int count)
        {
            GL.glDrawArrays(type, first, count);
        }

        public virtual void DrawElements(GL.PrimitiveType type, int first, int count)
        {
            GL.glDrawElements(type, count, GL.DrawElementsType.GL_UNSIGNED_SHORT, first);
        }

        public virtual ShaderBuilder BuildShader()
        {
            return new ShaderBuilder(this);
        }

        public virtual BufferBuilder<T> BuildBuffer<T>()
            where T : struct
        {
            return new BufferBuilder<T>(this);
        }

        public virtual TextureBuilder BuildTexture()
        {
            return new TextureBuilder(this);
        }

        public virtual IndexBuffer CreateIndexBuffer(params ushort[] indices)
        {
            return new IndexBuffer(this, indices);
        }
    }
}