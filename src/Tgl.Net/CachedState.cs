using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tgl.Net.Math;

namespace Tgl.Net.Core
{
    public class CachedState : GlState, INotifyPropertyChanged
    {
        private GL.TextureUnit _activeTexture;
        private uint _arrayBufferBinding;
        private bool _blend;
        private Vector4 _blendColor;
        private GL.BlendingFactor _blendDstAlpha;
        private GL.BlendingFactor _blendDstRgb;
        private GL.BlendEquationModeEXT _blendEquationAlpha;
        private GL.BlendEquationModeEXT _blendEquationRgb;
        private GL.BlendingFactor _blendSrcRgb;
        private GL.BlendingFactor _blendSrcAlpha;
        private Vector4 _colorClearValue;
        private Vector4b _colorWritemask;
        private bool _cullFace;
        private GL.CullFaceMode _cullFaceMode;
        private uint _currentProgram;
        private float _depthClearValue;
        private GL.DepthFunction _depthFunc;
        private Vector2 _depthRange;
        private bool _depthTest;
        private bool _depthWritemask;
        private bool _dither;
        private uint _elementArrayBufferBinding;
        private uint _framebufferBinding;
        private GL.FrontFaceDirection _frontFace;
        private GL.HintMode _generateMipmapHint;
        private float _lineWidth;
        private uint _packAlignment;
        private float _polygonOffsetFactor;
        private bool _polygonOffsetFill;
        private float _polygonOffsetUnits;
        private uint _renderbufferBinding;
        private bool _sampleAlphaToCoverage;
        private Vector4i _scissorBox;
        private bool _scissorTest;
        private GL.StencilOp _stencilBackFail;
        private GL.StencilFunction _stencilBackFunc;
        private GL.StencilOp _stencilBackPassDepthFail;
        private GL.StencilOp _stencilBackPassDepthPass;
        private int _stencilBackRef;
        private uint _stencilBackValueMask;
        private uint _stencilBackWriteMask;
        private int _stencilClearValue;
        private GL.StencilOp _stencilFail;
        private GL.StencilFunction _stencilFunc;
        private GL.StencilOp _stencilPassDepthFail;
        private GL.StencilOp _stencilPassDepthPass;
        private int _stencilRef;
        private bool _stencilTest;
        private uint _stencilValueMask;
        private uint _stencilWriteMask;
        private uint _textureBinding2D;
        private uint _textureBindingCubeMap;
        private uint _unpackAlignment;
        private Vector4i _viewport;

        public CachedState()
        {
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

        public override GL.TextureUnit ActiveTexture
        {
            get => _activeTexture;
            set => _activeTexture = value;
        }

        public override uint ArrayBufferBinding
        {
            get => _arrayBufferBinding;
            set => _arrayBufferBinding = value;
        }

        public override bool Blend
        {
            get => _blend;
            set => _blend = value;
        }

        public override Vector4 BlendColor
        {
            get => _blendColor;
            set => _blendColor = value;
        }

        public override GL.BlendingFactor BlendDstAlpha
        {
            get => _blendDstAlpha;
            set => _blendDstAlpha = value;
        }

        public override GL.BlendingFactor BlendDstRgb
        {
            get => _blendDstRgb;
            set => _blendDstRgb = value;
        }

        public override GL.BlendEquationModeEXT BlendEquationAlpha
        {
            get => _blendEquationAlpha;
            set => _blendEquationAlpha = value;
        }

        public override GL.BlendEquationModeEXT BlendEquationRgb
        {
            get => _blendEquationRgb;
            set => _blendEquationRgb = value;
        }

        public override GL.BlendingFactor BlendSrcAlpha
        {
            get => _blendSrcAlpha;
            set => _blendSrcAlpha = value;
        }

        public override GL.BlendingFactor BlendSrcRgb
        {
            get => _blendSrcRgb;
            set => _blendSrcRgb = value;
        }

        public override Vector4 ColorClearValue
        {
            get => _colorClearValue;
            set => _colorClearValue = value;
        }

        public override Vector4b ColorWritemask
        {
            get => _colorWritemask;
            set => _colorWritemask = value;
        }

        public override bool CullFace
        {
            get => _cullFace;
            set => _cullFace = value;
        }

        public override GL.CullFaceMode CullFaceMode
        {
            get => _cullFaceMode;
            set => _cullFaceMode = value;
        }

        public override uint CurrentProgram
        {
            get => _currentProgram;
            set => _currentProgram = value;
        }

        public override float DepthClearValue
        {
            get => _depthClearValue;
            set => _depthClearValue = value;
        }

        public override GL.DepthFunction DepthFunc
        {
            get => _depthFunc;
            set => _depthFunc = value;
        }

        public override Vector2 DepthRange
        {
            get => _depthRange;
            set => _depthRange = value;
        }

        public override bool DepthTest
        {
            get => _depthTest;
            set => _depthTest = value;
        }

        public override bool DepthWritemask
        {
            get => _depthWritemask;
            set => _depthWritemask = value;
        }

        public override bool Dither
        {
            get => _dither;
            set => _dither = value;
        }

        public override uint ElementArrayBufferBinding
        {
            get => _elementArrayBufferBinding;
            set => _elementArrayBufferBinding = value;
        }

        public override uint FramebufferBinding
        {
            get => _framebufferBinding;
            set => _framebufferBinding = value;
        }

        public override GL.FrontFaceDirection FrontFace
        {
            get => _frontFace;
            set => _frontFace = value;
        }

        public override GL.HintMode GenerateMipmapHint
        {
            get => _generateMipmapHint;
            set => _generateMipmapHint = value;
        }

        public override float LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        public override uint PackAlignment
        {
            get => _packAlignment;
            set => _packAlignment = value;
        }

        public override float PolygonOffsetFactor
        {
            get => _polygonOffsetFactor;
            set => _polygonOffsetFactor = value;
        }

        public override bool PolygonOffsetFill
        {
            get => _polygonOffsetFill;
            set => _polygonOffsetFill = value;
        }

        public override float PolygonOffsetUnits
        {
            get => _polygonOffsetUnits;
            set => _polygonOffsetUnits = value;
        }

        public override uint RenderbufferBinding
        {
            get => _renderbufferBinding;
            set => _renderbufferBinding = value;
        }

        public override bool SampleAlphaToCoverage
        {
            get => _sampleAlphaToCoverage;
            set => _sampleAlphaToCoverage = value;
        }

        public override Vector4i ScissorBox
        {
            get => _scissorBox;
            set => _scissorBox = value;
        }

        public override bool ScissorTest
        {
            get => _scissorTest;
            set => _scissorTest = value;
        }

        public override GL.StencilOp StencilBackFail
        {
            get => _stencilBackFail;
            set => _stencilBackFail = value;
        }

        public override GL.StencilFunction StencilBackFunc
        {
            get => _stencilBackFunc;
            set => _stencilBackFunc = value;
        }

        public override GL.StencilOp StencilBackPassDepthFail
        {
            get => _stencilBackPassDepthFail;
            set => _stencilBackPassDepthFail = value;
        }

        public override GL.StencilOp StencilBackPassDepthPass
        {
            get => _stencilBackPassDepthPass;
            set => _stencilBackPassDepthPass = value;
        }

        public override int StencilBackRef
        {
            get => _stencilBackRef;
            set => _stencilBackRef = value;
        }

        public override uint StencilBackValueMask
        {
            get => _stencilBackValueMask;
            set => _stencilBackValueMask = value;
        }

        public override uint StencilBackWriteMask
        {
            get => _stencilBackWriteMask;
            set => _stencilBackWriteMask = value;
        }

        public override int StencilClearValue
        {
            get => _stencilClearValue;
            set => _stencilClearValue = value;
        }

        public override GL.StencilOp StencilFail
        {
            get => _stencilFail;
            set => _stencilFail = value;
        }

        public override GL.StencilFunction StencilFuncValue
        {
            get => _stencilFunc;
            set => _stencilFunc = value;
        }

        public override GL.StencilOp StencilPassDepthFail
        {
            get => _stencilPassDepthFail;
            set => _stencilPassDepthFail = value;
        }

        public override GL.StencilOp StencilPassDepthPass
        {
            get => _stencilPassDepthPass;
            set => _stencilPassDepthPass = value;
        }

        public override int StencilRef
        {
            get => _stencilRef;
            set => _stencilRef = value;
        }

        public override bool StencilTest
        {
            get => _stencilTest;
            set => _stencilTest = value;
        }

        public override uint StencilValueMask
        {
            get => _stencilValueMask;
            set => _stencilValueMask = value;
        }

        public override uint StencilWriteMask
        {
            get => _stencilWriteMask;
            set => _stencilWriteMask = value;
        }

        public override uint TextureBinding2D
        {
            get => _textureBinding2D;
            set => _textureBinding2D = value;
        }

        public override uint TextureBindingCubeMap
        {
            get => _textureBindingCubeMap;
            set => _textureBindingCubeMap = value;
        }

        public override uint UnpackAlignment
        {
            get => _unpackAlignment;
            set => _unpackAlignment = value;
        }

        public override Vector4i Viewport
        {
            get => _viewport;
            set => _viewport = value;
        }

        //public override RefreshState()
        //{

        //}

        //public ApplyState(IGlState state)
        //{

        //}

        //private SetState(IGlState state)
        //{

        //}
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
