public static class GL
{
    #region Constants
    public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 35722;
    public const uint GL_ACTIVE_ATTRIBUTES = 35721;
    public const uint GL_ACTIVE_TEXTURE = 34016;
    public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 35719;
    public const uint GL_ACTIVE_UNIFORMS = 35718;
    public const uint GL_ALIASED_LINE_WIDTH_RANGE = 33902;
    public const uint GL_ALIASED_POINT_SIZE_RANGE = 33901;
    public const uint GL_ALPHA = 6406;
    public const uint GL_ALPHA_BITS = 3413;
    public const uint GL_ALWAYS = 519;
    public const uint GL_ARRAY_BUFFER = 34962;
    public const uint GL_ARRAY_BUFFER_BINDING = 34964;
    public const uint GL_ATTACHED_SHADERS = 35717;
    public const uint GL_BACK = 1029;
    public const uint GL_BLEND = 3042;
    public const uint GL_BLEND_COLOR = 32773;
    public const uint GL_BLEND_DST_ALPHA = 32970;
    public const uint GL_BLEND_DST_RGB = 32968;
    public const uint GL_BLEND_EQUATION = 32777;
    public const uint GL_BLEND_EQUATION_ALPHA = 34877;
    public const uint GL_BLEND_EQUATION_RGB = 32777;
    public const uint GL_BLEND_SRC_ALPHA = 32971;
    public const uint GL_BLEND_SRC_RGB = 32969;
    public const uint GL_BLUE_BITS = 3412;
    public const uint GL_BOOL = 35670;
    public const uint GL_BOOL_VEC2 = 35671;
    public const uint GL_BOOL_VEC3 = 35672;
    public const uint GL_BOOL_VEC4 = 35673;
    public const uint GL_BUFFER_SIZE = 34660;
    public const uint GL_BUFFER_USAGE = 34661;
    public const uint GL_BYTE = 5120;
    public const uint GL_CCW = 2305;
    public const uint GL_CLAMP_TO_EDGE = 33071;
    public const uint GL_COLOR_ATTACHMENT0 = 36064;
    public const uint GL_COLOR_BUFFER_BIT = 16384;
    public const uint GL_COLOR_CLEAR_VALUE = 3106;
    public const uint GL_COLOR_WRITEMASK = 3107;
    public const uint GL_COMPILE_STATUS = 35713;
    public const uint GL_COMPRESSED_TEXTURE_FORMATS = 34467;
    public const uint GL_CONSTANT_ALPHA = 32771;
    public const uint GL_CONSTANT_COLOR = 32769;
    public const uint GL_CULL_FACE = 2884;
    public const uint GL_CULL_FACE_MODE = 2885;
    public const uint GL_CURRENT_PROGRAM = 35725;
    public const uint GL_CURRENT_VERTEX_ATTRIB = 34342;
    public const uint GL_CW = 2304;
    public const uint GL_DECR = 7683;
    public const uint GL_DECR_WRAP = 34056;
    public const uint GL_DELETE_STATUS = 35712;
    public const uint GL_DEPTH_ATTACHMENT = 36096;
    public const uint GL_DEPTH_BITS = 3414;
    public const uint GL_DEPTH_BUFFER_BIT = 256;
    public const uint GL_DEPTH_CLEAR_VALUE = 2931;
    public const uint GL_DEPTH_COMPONENT = 6402;
    public const uint GL_DEPTH_COMPONENT16 = 33189;
    public const uint GL_DEPTH_FUNC = 2932;
    public const uint GL_DEPTH_RANGE = 2928;
    public const uint GL_DEPTH_TEST = 2929;
    public const uint GL_DEPTH_WRITEMASK = 2930;
    public const uint GL_DITHER = 3024;
    public const uint GL_DONT_CARE = 4352;
    public const uint GL_DST_ALPHA = 772;
    public const uint GL_DST_COLOR = 774;
    public const uint GL_DYNAMIC_DRAW = 35048;
    public const uint GL_ELEMENT_ARRAY_BUFFER = 34963;
    public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 34965;
    public const uint GL_EQUAL = 514;
    public const uint GL_EXTENSIONS = 7939;
    public const uint GL_FALSE = 0;
    public const uint GL_FASTEST = 4353;
    public const uint GL_FIXED = 5132;
    public const uint GL_FLOAT = 5126;
    public const uint GL_FLOAT_MAT2 = 35674;
    public const uint GL_FLOAT_MAT3 = 35675;
    public const uint GL_FLOAT_MAT4 = 35676;
    public const uint GL_FLOAT_VEC2 = 35664;
    public const uint GL_FLOAT_VEC3 = 35665;
    public const uint GL_FLOAT_VEC4 = 35666;
    public const uint GL_FRAGMENT_SHADER = 35632;
    public const uint GL_FRAMEBUFFER = 36160;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 36049;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 36048;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 36051;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 36050;
    public const uint GL_FRAMEBUFFER_BINDING = 36006;
    public const uint GL_FRAMEBUFFER_COMPLETE = 36053;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 36054;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 36057;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 36055;
    public const uint GL_FRAMEBUFFER_UNSUPPORTED = 36061;
    public const uint GL_FRONT = 1028;
    public const uint GL_FRONT_AND_BACK = 1032;
    public const uint GL_FRONT_FACE = 2886;
    public const uint GL_FUNC_ADD = 32774;
    public const uint GL_FUNC_REVERSE_SUBTRACT = 32779;
    public const uint GL_FUNC_SUBTRACT = 32778;
    public const uint GL_GENERATE_MIPMAP_HINT = 33170;
    public const uint GL_GEQUAL = 518;
    public const uint GL_GREATER = 516;
    public const uint GL_GREEN_BITS = 3411;
    public const uint GL_HIGH_FLOAT = 36338;
    public const uint GL_HIGH_INT = 36341;
    public const uint GL_IMPLEMENTATION_COLOR_READ_FORMAT = 35739;
    public const uint GL_IMPLEMENTATION_COLOR_READ_TYPE = 35738;
    public const uint GL_INCR = 7682;
    public const uint GL_INCR_WRAP = 34055;
    public const uint GL_INFO_LOG_LENGTH = 35716;
    public const uint GL_INT = 5124;
    public const uint GL_INT_VEC2 = 35667;
    public const uint GL_INT_VEC3 = 35668;
    public const uint GL_INT_VEC4 = 35669;
    public const uint GL_INVALID_ENUM = 1280;
    public const uint GL_INVALID_FRAMEBUFFER_OPERATION = 1286;
    public const uint GL_INVALID_OPERATION = 1282;
    public const uint GL_INVALID_VALUE = 1281;
    public const uint GL_INVERT = 5386;
    public const uint GL_KEEP = 7680;
    public const uint GL_LEQUAL = 515;
    public const uint GL_LESS = 513;
    public const uint GL_LINE_LOOP = 2;
    public const uint GL_LINE_STRIP = 3;
    public const uint GL_LINE_WIDTH = 2849;
    public const uint GL_LINEAR = 9729;
    public const uint GL_LINEAR_MIPMAP_LINEAR = 9987;
    public const uint GL_LINEAR_MIPMAP_NEAREST = 9985;
    public const uint GL_LINES = 1;
    public const uint GL_LINK_STATUS = 35714;
    public const uint GL_LOW_FLOAT = 36336;
    public const uint GL_LOW_INT = 36339;
    public const uint GL_LUMINANCE = 6409;
    public const uint GL_LUMINANCE_ALPHA = 6410;
    public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 35661;
    public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 34076;
    public const uint GL_MAX_FRAGMENT_UNIFORM_VECTORS = 36349;
    public const uint GL_MAX_RENDERBUFFER_SIZE = 34024;
    public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 34930;
    public const uint GL_MAX_TEXTURE_SIZE = 3379;
    public const uint GL_MAX_VARYING_VECTORS = 36348;
    public const uint GL_MAX_VERTEX_ATTRIBS = 34921;
    public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 35660;
    public const uint GL_MAX_VERTEX_UNIFORM_VECTORS = 36347;
    public const uint GL_MAX_VIEWPORT_DIMS = 3386;
    public const uint GL_MEDIUM_FLOAT = 36337;
    public const uint GL_MEDIUM_INT = 36340;
    public const uint GL_MIRRORED_REPEAT = 33648;
    public const uint GL_NEAREST = 9728;
    public const uint GL_NEAREST_MIPMAP_LINEAR = 9986;
    public const uint GL_NEAREST_MIPMAP_NEAREST = 9984;
    public const uint GL_NEVER = 512;
    public const uint GL_NICEST = 4354;
    public const uint GL_NO_ERROR = 0;
    public const uint GL_NONE = 0;
    public const uint GL_NOTEQUAL = 517;
    public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 34466;
    public const uint GL_NUM_SHADER_BINARY_FORMATS = 36345;
    public const uint GL_ONE = 1;
    public const uint GL_ONE_MINUS_CONSTANT_ALPHA = 32772;
    public const uint GL_ONE_MINUS_CONSTANT_COLOR = 32770;
    public const uint GL_ONE_MINUS_DST_ALPHA = 773;
    public const uint GL_ONE_MINUS_DST_COLOR = 775;
    public const uint GL_ONE_MINUS_SRC_ALPHA = 771;
    public const uint GL_ONE_MINUS_SRC_COLOR = 769;
    public const uint GL_OUT_OF_MEMORY = 1285;
    public const uint GL_PACK_ALIGNMENT = 3333;
    public const uint GL_POINTS = 0;
    public const uint GL_POLYGON_OFFSET_FACTOR = 32824;
    public const uint GL_POLYGON_OFFSET_FILL = 32823;
    public const uint GL_POLYGON_OFFSET_UNITS = 10752;
    public const uint GL_RED_BITS = 3410;
    public const uint GL_RENDERBUFFER = 36161;
    public const uint GL_RENDERBUFFER_ALPHA_SIZE = 36179;
    public const uint GL_RENDERBUFFER_BINDING = 36007;
    public const uint GL_RENDERBUFFER_BLUE_SIZE = 36178;
    public const uint GL_RENDERBUFFER_DEPTH_SIZE = 36180;
    public const uint GL_RENDERBUFFER_GREEN_SIZE = 36177;
    public const uint GL_RENDERBUFFER_HEIGHT = 36163;
    public const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 36164;
    public const uint GL_RENDERBUFFER_RED_SIZE = 36176;
    public const uint GL_RENDERBUFFER_STENCIL_SIZE = 36181;
    public const uint GL_RENDERBUFFER_WIDTH = 36162;
    public const uint GL_RENDERER = 7937;
    public const uint GL_REPEAT = 10497;
    public const uint GL_REPLACE = 7681;
    public const uint GL_RGB = 6407;
    public const uint GL_RGB5_A1 = 32855;
    public const uint GL_RGB565 = 36194;
    public const uint GL_RGBA = 6408;
    public const uint GL_RGBA4 = 32854;
    public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 32926;
    public const uint GL_SAMPLE_BUFFERS = 32936;
    public const uint GL_SAMPLE_COVERAGE = 32928;
    public const uint GL_SAMPLE_COVERAGE_INVERT = 32939;
    public const uint GL_SAMPLE_COVERAGE_VALUE = 32938;
    public const uint GL_SAMPLER_2D = 35678;
    public const uint GL_SAMPLER_CUBE = 35680;
    public const uint GL_SAMPLES = 32937;
    public const uint GL_SCISSOR_BOX = 3088;
    public const uint GL_SCISSOR_TEST = 3089;
    public const uint GL_SHADER_BINARY_FORMATS = 36344;
    public const uint GL_SHADER_COMPILER = 36346;
    public const uint GL_SHADER_SOURCE_LENGTH = 35720;
    public const uint GL_SHADER_TYPE = 35663;
    public const uint GL_SHADING_LANGUAGE_VERSION = 35724;
    public const uint GL_SHORT = 5122;
    public const uint GL_SRC_ALPHA = 770;
    public const uint GL_SRC_ALPHA_SATURATE = 776;
    public const uint GL_SRC_COLOR = 768;
    public const uint GL_STATIC_DRAW = 35044;
    public const uint GL_STENCIL_ATTACHMENT = 36128;
    public const uint GL_STENCIL_BACK_FAIL = 34817;
    public const uint GL_STENCIL_BACK_FUNC = 34816;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 34818;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 34819;
    public const uint GL_STENCIL_BACK_REF = 36003;
    public const uint GL_STENCIL_BACK_VALUE_MASK = 36004;
    public const uint GL_STENCIL_BACK_WRITEMASK = 36005;
    public const uint GL_STENCIL_BITS = 3415;
    public const uint GL_STENCIL_BUFFER_BIT = 1024;
    public const uint GL_STENCIL_CLEAR_VALUE = 2961;
    public const uint GL_STENCIL_FAIL = 2964;
    public const uint GL_STENCIL_FUNC = 2962;
    public const uint GL_STENCIL_INDEX8 = 36168;
    public const uint GL_STENCIL_PASS_DEPTH_FAIL = 2965;
    public const uint GL_STENCIL_PASS_DEPTH_PASS = 2966;
    public const uint GL_STENCIL_REF = 2967;
    public const uint GL_STENCIL_TEST = 2960;
    public const uint GL_STENCIL_VALUE_MASK = 2963;
    public const uint GL_STENCIL_WRITEMASK = 2968;
    public const uint GL_STREAM_DRAW = 35040;
    public const uint GL_SUBPIXEL_BITS = 3408;
    public const uint GL_TEXTURE = 5890;
    public const uint GL_TEXTURE_2D = 3553;
    public const uint GL_TEXTURE_BINDING_2D = 32873;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP = 34068;
    public const uint GL_TEXTURE_CUBE_MAP = 34067;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 34070;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 34072;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 34074;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 34069;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 34071;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 34073;
    public const uint GL_TEXTURE_MAG_FILTER = 10240;
    public const uint GL_TEXTURE_MIN_FILTER = 10241;
    public const uint GL_TEXTURE_WRAP_S = 10242;
    public const uint GL_TEXTURE_WRAP_T = 10243;
    public const uint GL_TEXTURE0 = 33984;
    public const uint GL_TEXTURE1 = 33985;
    public const uint GL_TEXTURE10 = 33994;
    public const uint GL_TEXTURE11 = 33995;
    public const uint GL_TEXTURE12 = 33996;
    public const uint GL_TEXTURE13 = 33997;
    public const uint GL_TEXTURE14 = 33998;
    public const uint GL_TEXTURE15 = 33999;
    public const uint GL_TEXTURE16 = 34000;
    public const uint GL_TEXTURE17 = 34001;
    public const uint GL_TEXTURE18 = 34002;
    public const uint GL_TEXTURE19 = 34003;
    public const uint GL_TEXTURE2 = 33986;
    public const uint GL_TEXTURE20 = 34004;
    public const uint GL_TEXTURE21 = 34005;
    public const uint GL_TEXTURE22 = 34006;
    public const uint GL_TEXTURE23 = 34007;
    public const uint GL_TEXTURE24 = 34008;
    public const uint GL_TEXTURE25 = 34009;
    public const uint GL_TEXTURE26 = 34010;
    public const uint GL_TEXTURE27 = 34011;
    public const uint GL_TEXTURE28 = 34012;
    public const uint GL_TEXTURE29 = 34013;
    public const uint GL_TEXTURE3 = 33987;
    public const uint GL_TEXTURE30 = 34014;
    public const uint GL_TEXTURE31 = 34015;
    public const uint GL_TEXTURE4 = 33988;
    public const uint GL_TEXTURE5 = 33989;
    public const uint GL_TEXTURE6 = 33990;
    public const uint GL_TEXTURE7 = 33991;
    public const uint GL_TEXTURE8 = 33992;
    public const uint GL_TEXTURE9 = 33993;
    public const uint GL_TRIANGLE_FAN = 6;
    public const uint GL_TRIANGLE_STRIP = 5;
    public const uint GL_TRIANGLES = 4;
    public const uint GL_TRUE = 1;
    public const uint GL_UNPACK_ALIGNMENT = 3317;
    public const uint GL_UNSIGNED_BYTE = 5121;
    public const uint GL_UNSIGNED_INT = 5125;
    public const uint GL_UNSIGNED_SHORT = 5123;
    public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 32819;
    public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 32820;
    public const uint GL_UNSIGNED_SHORT_5_6_5 = 33635;
    public const uint GL_VALIDATE_STATUS = 35715;
    public const uint GL_VENDOR = 7936;
    public const uint GL_VERSION = 7938;
    public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 34975;
    public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 34338;
    public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 34922;
    public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 34373;
    public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 34339;
    public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 34340;
    public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 34341;
    public const uint GL_VERTEX_SHADER = 35633;
    public const uint GL_VIEWPORT = 2978;
    public const uint GL_ZERO = 0;
    #endregion

    #region Enums
    public enum AlphaFunction : uint
    {
        GL_ALWAYS = 519,
        GL_EQUAL = 514,
        GL_GEQUAL = 518,
        GL_GREATER = 516,
        GL_LEQUAL = 515,
        GL_LESS = 513,
        GL_NEVER = 512,
        GL_NOTEQUAL = 517
    }

    public enum AttribMask : uint
    {
        GL_COLOR_BUFFER_BIT = 16384,
        GL_DEPTH_BUFFER_BIT = 256,
        GL_STENCIL_BUFFER_BIT = 1024
    }

    public enum AttributeType : uint
    {
        GL_FLOAT_VEC2 = 35664,
        GL_FLOAT_VEC3 = 35665,
        GL_FLOAT_VEC4 = 35666,
        GL_INT_VEC2 = 35667,
        GL_INT_VEC3 = 35668,
        GL_INT_VEC4 = 35669,
        GL_BOOL = 35670,
        GL_BOOL_VEC2 = 35671,
        GL_BOOL_VEC3 = 35672,
        GL_BOOL_VEC4 = 35673,
        GL_FLOAT_MAT2 = 35674,
        GL_FLOAT_MAT3 = 35675,
        GL_FLOAT_MAT4 = 35676,
        GL_SAMPLER_2D = 35678,
        GL_SAMPLER_CUBE = 35680
    }

    public enum BlendEquationModeEXT : uint
    {
        GL_FUNC_ADD = 32774,
        GL_FUNC_REVERSE_SUBTRACT = 32779,
        GL_FUNC_SUBTRACT = 32778
    }

    public enum BlendingFactor : uint
    {
        GL_ZERO = 0,
        GL_ONE = 1,
        GL_SRC_COLOR = 768,
        GL_ONE_MINUS_SRC_COLOR = 769,
        GL_DST_COLOR = 774,
        GL_ONE_MINUS_DST_COLOR = 775,
        GL_SRC_ALPHA = 770,
        GL_ONE_MINUS_SRC_ALPHA = 771,
        GL_DST_ALPHA = 772,
        GL_ONE_MINUS_DST_ALPHA = 773,
        GL_CONSTANT_COLOR = 32769,
        GL_ONE_MINUS_CONSTANT_COLOR = 32770,
        GL_CONSTANT_ALPHA = 32771,
        GL_ONE_MINUS_CONSTANT_ALPHA = 32772,
        GL_SRC_ALPHA_SATURATE = 776
    }

    public enum BlitFramebufferFilter : uint
    {
        GL_NEAREST = 9728,
        GL_LINEAR = 9729
    }

    public enum Boolean : uint
    {
        GL_FALSE = 0,
        GL_TRUE = 1
    }

    public enum BufferStorageTarget : uint
    {
        GL_ARRAY_BUFFER = 34962,
        GL_ELEMENT_ARRAY_BUFFER = 34963
    }

    public enum BufferTargetARB : uint
    {
        GL_ARRAY_BUFFER = 34962,
        GL_ELEMENT_ARRAY_BUFFER = 34963
    }

    public enum BufferUsageARB : uint
    {
        GL_STREAM_DRAW = 35040,
        GL_STATIC_DRAW = 35044,
        GL_DYNAMIC_DRAW = 35048
    }

    public enum ClearBufferMask : uint
    {
        GL_COLOR_BUFFER_BIT = 16384,
        GL_DEPTH_BUFFER_BIT = 256,
        GL_STENCIL_BUFFER_BIT = 1024
    }

    public enum ColorBuffer : uint
    {
        GL_NONE = 0,
        GL_FRONT = 1028,
        GL_BACK = 1029,
        GL_FRONT_AND_BACK = 1032,
        GL_NONE = 0,
        GL_COLOR_ATTACHMENT0 = 36064
    }

    public enum ColorPointerType : uint
    {
        GL_BYTE = 5120,
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122,
        GL_UNSIGNED_BYTE = 5121,
        GL_UNSIGNED_INT = 5125,
        GL_UNSIGNED_SHORT = 5123
    }

    public enum CopyBufferSubDataTarget : uint
    {
        GL_ARRAY_BUFFER = 34962,
        GL_ELEMENT_ARRAY_BUFFER = 34963
    }

    public enum CullFaceMode : uint
    {
        GL_BACK = 1029,
        GL_FRONT = 1028,
        GL_FRONT_AND_BACK = 1032
    }

    public enum DebugSeverity : uint
    {
        GL_DONT_CARE = 4352
    }

    public enum DebugSource : uint
    {
        GL_DONT_CARE = 4352
    }

    public enum DebugType : uint
    {
        GL_DONT_CARE = 4352
    }

    public enum DepthFunction : uint
    {
        GL_ALWAYS = 519,
        GL_EQUAL = 514,
        GL_GEQUAL = 518,
        GL_GREATER = 516,
        GL_LEQUAL = 515,
        GL_LESS = 513,
        GL_NEVER = 512,
        GL_NOTEQUAL = 517
    }

    public enum DrawBufferMode : uint
    {
        GL_BACK = 1029,
        GL_FRONT = 1028,
        GL_FRONT_AND_BACK = 1032,
        GL_NONE = 0
    }

    public enum DrawElementsType : uint
    {
        GL_UNSIGNED_BYTE = 5121,
        GL_UNSIGNED_SHORT = 5123,
        GL_UNSIGNED_INT = 5125
    }

    public enum EnableCap : uint
    {
        GL_BLEND = 3042,
        GL_CULL_FACE = 2884,
        GL_DEPTH_TEST = 2929,
        GL_DITHER = 3024,
        GL_POLYGON_OFFSET_FILL = 32823,
        GL_SCISSOR_TEST = 3089,
        GL_STENCIL_TEST = 2960,
        GL_TEXTURE_2D = 3553
    }

    public enum ErrorCode : uint
    {
        GL_INVALID_ENUM = 1280,
        GL_INVALID_FRAMEBUFFER_OPERATION = 1286,
        GL_INVALID_OPERATION = 1282,
        GL_INVALID_VALUE = 1281,
        GL_NO_ERROR = 0,
        GL_OUT_OF_MEMORY = 1285
    }

    public enum FogCoordinatePointerType : uint
    {
        GL_FLOAT = 5126
    }

    public enum FogPointerTypeEXT : uint
    {
        GL_FLOAT = 5126
    }

    public enum FogPointerTypeIBM : uint
    {
        GL_FLOAT = 5126
    }

    public enum FramebufferAttachment : uint
    {
        GL_COLOR_ATTACHMENT0 = 36064,
        GL_DEPTH_ATTACHMENT = 36096
    }

    public enum FramebufferAttachmentParameterName : uint
    {
        GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 36049,
        GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 36049,
        GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 36050,
        GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 36051
    }

    public enum FramebufferStatus : uint
    {
        GL_FRAMEBUFFER_COMPLETE = 36053,
        GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 36054,
        GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 36055,
        GL_FRAMEBUFFER_UNSUPPORTED = 36061
    }

    public enum FramebufferTarget : uint
    {
        GL_FRAMEBUFFER = 36160
    }

    public enum FrontFaceDirection : uint
    {
        GL_CCW = 2305,
        GL_CW = 2304
    }

    public enum GetFramebufferParameter : uint
    {
        GL_IMPLEMENTATION_COLOR_READ_FORMAT = 35739,
        GL_IMPLEMENTATION_COLOR_READ_TYPE = 35738,
        GL_SAMPLES = 32937,
        GL_SAMPLE_BUFFERS = 32936
    }

    public enum GetPName : uint
    {
        GL_ACTIVE_TEXTURE = 34016,
        GL_ALIASED_LINE_WIDTH_RANGE = 33902,
        GL_ALIASED_POINT_SIZE_RANGE = 33901,
        GL_ALPHA_BITS = 3413,
        GL_ARRAY_BUFFER_BINDING = 34964,
        GL_BLEND = 3042,
        GL_BLEND_COLOR = 32773,
        GL_BLEND_DST_ALPHA = 32970,
        GL_BLEND_DST_RGB = 32968,
        GL_BLEND_EQUATION_ALPHA = 34877,
        GL_BLEND_EQUATION_RGB = 32777,
        GL_BLEND_SRC_ALPHA = 32971,
        GL_BLEND_SRC_RGB = 32969,
        GL_BLUE_BITS = 3412,
        GL_COLOR_CLEAR_VALUE = 3106,
        GL_COLOR_WRITEMASK = 3107,
        GL_COMPRESSED_TEXTURE_FORMATS = 34467,
        GL_CULL_FACE = 2884,
        GL_CULL_FACE_MODE = 2885,
        GL_CURRENT_PROGRAM = 35725,
        GL_DEPTH_BITS = 3414,
        GL_DEPTH_CLEAR_VALUE = 2931,
        GL_DEPTH_FUNC = 2932,
        GL_DEPTH_RANGE = 2928,
        GL_DEPTH_TEST = 2929,
        GL_DEPTH_WRITEMASK = 2930,
        GL_DITHER = 3024,
        GL_ELEMENT_ARRAY_BUFFER_BINDING = 34965,
        GL_FRONT_FACE = 2886,
        GL_GREEN_BITS = 3411,
        GL_IMPLEMENTATION_COLOR_READ_FORMAT = 35739,
        GL_IMPLEMENTATION_COLOR_READ_TYPE = 35738,
        GL_LINE_WIDTH = 2849,
        GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 35661,
        GL_MAX_CUBE_MAP_TEXTURE_SIZE = 34076,
        GL_MAX_FRAGMENT_UNIFORM_VECTORS = 36349,
        GL_MAX_RENDERBUFFER_SIZE = 34024,
        GL_MAX_TEXTURE_IMAGE_UNITS = 34930,
        GL_MAX_TEXTURE_SIZE = 3379,
        GL_MAX_VARYING_VECTORS = 36348,
        GL_MAX_VERTEX_ATTRIBS = 34921,
        GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 35660,
        GL_MAX_VERTEX_UNIFORM_VECTORS = 36347,
        GL_MAX_VIEWPORT_DIMS = 3386,
        GL_NUM_COMPRESSED_TEXTURE_FORMATS = 34466,
        GL_NUM_SHADER_BINARY_FORMATS = 36345,
        GL_PACK_ALIGNMENT = 3333,
        GL_POLYGON_OFFSET_FACTOR = 32824,
        GL_POLYGON_OFFSET_FILL = 32823,
        GL_POLYGON_OFFSET_UNITS = 10752,
        GL_RED_BITS = 3410,
        GL_RENDERBUFFER_BINDING = 36007,
        GL_SAMPLES = 32937,
        GL_SAMPLE_BUFFERS = 32936,
        GL_SAMPLE_COVERAGE_INVERT = 32939,
        GL_SAMPLE_COVERAGE_VALUE = 32938,
        GL_SCISSOR_BOX = 3088,
        GL_SCISSOR_TEST = 3089,
        GL_SHADER_COMPILER = 36346,
        GL_STENCIL_BACK_FAIL = 34817,
        GL_STENCIL_BACK_FUNC = 34816,
        GL_STENCIL_BACK_PASS_DEPTH_FAIL = 34818,
        GL_STENCIL_BACK_PASS_DEPTH_PASS = 34819,
        GL_STENCIL_BACK_REF = 36003,
        GL_STENCIL_BACK_VALUE_MASK = 36004,
        GL_STENCIL_BACK_WRITEMASK = 36005,
        GL_STENCIL_BITS = 3415,
        GL_STENCIL_CLEAR_VALUE = 2961,
        GL_STENCIL_FAIL = 2964,
        GL_STENCIL_FUNC = 2962,
        GL_STENCIL_PASS_DEPTH_FAIL = 2965,
        GL_STENCIL_PASS_DEPTH_PASS = 2966,
        GL_STENCIL_REF = 2967,
        GL_STENCIL_TEST = 2960,
        GL_STENCIL_VALUE_MASK = 2963,
        GL_STENCIL_WRITEMASK = 2968,
        GL_SUBPIXEL_BITS = 3408,
        GL_TEXTURE_2D = 3553,
        GL_TEXTURE_BINDING_2D = 32873,
        GL_TEXTURE_BINDING_CUBE_MAP = 34068,
        GL_UNPACK_ALIGNMENT = 3317,
        GL_VIEWPORT = 2978
    }

    public enum GetTextureParameter : uint
    {
        GL_TEXTURE_MAG_FILTER = 10240,
        GL_TEXTURE_MIN_FILTER = 10241,
        GL_TEXTURE_WRAP_S = 10242,
        GL_TEXTURE_WRAP_T = 10243
    }

    public enum GraphicsResetStatus : uint
    {
        GL_NO_ERROR = 0
    }

    public enum HintMode : uint
    {
        GL_DONT_CARE = 4352,
        GL_FASTEST = 4353,
        GL_NICEST = 4354
    }

    public enum HintTarget : uint
    {
        GL_GENERATE_MIPMAP_HINT = 33170
    }

    public enum IndexPointerType : uint
    {
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122
    }

    public enum InternalFormat : uint
    {
        GL_RGB = 6407,
        GL_RGBA = 6408,
        GL_RGBA4 = 32854,
        GL_RGB5_A1 = 32855,
        GL_DEPTH_COMPONENT = 6402,
        GL_DEPTH_COMPONENT16 = 33189
    }

    public enum InternalFormatPName : uint
    {
        GL_SAMPLES = 32937
    }

    public enum ListNameType : uint
    {
        GL_BYTE = 5120,
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122,
        GL_UNSIGNED_BYTE = 5121,
        GL_UNSIGNED_INT = 5125,
        GL_UNSIGNED_SHORT = 5123
    }

    public enum LogicOp : uint
    {
        GL_INVERT = 5386
    }

    public enum MaterialFace : uint
    {
        GL_BACK = 1029,
        GL_FRONT = 1028,
        GL_FRONT_AND_BACK = 1032
    }

    public enum MatrixMode : uint
    {
        GL_TEXTURE = 5890
    }

    public enum NormalPointerType : uint
    {
        GL_BYTE = 5120,
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122
    }

    public enum ObjectIdentifier : uint
    {
        GL_TEXTURE = 5890,
        GL_RENDERBUFFER = 36161,
        GL_FRAMEBUFFER = 36160
    }

    public enum PathFillMode : uint
    {
        GL_INVERT = 5386
    }

    public enum PathFontStyle : uint
    {
        GL_NONE = 0
    }

    public enum PathGenMode : uint
    {
        GL_NONE = 0
    }

    public enum PathTransformType : uint
    {
        GL_NONE = 0
    }

    public enum PipelineParameterName : uint
    {
        GL_VERTEX_SHADER = 35633,
        GL_FRAGMENT_SHADER = 35632,
        GL_INFO_LOG_LENGTH = 35716
    }

    public enum PixelFormat : uint
    {
        GL_ALPHA = 6406,
        GL_DEPTH_COMPONENT = 6402,
        GL_LUMINANCE = 6409,
        GL_LUMINANCE_ALPHA = 6410,
        GL_RGB = 6407,
        GL_RGBA = 6408,
        GL_UNSIGNED_INT = 5125,
        GL_UNSIGNED_SHORT = 5123
    }

    public enum PixelStoreParameter : uint
    {
        GL_PACK_ALIGNMENT = 3333,
        GL_UNPACK_ALIGNMENT = 3317
    }

    public enum PixelType : uint
    {
        GL_BYTE = 5120,
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122,
        GL_UNSIGNED_BYTE = 5121,
        GL_UNSIGNED_INT = 5125,
        GL_UNSIGNED_SHORT = 5123,
        GL_UNSIGNED_SHORT_4_4_4_4 = 32819,
        GL_UNSIGNED_SHORT_5_5_5_1 = 32820
    }

    public enum PrecisionType : uint
    {
        GL_LOW_FLOAT = 36336,
        GL_MEDIUM_FLOAT = 36337,
        GL_HIGH_FLOAT = 36338,
        GL_LOW_INT = 36339,
        GL_MEDIUM_INT = 36340,
        GL_HIGH_INT = 36341
    }

    public enum PrimitiveType : uint
    {
        GL_LINES = 1,
        GL_LINE_LOOP = 2,
        GL_LINE_STRIP = 3,
        GL_POINTS = 0,
        GL_TRIANGLES = 4,
        GL_TRIANGLE_FAN = 6,
        GL_TRIANGLE_STRIP = 5
    }

    public enum ProgramPropertyARB : uint
    {
        GL_DELETE_STATUS = 35712,
        GL_LINK_STATUS = 35714,
        GL_VALIDATE_STATUS = 35715,
        GL_INFO_LOG_LENGTH = 35716,
        GL_ATTACHED_SHADERS = 35717,
        GL_ACTIVE_ATTRIBUTES = 35721,
        GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 35722,
        GL_ACTIVE_UNIFORMS = 35718,
        GL_ACTIVE_UNIFORM_MAX_LENGTH = 35719
    }

    public enum ReadBufferMode : uint
    {
        GL_BACK = 1029,
        GL_FRONT = 1028
    }

    public enum RenderbufferParameterName : uint
    {
        GL_RENDERBUFFER_WIDTH = 36162,
        GL_RENDERBUFFER_HEIGHT = 36163,
        GL_RENDERBUFFER_INTERNAL_FORMAT = 36164,
        GL_RENDERBUFFER_RED_SIZE = 36176,
        GL_RENDERBUFFER_GREEN_SIZE = 36177,
        GL_RENDERBUFFER_BLUE_SIZE = 36178,
        GL_RENDERBUFFER_ALPHA_SIZE = 36179,
        GL_RENDERBUFFER_DEPTH_SIZE = 36180,
        GL_RENDERBUFFER_STENCIL_SIZE = 36181
    }

    public enum RenderbufferTarget : uint
    {
        GL_RENDERBUFFER = 36161
    }

    public enum SamplerParameterName : uint
    {
        GL_TEXTURE_WRAP_S = 10242,
        GL_TEXTURE_WRAP_T = 10243,
        GL_TEXTURE_MIN_FILTER = 10241,
        GL_TEXTURE_MAG_FILTER = 10240
    }

    public enum ShaderParameterName : uint
    {
        GL_SHADER_TYPE = 35663,
        GL_DELETE_STATUS = 35712,
        GL_COMPILE_STATUS = 35713,
        GL_INFO_LOG_LENGTH = 35716,
        GL_SHADER_SOURCE_LENGTH = 35720
    }

    public enum ShaderType : uint
    {
        GL_VERTEX_SHADER = 35633,
        GL_FRAGMENT_SHADER = 35632
    }

    public enum StencilFaceDirection : uint
    {
        GL_FRONT = 1028,
        GL_BACK = 1029,
        GL_FRONT_AND_BACK = 1032
    }

    public enum StencilFunction : uint
    {
        GL_ALWAYS = 519,
        GL_EQUAL = 514,
        GL_GEQUAL = 518,
        GL_GREATER = 516,
        GL_LEQUAL = 515,
        GL_LESS = 513,
        GL_NEVER = 512,
        GL_NOTEQUAL = 517
    }

    public enum StencilOp : uint
    {
        GL_DECR = 7683,
        GL_DECR_WRAP = 34056,
        GL_INCR = 7682,
        GL_INCR_WRAP = 34055,
        GL_INVERT = 5386,
        GL_KEEP = 7680,
        GL_REPLACE = 7681,
        GL_ZERO = 0
    }

    public enum StringName : uint
    {
        GL_EXTENSIONS = 7939,
        GL_RENDERER = 7937,
        GL_VENDOR = 7936,
        GL_VERSION = 7938,
        GL_SHADING_LANGUAGE_VERSION = 35724
    }

    public enum TexCoordPointerType : uint
    {
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122
    }

    public enum TextureParameterName : uint
    {
        GL_TEXTURE_MAG_FILTER = 10240,
        GL_TEXTURE_MIN_FILTER = 10241,
        GL_TEXTURE_WRAP_S = 10242,
        GL_TEXTURE_WRAP_T = 10243
    }

    public enum TextureTarget : uint
    {
        GL_TEXTURE_2D = 3553,
        GL_TEXTURE_CUBE_MAP = 34067,
        GL_TEXTURE_CUBE_MAP_POSITIVE_X = 34069,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 34070,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 34071,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 34072,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 34073,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 34074
    }

    public enum TextureUnit : uint
    {
        GL_TEXTURE0 = 33984,
        GL_TEXTURE1 = 33985,
        GL_TEXTURE2 = 33986,
        GL_TEXTURE3 = 33987,
        GL_TEXTURE4 = 33988,
        GL_TEXTURE5 = 33989,
        GL_TEXTURE6 = 33990,
        GL_TEXTURE7 = 33991,
        GL_TEXTURE8 = 33992,
        GL_TEXTURE9 = 33993,
        GL_TEXTURE10 = 33994,
        GL_TEXTURE11 = 33995,
        GL_TEXTURE12 = 33996,
        GL_TEXTURE13 = 33997,
        GL_TEXTURE14 = 33998,
        GL_TEXTURE15 = 33999,
        GL_TEXTURE16 = 34000,
        GL_TEXTURE17 = 34001,
        GL_TEXTURE18 = 34002,
        GL_TEXTURE19 = 34003,
        GL_TEXTURE20 = 34004,
        GL_TEXTURE21 = 34005,
        GL_TEXTURE22 = 34006,
        GL_TEXTURE23 = 34007,
        GL_TEXTURE24 = 34008,
        GL_TEXTURE25 = 34009,
        GL_TEXTURE26 = 34010,
        GL_TEXTURE27 = 34011,
        GL_TEXTURE28 = 34012,
        GL_TEXTURE29 = 34013,
        GL_TEXTURE30 = 34014,
        GL_TEXTURE31 = 34015
    }

    public enum VertexArrayPName : uint
    {
        GL_VERTEX_ATTRIB_ARRAY_ENABLED = 34338,
        GL_VERTEX_ATTRIB_ARRAY_SIZE = 34339,
        GL_VERTEX_ATTRIB_ARRAY_STRIDE = 34340,
        GL_VERTEX_ATTRIB_ARRAY_TYPE = 34341,
        GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 34922
    }

    public enum VertexAttribEnum : uint
    {
        GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 34975,
        GL_VERTEX_ATTRIB_ARRAY_ENABLED = 34338,
        GL_VERTEX_ATTRIB_ARRAY_SIZE = 34339,
        GL_VERTEX_ATTRIB_ARRAY_STRIDE = 34340,
        GL_VERTEX_ATTRIB_ARRAY_TYPE = 34341,
        GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 34922,
        GL_CURRENT_VERTEX_ATTRIB = 34342
    }

    public enum VertexAttribPointerType : uint
    {
        GL_BYTE = 5120,
        GL_UNSIGNED_BYTE = 5121,
        GL_SHORT = 5122,
        GL_UNSIGNED_SHORT = 5123,
        GL_INT = 5124,
        GL_UNSIGNED_INT = 5125,
        GL_FLOAT = 5126,
        GL_FIXED = 5132
    }

    public enum VertexAttribType : uint
    {
        GL_BYTE = 5120,
        GL_SHORT = 5122,
        GL_INT = 5124,
        GL_FIXED = 5132,
        GL_FLOAT = 5126,
        GL_UNSIGNED_BYTE = 5121,
        GL_UNSIGNED_SHORT = 5123,
        GL_UNSIGNED_INT = 5125
    }

    public enum VertexBufferObjectParameter : uint
    {
        GL_BUFFER_SIZE = 34660,
        GL_BUFFER_USAGE = 34661
    }

    public enum VertexBufferObjectUsage : uint
    {
        GL_STREAM_DRAW = 35040,
        GL_STATIC_DRAW = 35044,
        GL_DYNAMIC_DRAW = 35048
    }

    public enum VertexPointerType : uint
    {
        GL_FLOAT = 5126,
        GL_INT = 5124,
        GL_SHORT = 5122
    }
    #endregion

    #region Delegates
    public delegate void glActiveTexture(TextureUnit texture);
    public delegate void glAttachShader(uint program, uint shader);
    public delegate void glBindAttribLocation(uint program, uint index, string name);
    public delegate void glBindBuffer(BufferTargetARB target, uint buffer);
    public delegate void glBindFramebuffer(FramebufferTarget target, uint framebuffer);
    public delegate void glBindRenderbuffer(RenderbufferTarget target, uint renderbuffer);
    public delegate void glBindTexture(TextureTarget target, uint texture);
    public delegate void glBlendColor(float red, float green, float blue, float alpha);
    public delegate void glBlendEquation(BlendEquationModeEXT mode);
    public delegate void glBlendEquationSeparate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
    public delegate void glBlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);
    public delegate void glBlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
    public unsafe delegate void glBufferData(BufferTargetARB target, uint size, void* data, BufferUsageARB usage);
    public unsafe delegate void glBufferSubData(BufferTargetARB target, IntPtr offset, uint size, void* data);
    public delegate FramebufferStatus glCheckFramebufferStatus(FramebufferTarget target);
    public delegate void glClear(ClearBufferMask mask);
    public delegate void glClearColor(float red, float green, float blue, float alpha);
    public delegate void glClearDepthf(float d);
    public delegate void glClearStencil(int s);
    public delegate void glColorMask(Boolean red, Boolean green, Boolean blue, Boolean alpha);
    public delegate void glCompileShader(uint shader);
    public unsafe delegate void glCompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, void* data);
    public unsafe delegate void glCompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, void* data);
    public delegate void glCopyTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border);
    public delegate void glCopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
    public delegate uint glCreateProgram();
    public delegate uint glCreateShader(ShaderType type);
    public delegate void glCullFace(CullFaceMode mode);
    public unsafe delegate void glDeleteBuffers(int n, uint* buffers);
    public unsafe delegate void glDeleteFramebuffers(int n, uint* framebuffers);
    public delegate void glDeleteProgram(uint program);
    public unsafe delegate void glDeleteRenderbuffers(int n, uint* renderbuffers);
    public delegate void glDeleteShader(uint shader);
    public unsafe delegate void glDeleteTextures(int n, uint* textures);
    public delegate void glDepthFunc(DepthFunction func);
    public delegate void glDepthMask(Boolean flag);
    public delegate void glDepthRangef(float n, float f);
    public delegate void glDetachShader(uint program, uint shader);
    public delegate void glDisable(EnableCap cap);
    public delegate void glDisableVertexAttribArray(uint index);
    public delegate void glDrawArrays(PrimitiveType mode, int first, int count);
    public unsafe delegate void glDrawElements(PrimitiveType mode, int count, DrawElementsType type, void* indices);
    public delegate void glEnable(EnableCap cap);
    public delegate void glEnableVertexAttribArray(uint index);
    public delegate void glFinish();
    public delegate void glFlush();
    public delegate void glFramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
    public delegate void glFramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
    public delegate void glFrontFace(FrontFaceDirection mode);
    public unsafe delegate void glGenBuffers(int n, uint* buffers);
    public delegate void glGenerateMipmap(TextureTarget target);
    public unsafe delegate void glGenFramebuffers(int n, uint* framebuffers);
    public unsafe delegate void glGenRenderbuffers(int n, uint* renderbuffers);
    public unsafe delegate void glGenTextures(int n, uint* textures);
    public unsafe delegate void glGetActiveAttrib(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, string name);
    public unsafe delegate void glGetActiveUniform(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, string name);
    public unsafe delegate void glGetAttachedShaders(uint program, int maxCount, int* count, uint* shaders);
    public delegate int glGetAttribLocation(uint program, string name);
    public unsafe delegate void glGetBooleanv(GetPName pname, Boolean* data);
    public unsafe delegate void glGetBufferParameteriv(BufferTargetARB target, uint pname, int* params);
    public delegate ErrorCode glGetError();
    public unsafe delegate void glGetFloatv(GetPName pname, float* data);
    public unsafe delegate void glGetFramebufferAttachmentParameteriv(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* params);
    public unsafe delegate void glGetIntegerv(GetPName pname, int* data);
    public unsafe delegate void glGetProgramInfoLog(uint program, int bufSize, int* length, string infoLog);
    public unsafe delegate void glGetProgramiv(uint program, ProgramPropertyARB pname, int* params);
    public unsafe delegate void glGetRenderbufferParameteriv(RenderbufferTarget target, RenderbufferParameterName pname, int* params);
    public unsafe delegate void glGetShaderInfoLog(uint shader, int bufSize, int* length, string infoLog);
    public unsafe delegate void glGetShaderiv(uint shader, ShaderParameterName pname, int* params);
    public unsafe delegate void glGetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, int* range, int* precision);
    public unsafe delegate void glGetShaderSource(uint shader, int bufSize, int* length, string source);
    public delegate byte glGetString(StringName name);
    public unsafe delegate void glGetTexParameterfv(TextureTarget target, GetTextureParameter pname, float* params);
    public unsafe delegate void glGetTexParameteriv(TextureTarget target, GetTextureParameter pname, int* params);
    public unsafe delegate void glGetUniformfv(uint program, int location, float* params);
    public unsafe delegate void glGetUniformiv(uint program, int location, int* params);
    public delegate int glGetUniformLocation(uint program, string name);
    public unsafe delegate void glGetVertexAttribfv(uint index, uint pname, float* params);
    public unsafe delegate void glGetVertexAttribiv(uint index, uint pname, int* params);
    public unsafe delegate void glGetVertexAttribPointerv(uint index, uint pname, void* pointer);
    public delegate void glHint(HintTarget target, HintMode mode);
    public delegate Boolean glIsBuffer(uint buffer);
    public delegate Boolean glIsEnabled(EnableCap cap);
    public delegate Boolean glIsFramebuffer(uint framebuffer);
    public delegate Boolean glIsProgram(uint program);
    public delegate Boolean glIsRenderbuffer(uint renderbuffer);
    public delegate Boolean glIsShader(uint shader);
    public delegate Boolean glIsTexture(uint texture);
    public delegate void glLineWidth(float width);
    public delegate void glLinkProgram(uint program);
    public delegate void glPixelStorei(PixelStoreParameter pname, int param);
    public delegate void glPolygonOffset(float factor, float units);
    public unsafe delegate void glReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, void* pixels);
    public delegate void glReleaseShaderCompiler();
    public delegate void glRenderbufferStorage(RenderbufferTarget target, InternalFormat internalformat, int width, int height);
    public delegate void glSampleCoverage(float value, Boolean invert);
    public delegate void glScissor(int x, int y, int width, int height);
    public unsafe delegate void glShaderBinary(int count, uint* shaders, uint binaryformat, void* binary, int length);
    public unsafe delegate void glShaderSource(uint shader, int count, string string, int* length);
    public delegate void glStencilFunc(StencilFunction func, int ref, uint mask);
    public delegate void glStencilFuncSeparate(StencilFaceDirection face, StencilFunction func, int ref, uint mask);
    public delegate void glStencilMask(uint mask);
    public delegate void glStencilMaskSeparate(StencilFaceDirection face, uint mask);
    public delegate void glStencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass);
    public delegate void glStencilOpSeparate(StencilFaceDirection face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
    public unsafe delegate void glTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, void* pixels);
    public delegate void glTexParameterf(TextureTarget target, TextureParameterName pname, float param);
    public unsafe delegate void glTexParameterfv(TextureTarget target, TextureParameterName pname, float* params);
    public delegate void glTexParameteri(TextureTarget target, TextureParameterName pname, int param);
    public unsafe delegate void glTexParameteriv(TextureTarget target, TextureParameterName pname, int* params);
    public unsafe delegate void glTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, void* pixels);
    public delegate void glUniform1f(int location, float v0);
    public unsafe delegate void glUniform1fv(int location, int count, float* value);
    public delegate void glUniform1i(int location, int v0);
    public unsafe delegate void glUniform1iv(int location, int count, int* value);
    public delegate void glUniform2f(int location, float v0, float v1);
    public unsafe delegate void glUniform2fv(int location, int count, float* value);
    public delegate void glUniform2i(int location, int v0, int v1);
    public unsafe delegate void glUniform2iv(int location, int count, int* value);
    public delegate void glUniform3f(int location, float v0, float v1, float v2);
    public unsafe delegate void glUniform3fv(int location, int count, float* value);
    public delegate void glUniform3i(int location, int v0, int v1, int v2);
    public unsafe delegate void glUniform3iv(int location, int count, int* value);
    public delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);
    public unsafe delegate void glUniform4fv(int location, int count, float* value);
    public delegate void glUniform4i(int location, int v0, int v1, int v2, int v3);
    public unsafe delegate void glUniform4iv(int location, int count, int* value);
    public unsafe delegate void glUniformMatrix2fv(int location, int count, Boolean transpose, float* value);
    public unsafe delegate void glUniformMatrix3fv(int location, int count, Boolean transpose, float* value);
    public unsafe delegate void glUniformMatrix4fv(int location, int count, Boolean transpose, float* value);
    public delegate void glUseProgram(uint program);
    public delegate void glValidateProgram(uint program);
    public delegate void glVertexAttrib1f(uint index, float x);
    public unsafe delegate void glVertexAttrib1fv(uint index, float* v);
    public delegate void glVertexAttrib2f(uint index, float x, float y);
    public unsafe delegate void glVertexAttrib2fv(uint index, float* v);
    public delegate void glVertexAttrib3f(uint index, float x, float y, float z);
    public unsafe delegate void glVertexAttrib3fv(uint index, float* v);
    public delegate void glVertexAttrib4f(uint index, float x, float y, float z, float w);
    public unsafe delegate void glVertexAttrib4fv(uint index, float* v);
    public unsafe delegate void glVertexAttribPointer(uint index, int size, VertexAttribPointerType type, Boolean normalized, int stride, void* pointer);
    public delegate void glViewport(int x, int y, int width, int height);
    #endregion

    #region Delegate instances
    public readonly glActiveTexture glActiveTexture;
    public readonly glAttachShader glAttachShader;
    public readonly glBindAttribLocation glBindAttribLocation;
    public readonly glBindBuffer glBindBuffer;
    public readonly glBindFramebuffer glBindFramebuffer;
    public readonly glBindRenderbuffer glBindRenderbuffer;
    public readonly glBindTexture glBindTexture;
    public readonly glBlendColor glBlendColor;
    public readonly glBlendEquation glBlendEquation;
    public readonly glBlendEquationSeparate glBlendEquationSeparate;
    public readonly glBlendFunc glBlendFunc;
    public readonly glBlendFuncSeparate glBlendFuncSeparate;
    public readonly glBufferData glBufferData;
    public readonly glBufferSubData glBufferSubData;
    public readonly glCheckFramebufferStatus glCheckFramebufferStatus;
    public readonly glClear glClear;
    public readonly glClearColor glClearColor;
    public readonly glClearDepthf glClearDepthf;
    public readonly glClearStencil glClearStencil;
    public readonly glColorMask glColorMask;
    public readonly glCompileShader glCompileShader;
    public readonly glCompressedTexImage2D glCompressedTexImage2D;
    public readonly glCompressedTexSubImage2D glCompressedTexSubImage2D;
    public readonly glCopyTexImage2D glCopyTexImage2D;
    public readonly glCopyTexSubImage2D glCopyTexSubImage2D;
    public readonly glCreateProgram glCreateProgram;
    public readonly glCreateShader glCreateShader;
    public readonly glCullFace glCullFace;
    public readonly glDeleteBuffers glDeleteBuffers;
    public readonly glDeleteFramebuffers glDeleteFramebuffers;
    public readonly glDeleteProgram glDeleteProgram;
    public readonly glDeleteRenderbuffers glDeleteRenderbuffers;
    public readonly glDeleteShader glDeleteShader;
    public readonly glDeleteTextures glDeleteTextures;
    public readonly glDepthFunc glDepthFunc;
    public readonly glDepthMask glDepthMask;
    public readonly glDepthRangef glDepthRangef;
    public readonly glDetachShader glDetachShader;
    public readonly glDisable glDisable;
    public readonly glDisableVertexAttribArray glDisableVertexAttribArray;
    public readonly glDrawArrays glDrawArrays;
    public readonly glDrawElements glDrawElements;
    public readonly glEnable glEnable;
    public readonly glEnableVertexAttribArray glEnableVertexAttribArray;
    public readonly glFinish glFinish;
    public readonly glFlush glFlush;
    public readonly glFramebufferRenderbuffer glFramebufferRenderbuffer;
    public readonly glFramebufferTexture2D glFramebufferTexture2D;
    public readonly glFrontFace glFrontFace;
    public readonly glGenBuffers glGenBuffers;
    public readonly glGenerateMipmap glGenerateMipmap;
    public readonly glGenFramebuffers glGenFramebuffers;
    public readonly glGenRenderbuffers glGenRenderbuffers;
    public readonly glGenTextures glGenTextures;
    public readonly glGetActiveAttrib glGetActiveAttrib;
    public readonly glGetActiveUniform glGetActiveUniform;
    public readonly glGetAttachedShaders glGetAttachedShaders;
    public readonly glGetAttribLocation glGetAttribLocation;
    public readonly glGetBooleanv glGetBooleanv;
    public readonly glGetBufferParameteriv glGetBufferParameteriv;
    public readonly glGetError glGetError;
    public readonly glGetFloatv glGetFloatv;
    public readonly glGetFramebufferAttachmentParameteriv glGetFramebufferAttachmentParameteriv;
    public readonly glGetIntegerv glGetIntegerv;
    public readonly glGetProgramInfoLog glGetProgramInfoLog;
    public readonly glGetProgramiv glGetProgramiv;
    public readonly glGetRenderbufferParameteriv glGetRenderbufferParameteriv;
    public readonly glGetShaderInfoLog glGetShaderInfoLog;
    public readonly glGetShaderiv glGetShaderiv;
    public readonly glGetShaderPrecisionFormat glGetShaderPrecisionFormat;
    public readonly glGetShaderSource glGetShaderSource;
    public readonly glGetString glGetString;
    public readonly glGetTexParameterfv glGetTexParameterfv;
    public readonly glGetTexParameteriv glGetTexParameteriv;
    public readonly glGetUniformfv glGetUniformfv;
    public readonly glGetUniformiv glGetUniformiv;
    public readonly glGetUniformLocation glGetUniformLocation;
    public readonly glGetVertexAttribfv glGetVertexAttribfv;
    public readonly glGetVertexAttribiv glGetVertexAttribiv;
    public readonly glGetVertexAttribPointerv glGetVertexAttribPointerv;
    public readonly glHint glHint;
    public readonly glIsBuffer glIsBuffer;
    public readonly glIsEnabled glIsEnabled;
    public readonly glIsFramebuffer glIsFramebuffer;
    public readonly glIsProgram glIsProgram;
    public readonly glIsRenderbuffer glIsRenderbuffer;
    public readonly glIsShader glIsShader;
    public readonly glIsTexture glIsTexture;
    public readonly glLineWidth glLineWidth;
    public readonly glLinkProgram glLinkProgram;
    public readonly glPixelStorei glPixelStorei;
    public readonly glPolygonOffset glPolygonOffset;
    public readonly glReadPixels glReadPixels;
    public readonly glReleaseShaderCompiler glReleaseShaderCompiler;
    public readonly glRenderbufferStorage glRenderbufferStorage;
    public readonly glSampleCoverage glSampleCoverage;
    public readonly glScissor glScissor;
    public readonly glShaderBinary glShaderBinary;
    public readonly glShaderSource glShaderSource;
    public readonly glStencilFunc glStencilFunc;
    public readonly glStencilFuncSeparate glStencilFuncSeparate;
    public readonly glStencilMask glStencilMask;
    public readonly glStencilMaskSeparate glStencilMaskSeparate;
    public readonly glStencilOp glStencilOp;
    public readonly glStencilOpSeparate glStencilOpSeparate;
    public readonly glTexImage2D glTexImage2D;
    public readonly glTexParameterf glTexParameterf;
    public readonly glTexParameterfv glTexParameterfv;
    public readonly glTexParameteri glTexParameteri;
    public readonly glTexParameteriv glTexParameteriv;
    public readonly glTexSubImage2D glTexSubImage2D;
    public readonly glUniform1f glUniform1f;
    public readonly glUniform1fv glUniform1fv;
    public readonly glUniform1i glUniform1i;
    public readonly glUniform1iv glUniform1iv;
    public readonly glUniform2f glUniform2f;
    public readonly glUniform2fv glUniform2fv;
    public readonly glUniform2i glUniform2i;
    public readonly glUniform2iv glUniform2iv;
    public readonly glUniform3f glUniform3f;
    public readonly glUniform3fv glUniform3fv;
    public readonly glUniform3i glUniform3i;
    public readonly glUniform3iv glUniform3iv;
    public readonly glUniform4f glUniform4f;
    public readonly glUniform4fv glUniform4fv;
    public readonly glUniform4i glUniform4i;
    public readonly glUniform4iv glUniform4iv;
    public readonly glUniformMatrix2fv glUniformMatrix2fv;
    public readonly glUniformMatrix3fv glUniformMatrix3fv;
    public readonly glUniformMatrix4fv glUniformMatrix4fv;
    public readonly glUseProgram glUseProgram;
    public readonly glValidateProgram glValidateProgram;
    public readonly glVertexAttrib1f glVertexAttrib1f;
    public readonly glVertexAttrib1fv glVertexAttrib1fv;
    public readonly glVertexAttrib2f glVertexAttrib2f;
    public readonly glVertexAttrib2fv glVertexAttrib2fv;
    public readonly glVertexAttrib3f glVertexAttrib3f;
    public readonly glVertexAttrib3fv glVertexAttrib3fv;
    public readonly glVertexAttrib4f glVertexAttrib4f;
    public readonly glVertexAttrib4fv glVertexAttrib4fv;
    public readonly glVertexAttribPointer glVertexAttribPointer;
    public readonly glViewport glViewport;
    #endregion
}