using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public class GlStateCache : GlState, INotifyPropertyChanged
    {
        private CachedTextureBindingAccessor _accessor;

        private TextureUnit _activeTexture;
        private uint _arrayBufferBinding;
        private bool _blend;
        private Vector4 _blendColor;
        private BlendingFactor _blendDstAlpha;
        private BlendingFactor _blendDstRgb;
        private BlendEquationModeEXT _blendEquationAlpha;
        private BlendEquationModeEXT _blendEquationRgb;
        private BlendingFactor _blendSrcRgb;
        private BlendingFactor _blendSrcAlpha;
        private Vector4 _colorClearValue;
        private ColorWriteMask _colorWritemask;
        private bool _cullFace;
        private CullFaceMode _cullFaceMode;
        private uint _currentProgram;
        private float _depthClearValue;
        private DepthFunction _depthFunc;
        private Vector2 _depthRange;
        private bool _depthTest;
        private bool _depthWritemask;
        private bool _dither;
        private uint _elementArrayBufferBinding;
        private uint _framebufferBinding;
        private FrontFaceDirection _frontFace;
        private HintMode _generateMipmapHint;
        private float _lineWidth;
        private uint _packAlignment;
        private float _polygonOffsetFactor;
        private bool _polygonOffsetFill;
        private float _polygonOffsetUnits;
        private uint _renderbufferBinding;
        private bool _sampleAlphaToCoverage;
        private Rectangle _scissorBox;
        private bool _scissorTest;
        private StencilOp _stencilBackFail;
        private StencilFunction _stencilBackFunc;
        private StencilOp _stencilBackPassDepthFail;
        private StencilOp _stencilBackPassDepthPass;
        private int _stencilBackRef;
        private uint _stencilBackValueMask;
        private uint _stencilBackWriteMask;
        private int _stencilClearValue;
        private StencilOp _stencilFail;
        private StencilFunction _stencilFunc;
        private StencilOp _stencilPassDepthFail;
        private StencilOp _stencilPassDepthPass;
        private int _stencilRef;
        private bool _stencilTest;
        private uint _stencilValueMask;
        private uint _stencilWriteMask;
        private uint _textureBinding2D;
        private uint _textureBindingCubeMap;
        private uint _unpackAlignment;
        private Rectangle _viewport;

        public GlStateCache(GlInfo info)
            : base(info)
        {
            _accessor = new CachedTextureBindingAccessor(TextureBindingAccessor);
            SyncState();
        }

        public override IEnumerable<uint> TextureBindings => _accessor;

        public override TextureUnit ActiveTexture
        {
            get => _activeTexture;
            set
            {
                TrySetValue(ref _activeTexture, ref value, () => base.ActiveTexture = value);
                _textureBinding2D = _accessor[value];
            }
        }

        public override uint ArrayBufferBinding
        {
            get => _arrayBufferBinding;
            set => TrySetValue(ref _arrayBufferBinding, ref value, () => base.ArrayBufferBinding = value);
        }

        public override bool Blend
        {
            get => _blend;
            set => TrySetValue(ref _blend, ref value, () => base.Blend = value);
        }

        public override Vector4 BlendColor
        {
            get => _blendColor;
            set => TrySetValue(ref _blendColor, ref value, () => base.BlendColor = value);
        }

        public override BlendingFactor BlendDstAlpha
        {
            get => _blendDstAlpha;
            set => TrySetValue(ref _blendDstAlpha, ref value,() => base.BlendDstAlpha = value);
        }

        public override BlendingFactor BlendDstRgb
        {
            get => _blendDstRgb;
            set => TrySetValue(ref _blendDstRgb, ref value, () => base.BlendDstRgb = value);
        }

        public override BlendEquationModeEXT BlendEquationAlpha
        {
            get => _blendEquationAlpha;
            set => TrySetValue(ref _blendEquationAlpha, ref value, () => base.BlendEquationAlpha = value);
        }

        public override BlendEquationModeEXT BlendEquationRgb
        {
            get => _blendEquationRgb;
            set => TrySetValue(ref _blendEquationRgb, ref value, () => base.BlendEquationRgb = value);
        }

        public override BlendingFactor BlendSrcAlpha
        {
            get => _blendSrcAlpha;
            set => TrySetValue(ref _blendSrcAlpha, ref value, () => base.BlendSrcAlpha = value);
        }

        public override BlendingFactor BlendSrcRgb
        {
            get => _blendSrcRgb;
            set => TrySetValue(ref _blendSrcRgb, ref value, () => base.BlendSrcRgb = value);
        }

        public override Vector4 ColorClearValue
        {
            get => _colorClearValue;
            set => TrySetValue(ref _colorClearValue, ref value, () => base.ColorClearValue = value);
        }

        public override ColorWriteMask ColorWritemask
        {
            get => _colorWritemask;
            set => TrySetValue(ref _colorWritemask, ref value, () => base.ColorWritemask = value);
        }

        public override bool CullFace
        {
            get => _cullFace;
            set => TrySetValue(ref _cullFace, ref value, () => base.CullFace = value);
        }

        public override CullFaceMode CullFaceMode
        {
            get => _cullFaceMode;
            set => TrySetValue(ref _cullFaceMode, ref value, () => base.CullFaceMode = value);
        }

        public override uint CurrentProgram
        {
            get => _currentProgram;
            set => TrySetValue(ref _currentProgram, ref value, () => base.CurrentProgram = value);
        }

        public override float DepthClearValue
        {
            get => _depthClearValue;
            set => TrySetValue(ref _depthClearValue, ref value, () => base.DepthClearValue = value);
        }

        public override DepthFunction DepthFunc
        {
            get => _depthFunc;
            set => TrySetValue(ref _depthFunc, ref value, () => base.DepthFunc = value);
        }

        public override Vector2 DepthRange
        {
            get => _depthRange;
            set => TrySetValue(ref _depthRange, ref value, () => base.DepthRange = value);
        }

        public override bool DepthTest
        {
            get => _depthTest;
            set => TrySetValue(ref _depthTest, ref value, () => base.DepthTest = value);
        }

        public override bool DepthWritemask
        {
            get => _depthWritemask;
            set => TrySetValue(ref _depthWritemask, ref value, () => base.DepthWritemask = value);
        }

        public override bool Dither
        {
            get => _dither;
            set => TrySetValue(ref _dither, ref value, () => base.Dither = value);
        }

        public override uint ElementArrayBufferBinding
        {
            get => _elementArrayBufferBinding;
            set => TrySetValue(ref _elementArrayBufferBinding, ref value, () => base.ElementArrayBufferBinding = value);
        }

        public override uint FramebufferBinding
        {
            get => _framebufferBinding;
            set => TrySetValue(ref _framebufferBinding, ref value, () => base.FramebufferBinding = value);
        }

        public override FrontFaceDirection FrontFace
        {
            get => _frontFace;
            set => TrySetValue(ref _frontFace, ref value, () => base.FrontFace = value);
        }

        public override HintMode GenerateMipmapHint
        {
            get => _generateMipmapHint;
            set => TrySetValue(ref _generateMipmapHint, ref value, () => base.GenerateMipmapHint = value);
        }

        public override float LineWidth
        {
            get => _lineWidth;
            set => TrySetValue(ref _lineWidth, ref value, () => base.LineWidth = value);
        }

        public override uint PackAlignment
        {
            get => _packAlignment;
            set => TrySetValue(ref _packAlignment, ref value, () => base.PackAlignment = value);
        }

        public override float PolygonOffsetFactor
        {
            get => _polygonOffsetFactor;
            set => TrySetValue(ref _polygonOffsetFactor, ref value, () => base.PolygonOffsetFactor = value);
        }

        public override bool PolygonOffsetFill
        {
            get => _polygonOffsetFill;
            set => TrySetValue(ref _polygonOffsetFill, ref value, () => base.PolygonOffsetFill = value);
        }

        public override float PolygonOffsetUnits
        {
            get => _polygonOffsetUnits;
            set => TrySetValue(ref _polygonOffsetUnits, ref value, () => base.PolygonOffsetUnits = value);
        }

        public override uint RenderbufferBinding
        {
            get => _renderbufferBinding;
            set => TrySetValue(ref _renderbufferBinding, ref value, () => base.RenderbufferBinding = value);
        }

        public override bool SampleAlphaToCoverage
        {
            get => _sampleAlphaToCoverage;
            set => TrySetValue(ref _sampleAlphaToCoverage, ref value, () => base.SampleAlphaToCoverage = value);
        }

        public override Rectangle ScissorBox
        {
            get => _scissorBox;
            set => TrySetValue(ref _scissorBox, ref value, () => base.ScissorBox = value);
        }

        public override bool ScissorTest
        {
            get => _scissorTest;
            set => TrySetValue(ref _scissorTest, ref value, () => base.ScissorTest = value);
        }

        public override StencilOp StencilBackFail
        {
            get => _stencilBackFail;
            set => TrySetValue(ref _stencilBackFail, ref value, () => base.StencilBackFail = value);
        }

        public override StencilFunction StencilBackFunc
        {
            get => _stencilBackFunc;
            set => TrySetValue(ref _stencilBackFunc, ref value, () => base.StencilBackFunc = value);
        }

        public override StencilOp StencilBackPassDepthFail
        {
            get => _stencilBackPassDepthFail;
            set => TrySetValue(ref _stencilBackPassDepthFail, ref value, () => base.StencilBackPassDepthFail = value);
        }

        public override StencilOp StencilBackPassDepthPass
        {
            get => _stencilBackPassDepthPass;
            set => TrySetValue(ref _stencilBackPassDepthPass, ref value, () => base.StencilBackPassDepthPass = value);
        }

        public override int StencilBackRef
        {
            get => _stencilBackRef;
            set => TrySetValue(ref _stencilBackRef, ref value, () => base.StencilBackRef = value);
        }

        public override uint StencilBackValueMask
        {
            get => _stencilBackValueMask;
            set => TrySetValue(ref _stencilBackValueMask, ref value, () => base.StencilBackValueMask = value);
        }

        public override uint StencilBackWriteMask
        {
            get => _stencilBackWriteMask;
            set => TrySetValue(ref _stencilBackWriteMask, ref value, () => base.StencilBackWriteMask = value);
        }

        public override int StencilClearValue
        {
            get => _stencilClearValue;
            set => TrySetValue(ref _stencilClearValue, ref value, () => base.StencilClearValue = value);
        }

        public override StencilOp StencilFail
        {
            get => _stencilFail;
            set => TrySetValue(ref _stencilFail, ref value, () => base.StencilFail = value);
        }

        public override StencilFunction StencilFuncValue
        {
            get => _stencilFunc;
            set => TrySetValue(ref _stencilFunc, ref value, () => base.StencilFuncValue = value);
        }

        public override StencilOp StencilPassDepthFail
        {
            get => _stencilPassDepthFail;
            set => TrySetValue(ref _stencilPassDepthFail, ref value, () => base.StencilPassDepthFail = value);
        }

        public override StencilOp StencilPassDepthPass
        {
            get => _stencilPassDepthPass;
            set => TrySetValue(ref _stencilPassDepthPass, ref value, () => base.StencilPassDepthPass = value);
        }

        public override int StencilRef
        {
            get => _stencilRef;
            set => TrySetValue(ref _stencilRef, ref value, () => base.StencilRef = value);
        }

        public override bool StencilTest
        {
            get => _stencilTest;
            set => TrySetValue(ref _stencilTest, ref value, () => base.StencilTest = value);
        }

        public override uint StencilValueMask
        {
            get => _stencilValueMask;
            set => TrySetValue(ref _stencilValueMask, ref value, () => base.StencilValueMask = value);
        }

        public override uint StencilWriteMask
        {
            get => _stencilWriteMask;
            set => TrySetValue(ref _stencilWriteMask, ref value, () => base.StencilWriteMask = value);
        }

        public override uint TextureBinding2D
        {
            get => _textureBinding2D;
            set
            {
                TrySetValue(ref _textureBinding2D, ref value, () => base.TextureBinding2D = value);
                _accessor[ActiveTexture] = value;
            }
        }

        public override uint TextureBindingCubeMap
        {
            get => _textureBindingCubeMap;
            set => TrySetValue(ref _textureBindingCubeMap, ref value, () => base.TextureBindingCubeMap = value);
        }

        public override uint UnpackAlignment
        {
            get => _unpackAlignment;
            set => TrySetValue(ref _unpackAlignment, ref value, () => base.UnpackAlignment = value);
        }

        public override Rectangle Viewport
        {
            get => _viewport;
            set => TrySetValue(ref _viewport, ref value, () => base.Viewport = value);
        }

        public override void BlendFuncSeparate(BlendingFactor blendSrcRgb,
            BlendingFactor blendDstRgb,
            BlendingFactor blendSrcAlpha,
            BlendingFactor blendDstAlpha)
        {
            var srcRgbChanged = blendSrcRgb != _blendSrcRgb;
            var dstRgbChanged = blendDstRgb != _blendDstRgb;
            var srcAlphaChanged = blendSrcAlpha != _blendSrcAlpha;
            var dstAlphaChanged = blendDstAlpha != _blendDstAlpha;

            if (srcRgbChanged || dstRgbChanged || srcAlphaChanged || dstAlphaChanged)
            {
                base.BlendFuncSeparate(blendSrcRgb, blendDstRgb, blendSrcAlpha, blendDstAlpha);
                OnPropertyChanged(nameof(BlendFunc));
            }

            _blendSrcRgb = blendSrcRgb;
            _blendDstRgb = blendDstRgb;
            _blendSrcAlpha = blendSrcAlpha;
            _blendDstAlpha = blendDstAlpha;

            if(srcRgbChanged)
                OnPropertyChanged(nameof(BlendSrcRgb));

            if(dstRgbChanged)
                OnPropertyChanged(nameof(BlendDstRgb));

            if(srcAlphaChanged)
                OnPropertyChanged(nameof(BlendSrcAlpha));

            if (dstAlphaChanged)
                OnPropertyChanged(nameof(BlendDstAlpha));
        }

        public override void BlendFunc(BlendingFactor blendSrc,
            BlendingFactor blendDst)
        {
            BlendFuncSeparate(blendSrc, blendDst, blendSrc, blendDst);
        }

        public override void BlendEquationSeparate(BlendEquationModeEXT blendEquationRgb,
            BlendEquationModeEXT blendEquationAlpha)
        {
            var rgbChanged = blendEquationRgb != _blendEquationRgb;
            var alphaChanged = blendEquationAlpha != _blendEquationAlpha;

            if (rgbChanged || alphaChanged)
            {
                base.BlendEquationSeparate(blendEquationRgb, blendEquationAlpha);
                OnPropertyChanged(nameof(BlendEquation));
            }

            _blendEquationRgb = blendEquationRgb;
            _blendEquationAlpha = blendEquationAlpha;

            if(rgbChanged)
                OnPropertyChanged(nameof(BlendEquationRgb));

            if(alphaChanged)
                OnPropertyChanged(nameof(BlendEquationAlpha));
        }

        public override void BlendEquation(BlendEquationModeEXT blendEquation)
        {
            BlendEquationSeparate(blendEquation, blendEquation);
        }

        public override void PolygonOffset(float factor, float units)
        {
            var factorChanged = factor != _polygonOffsetFactor;
            var unitsChanged = units != _polygonOffsetUnits;

            if (factorChanged || unitsChanged)
            {
                base.PolygonOffset(factor, units);
            }

            _polygonOffsetFactor = factor;
            _polygonOffsetUnits = units;

            if(factorChanged)
                OnPropertyChanged(nameof(PolygonOffsetFactor));

            if(unitsChanged)
                OnPropertyChanged(nameof(PolygonOffsetUnits));
        }

        public override void StencilOpSeparate(StencilFaceDirection direction,
            StencilOp stencilFail,
            StencilOp depthFail,
            StencilOp pass)
        {
            bool stencilFailChange = false, depthFailChange = false, passChange = false; 

            if (direction == StencilFaceDirection.GL_FRONT)
            {
                stencilFailChange = stencilFail != _stencilFail;
                depthFailChange = depthFail != _stencilPassDepthFail;
                passChange = pass != _stencilPassDepthPass;
            }
            else if (direction == StencilFaceDirection.GL_BACK)
            {
                stencilFailChange = stencilFail != _stencilBackFail;
                depthFailChange = depthFail != _stencilBackPassDepthFail;
                passChange = pass != _stencilBackPassDepthPass;
            }
            else if (direction == StencilFaceDirection.GL_FRONT_AND_BACK)
            {
                stencilFailChange = stencilFail != _stencilFail || stencilFail != _stencilBackFail;
                depthFailChange = depthFail != _stencilPassDepthFail || depthFail != _stencilBackPassDepthFail;
                passChange = pass != _stencilPassDepthPass || pass != _stencilBackPassDepthPass;
            }

            if (stencilFailChange || depthFailChange || passChange)
            {
                base.StencilOpSeparate(direction, stencilFail, depthFail, pass);
                OnPropertyChanged(nameof(StencilOp));
            }

            if (direction == StencilFaceDirection.GL_FRONT)
            {
                _stencilFail = stencilFail;
                _stencilPassDepthFail = depthFail;
                _stencilPassDepthPass = pass;

                if(stencilFailChange)
                    OnPropertyChanged(nameof(StencilFail));

                if(depthFailChange)
                    OnPropertyChanged(nameof(StencilPassDepthFail));

                if(passChange)
                    OnPropertyChanged(nameof(StencilPassDepthPass));
            }
            else if (direction == StencilFaceDirection.GL_BACK)
            {
                _stencilBackFail = stencilFail;
                _stencilBackPassDepthFail = depthFail;
                _stencilBackPassDepthPass = pass;

                if (stencilFailChange)
                    OnPropertyChanged(nameof(StencilBackFail));

                if (depthFailChange)
                    OnPropertyChanged(nameof(StencilBackPassDepthFail));

                if (passChange)
                    OnPropertyChanged(nameof(StencilBackPassDepthPass));
            }
            else if (direction == StencilFaceDirection.GL_FRONT_AND_BACK)
            {
                _stencilFail = stencilFail;
                _stencilBackFail = stencilFail;
                _stencilPassDepthFail = depthFail;
                _stencilBackPassDepthFail = depthFail;
                _stencilPassDepthPass = pass;
                _stencilBackPassDepthPass = pass;

                if (stencilFailChange)
                {
                    OnPropertyChanged(nameof(StencilFail));
                    OnPropertyChanged(nameof(StencilBackFail));
                }

                if (depthFailChange)
                {
                    OnPropertyChanged(nameof(StencilPassDepthFail));
                    OnPropertyChanged(nameof(StencilBackPassDepthFail));
                }

                if (passChange)
                {
                    OnPropertyChanged(nameof(StencilPassDepthPass));
                    OnPropertyChanged(nameof(StencilBackPassDepthPass));
                }
            }
        }

        public override void StencilOp(StencilOp stencilFail,
            StencilOp depthFail,
            StencilOp pass)
        {
            StencilOpSeparate(StencilFaceDirection.GL_FRONT_AND_BACK, stencilFail, depthFail, pass);
        }

        public override void StencilFuncSeparate(StencilFaceDirection direction,
            StencilFunction func, int @ref, uint mask)
        {
            bool funcChange = false, refChange = false, maskChange = false;

            if (direction == StencilFaceDirection.GL_FRONT)
            {
                funcChange = func != _stencilFunc;
                refChange = @ref != _stencilRef;
                maskChange = mask != _stencilValueMask;
            }
            else if (direction == StencilFaceDirection.GL_BACK)
            {
                funcChange = func != _stencilBackFunc;
                refChange = @ref != _stencilBackRef;
                maskChange = mask != _stencilBackValueMask;
            }
            else if (direction == StencilFaceDirection.GL_FRONT_AND_BACK)
            {
                funcChange = func != _stencilFunc || func != _stencilBackFunc;
                refChange = @ref != _stencilRef || @ref != _stencilBackRef;
                maskChange = mask != _stencilValueMask || mask != _stencilBackValueMask;
            }

            if (funcChange || refChange || maskChange)
            {
                base.StencilFuncSeparate(direction, func, @ref, mask);
                OnPropertyChanged(nameof(StencilFunc));
            }

            if (direction == StencilFaceDirection.GL_FRONT)
            {
                _stencilFunc = func;
                _stencilRef = @ref;
                _stencilValueMask = mask;

                if (funcChange)
                    OnPropertyChanged(nameof(StencilFunc));

                if (refChange)
                    OnPropertyChanged(nameof(StencilRef));

                if (maskChange)
                    OnPropertyChanged(nameof(StencilValueMask));
            }
            else if (direction == StencilFaceDirection.GL_BACK)
            {
                _stencilBackFunc = func;
                _stencilBackRef = @ref;
                _stencilBackValueMask = mask;

                if (funcChange)
                    OnPropertyChanged(nameof(StencilBackFunc));

                if (refChange)
                    OnPropertyChanged(nameof(StencilBackRef));

                if (maskChange)
                    OnPropertyChanged(nameof(StencilBackValueMask));
            }
            else if (direction == StencilFaceDirection.GL_FRONT_AND_BACK)
            {
                _stencilFunc = func;
                _stencilBackFunc = func;
                _stencilRef = @ref;
                _stencilBackRef = @ref;
                _stencilValueMask = mask;
                _stencilBackValueMask = mask;

                if (funcChange)
                {
                    OnPropertyChanged(nameof(StencilFunc));
                    OnPropertyChanged(nameof(StencilBackFunc));
                }

                if (refChange)
                {
                    OnPropertyChanged(nameof(StencilRef));
                    OnPropertyChanged(nameof(StencilBackRef));
                }

                if (maskChange)
                {
                    OnPropertyChanged(nameof(StencilValueMask));
                    OnPropertyChanged(nameof(StencilBackValueMask));
                }
            }
        }

        public override void StencilFunc(StencilFunction func,
            int @ref, uint mask)
        {
            StencilFuncSeparate(StencilFaceDirection.GL_FRONT_AND_BACK, func, @ref, mask);
        }

        public void SyncState()
        {
            _activeTexture = base.ActiveTexture;
            _arrayBufferBinding = base.ArrayBufferBinding;
            _blend = base.Blend;
            _blendColor = base.BlendColor;
            _blendDstAlpha = base.BlendDstAlpha;
            _blendDstRgb = base.BlendDstRgb;
            _blendEquationAlpha = base.BlendEquationAlpha;
            _blendEquationRgb = base.BlendEquationRgb;
            _blendSrcRgb = base.BlendSrcRgb;
            _blendSrcAlpha = base.BlendSrcAlpha;
            _colorClearValue = base.ColorClearValue;
            _colorWritemask = base.ColorWritemask;
            _cullFace = base.CullFace;
            _cullFaceMode = base.CullFaceMode;
            _currentProgram = base.CurrentProgram;
            _depthClearValue = base.DepthClearValue;
            _depthFunc = base.DepthFunc;
            _depthRange = base.DepthRange;
            _depthTest = base.DepthTest;
            _depthWritemask = base.DepthWritemask;
            _dither = base.Dither;
            _elementArrayBufferBinding = base.ElementArrayBufferBinding;
            _framebufferBinding = base.FramebufferBinding;
            _frontFace = base.FrontFace;
            _generateMipmapHint = base.GenerateMipmapHint;
            _lineWidth = base.LineWidth;
            _packAlignment = base.PackAlignment;
            _polygonOffsetFactor = base.PolygonOffsetFactor;
            _polygonOffsetFill = base.PolygonOffsetFill;
            _polygonOffsetUnits = base.PolygonOffsetUnits;
            _renderbufferBinding = base.RenderbufferBinding;
            _sampleAlphaToCoverage = base.SampleAlphaToCoverage;
            _scissorBox = base.ScissorBox;
            _scissorTest = base.ScissorTest;
            _stencilBackFail = base.StencilBackFail;
            _stencilBackFunc = base.StencilBackFunc;
            _stencilBackPassDepthFail = base.StencilBackPassDepthFail;
            _stencilBackPassDepthPass = base.StencilBackPassDepthPass;
            _stencilBackRef = base.StencilBackRef;
            _stencilBackValueMask = base.StencilBackValueMask;
            _stencilBackWriteMask = base.StencilBackWriteMask;
            _stencilClearValue = base.StencilClearValue;
            _stencilFail = base.StencilFail;
            _stencilFunc = base.StencilFuncValue;
            _stencilPassDepthFail = base.StencilPassDepthFail;
            _stencilPassDepthPass = base.StencilPassDepthPass;
            _stencilRef = base.StencilRef;
            _stencilTest = base.StencilTest;
            _stencilValueMask = base.StencilValueMask;
            _stencilWriteMask = base.StencilWriteMask;
            _textureBinding2D = base.TextureBinding2D;
            _textureBindingCubeMap = base.TextureBindingCubeMap;
            _unpackAlignment = base.UnpackAlignment;
            _viewport = base.Viewport;
        }

        public void ApplyState(IGlState state)
        {
            _activeTexture = state.ActiveTexture;
            _arrayBufferBinding = state.ArrayBufferBinding;
            _blend = state.Blend;
            _blendColor = state.BlendColor;
            _blendDstAlpha = state.BlendDstAlpha;
            _blendDstRgb = state.BlendDstRgb;
            _blendEquationAlpha = state.BlendEquationAlpha;
            _blendEquationRgb = state.BlendEquationRgb;
            _blendSrcRgb = state.BlendSrcRgb;
            _blendSrcAlpha = state.BlendSrcAlpha;
            _colorClearValue = state.ColorClearValue;
            _colorWritemask = state.ColorWritemask;
            _cullFace = state.CullFace;
            _cullFaceMode = state.CullFaceMode;
            _currentProgram = state.CurrentProgram;
            _depthClearValue = state.DepthClearValue;
            _depthFunc = state.DepthFunc;
            _depthRange = state.DepthRange;
            _depthTest = state.DepthTest;
            _depthWritemask = state.DepthWritemask;
            _dither = state.Dither;
            _elementArrayBufferBinding = state.ElementArrayBufferBinding;
            _framebufferBinding = state.FramebufferBinding;
            _frontFace = state.FrontFace;
            _generateMipmapHint = state.GenerateMipmapHint;
            _lineWidth = state.LineWidth;
            _packAlignment = state.PackAlignment;
            _polygonOffsetFactor = state.PolygonOffsetFactor;
            _polygonOffsetFill = state.PolygonOffsetFill;
            _polygonOffsetUnits = state.PolygonOffsetUnits;
            _renderbufferBinding = state.RenderbufferBinding;
            _sampleAlphaToCoverage = state.SampleAlphaToCoverage;
            _scissorBox = state.ScissorBox;
            _scissorTest = state.ScissorTest;
            _stencilBackFail = state.StencilBackFail;
            _stencilBackFunc = state.StencilBackFunc;
            _stencilBackPassDepthFail = state.StencilBackPassDepthFail;
            _stencilBackPassDepthPass = state.StencilBackPassDepthPass;
            _stencilBackRef = state.StencilBackRef;
            _stencilBackValueMask = state.StencilBackValueMask;
            _stencilBackWriteMask = state.StencilBackWriteMask;
            _stencilClearValue = state.StencilClearValue;
            _stencilFail = state.StencilFail;
            _stencilFunc = state.StencilFuncValue;
            _stencilPassDepthFail = state.StencilPassDepthFail;
            _stencilPassDepthPass = state.StencilPassDepthPass;
            _stencilRef = state.StencilRef;
            _stencilTest = state.StencilTest;
            _stencilValueMask = state.StencilValueMask;
            _stencilWriteMask = state.StencilWriteMask;
            _textureBinding2D = state.TextureBinding2D;
            _textureBindingCubeMap = state.TextureBindingCubeMap;
            _unpackAlignment = state.UnpackAlignment;
            _viewport = state.Viewport;
        }

        //public ApplyState(IGlState state)
        //{

        //}

        //private SetState(IGlState state)
        //{

        //}
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TrySetValue<T>(ref T oldValue, ref T newValue, Action setter, [CallerMemberName]string propertyName = null)
        {
            if (!oldValue.Equals(newValue))
            {
                setter();
                oldValue = newValue;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
