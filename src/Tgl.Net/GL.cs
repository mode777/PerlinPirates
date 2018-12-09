using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Tgl.Net
{
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
        [SuppressUnmanagedCodeSecurity] public delegate void glActiveTextureDelegate(TextureUnit texture);
        [SuppressUnmanagedCodeSecurity] public delegate void glAttachShaderDelegate(uint program, uint shader);
        [SuppressUnmanagedCodeSecurity] public delegate void glBindAttribLocationDelegate(uint program, uint index, string name);
        [SuppressUnmanagedCodeSecurity] public delegate void glBindBufferDelegate(BufferTargetARB target, uint buffer);
        [SuppressUnmanagedCodeSecurity] public delegate void glBindFramebufferDelegate(FramebufferTarget target, uint framebuffer);
        [SuppressUnmanagedCodeSecurity] public delegate void glBindRenderbufferDelegate(RenderbufferTarget target, uint renderbuffer);
        [SuppressUnmanagedCodeSecurity] public delegate void glBindTextureDelegate(TextureTarget target, uint texture);
        [SuppressUnmanagedCodeSecurity] public delegate void glBlendColorDelegate(float red, float green, float blue, float alpha);
        [SuppressUnmanagedCodeSecurity] public delegate void glBlendEquationDelegate(BlendEquationModeEXT mode);
        [SuppressUnmanagedCodeSecurity] public delegate void glBlendEquationSeparateDelegate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        [SuppressUnmanagedCodeSecurity] public delegate void glBlendFuncDelegate(BlendingFactor sfactor, BlendingFactor dfactor);
        [SuppressUnmanagedCodeSecurity] public delegate void glBlendFuncSeparateDelegate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glBufferDataDelegate(BufferTargetARB target, uint size, void* data, BufferUsageARB usage);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glBufferSubDataDelegate(BufferTargetARB target, IntPtr offset, uint size, void* data);
        [SuppressUnmanagedCodeSecurity] public delegate FramebufferStatus glCheckFramebufferStatusDelegate(FramebufferTarget target);
        [SuppressUnmanagedCodeSecurity] public delegate void glClearDelegate(ClearBufferMask mask);
        [SuppressUnmanagedCodeSecurity] public delegate void glClearColorDelegate(float red, float green, float blue, float alpha);
        [SuppressUnmanagedCodeSecurity] public delegate void glClearDepthfDelegate(float d);
        [SuppressUnmanagedCodeSecurity] public delegate void glClearStencilDelegate(int s);
        [SuppressUnmanagedCodeSecurity] public delegate void glColorMaskDelegate(bool red, bool green, bool blue, bool alpha);
        [SuppressUnmanagedCodeSecurity] public delegate void glCompileShaderDelegate(uint shader);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glCompressedTexImage2DDelegate(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, void* data);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glCompressedTexSubImage2DDelegate(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, void* data);
        [SuppressUnmanagedCodeSecurity] public delegate void glCopyTexImage2DDelegate(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border);
        [SuppressUnmanagedCodeSecurity] public delegate void glCopyTexSubImage2DDelegate(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        [SuppressUnmanagedCodeSecurity] public delegate uint glCreateProgramDelegate();
        [SuppressUnmanagedCodeSecurity] public delegate uint glCreateShaderDelegate(ShaderType type);
        [SuppressUnmanagedCodeSecurity] public delegate void glCullFaceDelegate(CullFaceMode mode);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glDeleteBuffersDelegate(int n, uint* buffers);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glDeleteFramebuffersDelegate(int n, uint* framebuffers);
        [SuppressUnmanagedCodeSecurity] public delegate void glDeleteProgramDelegate(uint program);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glDeleteRenderbuffersDelegate(int n, uint* renderbuffers);
        [SuppressUnmanagedCodeSecurity] public delegate void glDeleteShaderDelegate(uint shader);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glDeleteTexturesDelegate(int n, uint* textures);
        [SuppressUnmanagedCodeSecurity] public delegate void glDepthFuncDelegate(DepthFunction func);
        [SuppressUnmanagedCodeSecurity] public delegate void glDepthMaskDelegate(bool flag);
        [SuppressUnmanagedCodeSecurity] public delegate void glDepthRangefDelegate(float n, float f);
        [SuppressUnmanagedCodeSecurity] public delegate void glDetachShaderDelegate(uint program, uint shader);
        [SuppressUnmanagedCodeSecurity] public delegate void glDisableDelegate(EnableCap cap);
        [SuppressUnmanagedCodeSecurity] public delegate void glDisableVertexAttribArrayDelegate(uint index);
        [SuppressUnmanagedCodeSecurity] public delegate void glDrawArraysDelegate(PrimitiveType mode, int first, int count);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glDrawElementsDelegate(PrimitiveType mode, int count, DrawElementsType type, void* indices);
        [SuppressUnmanagedCodeSecurity] public delegate void glEnableDelegate(EnableCap cap);
        [SuppressUnmanagedCodeSecurity] public delegate void glEnableVertexAttribArrayDelegate(uint index);
        [SuppressUnmanagedCodeSecurity] public delegate void glFinishDelegate();
        [SuppressUnmanagedCodeSecurity] public delegate void glFlushDelegate();
        [SuppressUnmanagedCodeSecurity] public delegate void glFramebufferRenderbufferDelegate(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
        [SuppressUnmanagedCodeSecurity] public delegate void glFramebufferTexture2DDelegate(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
        [SuppressUnmanagedCodeSecurity] public delegate void glFrontFaceDelegate(FrontFaceDirection mode);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGenBuffersDelegate(int n, uint* buffers);
        [SuppressUnmanagedCodeSecurity] public delegate void glGenerateMipmapDelegate(TextureTarget target);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGenFramebuffersDelegate(int n, uint* framebuffers);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGenRenderbuffersDelegate(int n, uint* renderbuffers);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGenTexturesDelegate(int n, uint* textures);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetActiveAttribDelegate(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, string name);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetActiveUniformDelegate(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, string name);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetAttachedShadersDelegate(uint program, int maxCount, int* count, uint* shaders);
        [SuppressUnmanagedCodeSecurity] public delegate int glGetAttribLocationDelegate(uint program, string name);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetboolvDelegate(GetPName pname, bool* data);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetBufferParameterivDelegate(BufferTargetARB target, uint pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public delegate ErrorCode glGetErrorDelegate();
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetFloatvDelegate(GetPName pname, void* data);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetFramebufferAttachmentParameterivDelegate(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetIntegervDelegate(GetPName pname, void* data);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetProgramInfoLogDelegate(uint program, int bufSize, out int length, StringBuilder infoLog);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetProgramivDelegate(uint program, ProgramPropertyARB pname, out int @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetRenderbufferParameterivDelegate(RenderbufferTarget target, RenderbufferParameterName pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public delegate void glGetShaderInfoLogDelegate(uint shader, int bufSize, out int length, StringBuilder infoLog);
        [SuppressUnmanagedCodeSecurity] public delegate void glGetShaderivDelegate(uint shader, ShaderParameterName pname, out int @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetShaderPrecisionFormatDelegate(ShaderType shadertype, PrecisionType precisiontype, int* range, int* precision);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetShaderSourceDelegate(uint shader, int bufSize, int* length, string source);
        [SuppressUnmanagedCodeSecurity] public delegate byte glGetStringDelegate(StringName name);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetTexParameterfvDelegate(TextureTarget target, GetTextureParameter pname, float* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetTexParameterivDelegate(TextureTarget target, GetTextureParameter pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetUniformfvDelegate(uint program, int location, float* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetUniformivDelegate(uint program, int location, int* @params);
        [SuppressUnmanagedCodeSecurity] public delegate int glGetUniformLocationDelegate(uint program, string name);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetVertexAttribfvDelegate(uint index, uint pname, float* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetVertexAttribivDelegate(uint index, uint pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glGetVertexAttribPointervDelegate(uint index, uint pname, void* pointer);
        [SuppressUnmanagedCodeSecurity] public delegate void glHintDelegate(HintTarget target, HintMode mode);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsBufferDelegate(uint buffer);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsEnabledDelegate(EnableCap cap);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsFramebufferDelegate(uint framebuffer);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsProgramDelegate(uint program);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsRenderbufferDelegate(uint renderbuffer);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsShaderDelegate(uint shader);
        [SuppressUnmanagedCodeSecurity] public delegate bool glIsTextureDelegate(uint texture);
        [SuppressUnmanagedCodeSecurity] public delegate void glLineWidthDelegate(float width);
        [SuppressUnmanagedCodeSecurity] public delegate void glLinkProgramDelegate(uint program);
        [SuppressUnmanagedCodeSecurity] public delegate void glPixelStoreiDelegate(PixelStoreParameter pname, int param);
        [SuppressUnmanagedCodeSecurity] public delegate void glPolygonOffsetDelegate(float factor, float units);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glReadPixelsDelegate(int x, int y, int width, int height, PixelFormat format, PixelType type, void* pixels);
        [SuppressUnmanagedCodeSecurity] public delegate void glReleaseShaderCompilerDelegate();
        [SuppressUnmanagedCodeSecurity] public delegate void glRenderbufferStorageDelegate(RenderbufferTarget target, InternalFormat internalformat, int width, int height);
        [SuppressUnmanagedCodeSecurity] public delegate void glSampleCoverageDelegate(float value, bool invert);
        [SuppressUnmanagedCodeSecurity] public delegate void glScissorDelegate(int x, int y, int width, int height);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glShaderBinaryDelegate(int count, uint* shaders, uint binaryformat, void* binary, int length);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glShaderSourceDelegate(uint shader, int count, string[] @string, int* length);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilFuncDelegate(StencilFunction func, int @ref, uint mask);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilFuncSeparateDelegate(StencilFaceDirection face, StencilFunction func, int @ref, uint mask);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilMaskDelegate(uint mask);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilMaskSeparateDelegate(StencilFaceDirection face, uint mask);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilOpDelegate(StencilOp fail, StencilOp zfail, StencilOp zpass);
        [SuppressUnmanagedCodeSecurity] public delegate void glStencilOpSeparateDelegate(StencilFaceDirection face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glTexImage2DDelegate(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, void* pixels);
        [SuppressUnmanagedCodeSecurity] public delegate void glTexParameterfDelegate(TextureTarget target, TextureParameterName pname, float param);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glTexParameterfvDelegate(TextureTarget target, TextureParameterName pname, float* @params);
        [SuppressUnmanagedCodeSecurity] public delegate void glTexParameteriDelegate(TextureTarget target, TextureParameterName pname, int param);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glTexParameterivDelegate(TextureTarget target, TextureParameterName pname, int* @params);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glTexSubImage2DDelegate(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, void* pixels);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform1fDelegate(int location, float v0);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform1fvDelegate(int location, int count, float* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform1iDelegate(int location, int v0);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform1ivDelegate(int location, int count, int* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform2fDelegate(int location, float v0, float v1);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform2fvDelegate(int location, int count, float* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform2iDelegate(int location, int v0, int v1);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform2ivDelegate(int location, int count, int* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform3fDelegate(int location, float v0, float v1, float v2);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform3fvDelegate(int location, int count, float* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform3iDelegate(int location, int v0, int v1, int v2);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform3ivDelegate(int location, int count, int* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform4fDelegate(int location, float v0, float v1, float v2, float v3);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform4fvDelegate(int location, int count, float* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUniform4iDelegate(int location, int v0, int v1, int v2, int v3);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniform4ivDelegate(int location, int count, int* value);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniformMatrix2fvDelegate(int location, int count, bool transpose, float* value);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniformMatrix3fvDelegate(int location, int count, bool transpose, float* value);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glUniformMatrix4fvDelegate(int location, int count, bool transpose, float* value);
        [SuppressUnmanagedCodeSecurity] public delegate void glUseProgramDelegate(uint program);
        [SuppressUnmanagedCodeSecurity] public delegate void glValidateProgramDelegate(uint program);
        [SuppressUnmanagedCodeSecurity] public delegate void glVertexAttrib1fDelegate(uint index, float x);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glVertexAttrib1fvDelegate(uint index, float* v);
        [SuppressUnmanagedCodeSecurity] public delegate void glVertexAttrib2fDelegate(uint index, float x, float y);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glVertexAttrib2fvDelegate(uint index, float* v);
        [SuppressUnmanagedCodeSecurity] public delegate void glVertexAttrib3fDelegate(uint index, float x, float y, float z);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glVertexAttrib3fvDelegate(uint index, float* v);
        [SuppressUnmanagedCodeSecurity] public delegate void glVertexAttrib4fDelegate(uint index, float x, float y, float z, float w);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glVertexAttrib4fvDelegate(uint index, float* v);
        [SuppressUnmanagedCodeSecurity] public unsafe delegate void glVertexAttribPointerDelegate(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, void* pointer);
        [SuppressUnmanagedCodeSecurity] public delegate void glViewportDelegate(int x, int y, int width, int height);
        #endregion

        #region Delegate instances
        [ThreadStatic] public static glActiveTextureDelegate glActiveTexture;
        [ThreadStatic] public static glAttachShaderDelegate glAttachShader;
        [ThreadStatic] public static glBindAttribLocationDelegate glBindAttribLocation;
        [ThreadStatic] public static glBindBufferDelegate glBindBuffer;
        [ThreadStatic] public static glBindFramebufferDelegate glBindFramebuffer;
        [ThreadStatic] public static glBindRenderbufferDelegate glBindRenderbuffer;
        [ThreadStatic] public static glBindTextureDelegate glBindTexture;
        [ThreadStatic] public static glBlendColorDelegate glBlendColor;
        [ThreadStatic] public static glBlendEquationDelegate glBlendEquation;
        [ThreadStatic] public static glBlendEquationSeparateDelegate glBlendEquationSeparate;
        [ThreadStatic] public static glBlendFuncDelegate glBlendFunc;
        [ThreadStatic] public static glBlendFuncSeparateDelegate glBlendFuncSeparate;
        [ThreadStatic] public static glBufferDataDelegate glBufferData;
        [ThreadStatic] public static glBufferSubDataDelegate glBufferSubData;
        [ThreadStatic] public static glCheckFramebufferStatusDelegate glCheckFramebufferStatus;
        [ThreadStatic] public static glClearDelegate glClear;
        [ThreadStatic] public static glClearColorDelegate glClearColor;
        [ThreadStatic] public static glClearDepthfDelegate glClearDepthf;
        [ThreadStatic] public static glClearStencilDelegate glClearStencil;
        [ThreadStatic] public static glColorMaskDelegate glColorMask;
        [ThreadStatic] public static glCompileShaderDelegate glCompileShader;
        [ThreadStatic] public static glCompressedTexImage2DDelegate glCompressedTexImage2D;
        [ThreadStatic] public static glCompressedTexSubImage2DDelegate glCompressedTexSubImage2D;
        [ThreadStatic] public static glCopyTexImage2DDelegate glCopyTexImage2D;
        [ThreadStatic] public static glCopyTexSubImage2DDelegate glCopyTexSubImage2D;
        [ThreadStatic] public static glCreateProgramDelegate glCreateProgram;
        [ThreadStatic] public static glCreateShaderDelegate glCreateShader;
        [ThreadStatic] public static glCullFaceDelegate glCullFace;
        [ThreadStatic] public static glDeleteBuffersDelegate glDeleteBuffers;
        [ThreadStatic] public static glDeleteFramebuffersDelegate glDeleteFramebuffers;
        [ThreadStatic] public static glDeleteProgramDelegate glDeleteProgram;
        [ThreadStatic] public static glDeleteRenderbuffersDelegate glDeleteRenderbuffers;
        [ThreadStatic] public static glDeleteShaderDelegate glDeleteShader;
        [ThreadStatic] public static glDeleteTexturesDelegate glDeleteTextures;
        [ThreadStatic] public static glDepthFuncDelegate glDepthFunc;
        [ThreadStatic] public static glDepthMaskDelegate glDepthMask;
        [ThreadStatic] public static glDepthRangefDelegate glDepthRangef;
        [ThreadStatic] public static glDetachShaderDelegate glDetachShader;
        [ThreadStatic] public static glDisableDelegate glDisable;
        [ThreadStatic] public static glDisableVertexAttribArrayDelegate glDisableVertexAttribArray;
        [ThreadStatic] public static glDrawArraysDelegate glDrawArrays;
        [ThreadStatic] public static glDrawElementsDelegate glDrawElements;
        [ThreadStatic] public static glEnableDelegate glEnable;
        [ThreadStatic] public static glEnableVertexAttribArrayDelegate glEnableVertexAttribArray;
        [ThreadStatic] public static glFinishDelegate glFinish;
        [ThreadStatic] public static glFlushDelegate glFlush;
        [ThreadStatic] public static glFramebufferRenderbufferDelegate glFramebufferRenderbuffer;
        [ThreadStatic] public static glFramebufferTexture2DDelegate glFramebufferTexture2D;
        [ThreadStatic] public static glFrontFaceDelegate glFrontFace;
        [ThreadStatic] public static glGenBuffersDelegate glGenBuffers;
        [ThreadStatic] public static glGenerateMipmapDelegate glGenerateMipmap;
        [ThreadStatic] public static glGenFramebuffersDelegate glGenFramebuffers;
        [ThreadStatic] public static glGenRenderbuffersDelegate glGenRenderbuffers;
        [ThreadStatic] public static glGenTexturesDelegate glGenTextures;
        [ThreadStatic] public static glGetActiveAttribDelegate glGetActiveAttrib;
        [ThreadStatic] public static glGetActiveUniformDelegate glGetActiveUniform;
        [ThreadStatic] public static glGetAttachedShadersDelegate glGetAttachedShaders;
        [ThreadStatic] public static glGetAttribLocationDelegate glGetAttribLocation;
        [ThreadStatic] public static glGetboolvDelegate glGetboolv;
        [ThreadStatic] public static glGetBufferParameterivDelegate glGetBufferParameteriv;
        [ThreadStatic] public static glGetErrorDelegate glGetError;
        [ThreadStatic] public static glGetFloatvDelegate glGetFloatv;
        [ThreadStatic] public static glGetFramebufferAttachmentParameterivDelegate glGetFramebufferAttachmentParameteriv;
        [ThreadStatic] public static glGetIntegervDelegate glGetIntegerv;
        [ThreadStatic] public static glGetProgramInfoLogDelegate glGetProgramInfoLog;
        [ThreadStatic] public static glGetProgramivDelegate glGetProgramiv;
        [ThreadStatic] public static glGetRenderbufferParameterivDelegate glGetRenderbufferParameteriv;
        [ThreadStatic] public static glGetShaderInfoLogDelegate glGetShaderInfoLog;
        [ThreadStatic] public static glGetShaderivDelegate glGetShaderiv;
        [ThreadStatic] public static glGetShaderPrecisionFormatDelegate glGetShaderPrecisionFormat;
        [ThreadStatic] public static glGetShaderSourceDelegate glGetShaderSource;
        [ThreadStatic] public static glGetStringDelegate glGetString;
        [ThreadStatic] public static glGetTexParameterfvDelegate glGetTexParameterfv;
        [ThreadStatic] public static glGetTexParameterivDelegate glGetTexParameteriv;
        [ThreadStatic] public static glGetUniformfvDelegate glGetUniformfv;
        [ThreadStatic] public static glGetUniformivDelegate glGetUniformiv;
        [ThreadStatic] public static glGetUniformLocationDelegate glGetUniformLocation;
        [ThreadStatic] public static glGetVertexAttribfvDelegate glGetVertexAttribfv;
        [ThreadStatic] public static glGetVertexAttribivDelegate glGetVertexAttribiv;
        [ThreadStatic] public static glGetVertexAttribPointervDelegate glGetVertexAttribPointerv;
        [ThreadStatic] public static glHintDelegate glHint;
        [ThreadStatic] public static glIsBufferDelegate glIsBuffer;
        [ThreadStatic] public static glIsEnabledDelegate glIsEnabled;
        [ThreadStatic] public static glIsFramebufferDelegate glIsFramebuffer;
        [ThreadStatic] public static glIsProgramDelegate glIsProgram;
        [ThreadStatic] public static glIsRenderbufferDelegate glIsRenderbuffer;
        [ThreadStatic] public static glIsShaderDelegate glIsShader;
        [ThreadStatic] public static glIsTextureDelegate glIsTexture;
        [ThreadStatic] public static glLineWidthDelegate glLineWidth;
        [ThreadStatic] public static glLinkProgramDelegate glLinkProgram;
        [ThreadStatic] public static glPixelStoreiDelegate glPixelStorei;
        [ThreadStatic] public static glPolygonOffsetDelegate glPolygonOffset;
        [ThreadStatic] public static glReadPixelsDelegate glReadPixels;
        [ThreadStatic] public static glReleaseShaderCompilerDelegate glReleaseShaderCompiler;
        [ThreadStatic] public static glRenderbufferStorageDelegate glRenderbufferStorage;
        [ThreadStatic] public static glSampleCoverageDelegate glSampleCoverage;
        [ThreadStatic] public static glScissorDelegate glScissor;
        [ThreadStatic] public static glShaderBinaryDelegate glShaderBinary;
        [ThreadStatic] public static glShaderSourceDelegate glShaderSource;
        [ThreadStatic] public static glStencilFuncDelegate glStencilFunc;
        [ThreadStatic] public static glStencilFuncSeparateDelegate glStencilFuncSeparate;
        [ThreadStatic] public static glStencilMaskDelegate glStencilMask;
        [ThreadStatic] public static glStencilMaskSeparateDelegate glStencilMaskSeparate;
        [ThreadStatic] public static glStencilOpDelegate glStencilOp;
        [ThreadStatic] public static glStencilOpSeparateDelegate glStencilOpSeparate;
        [ThreadStatic] public static glTexImage2DDelegate glTexImage2D;
        [ThreadStatic] public static glTexParameterfDelegate glTexParameterf;
        [ThreadStatic] public static glTexParameterfvDelegate glTexParameterfv;
        [ThreadStatic] public static glTexParameteriDelegate glTexParameteri;
        [ThreadStatic] public static glTexParameterivDelegate glTexParameteriv;
        [ThreadStatic] public static glTexSubImage2DDelegate glTexSubImage2D;
        [ThreadStatic] public static glUniform1fDelegate glUniform1f;
        [ThreadStatic] public static glUniform1fvDelegate glUniform1fv;
        [ThreadStatic] public static glUniform1iDelegate glUniform1i;
        [ThreadStatic] public static glUniform1ivDelegate glUniform1iv;
        [ThreadStatic] public static glUniform2fDelegate glUniform2f;
        [ThreadStatic] public static glUniform2fvDelegate glUniform2fv;
        [ThreadStatic] public static glUniform2iDelegate glUniform2i;
        [ThreadStatic] public static glUniform2ivDelegate glUniform2iv;
        [ThreadStatic] public static glUniform3fDelegate glUniform3f;
        [ThreadStatic] public static glUniform3fvDelegate glUniform3fv;
        [ThreadStatic] public static glUniform3iDelegate glUniform3i;
        [ThreadStatic] public static glUniform3ivDelegate glUniform3iv;
        [ThreadStatic] public static glUniform4fDelegate glUniform4f;
        [ThreadStatic] public static glUniform4fvDelegate glUniform4fv;
        [ThreadStatic] public static glUniform4iDelegate glUniform4i;
        [ThreadStatic] public static glUniform4ivDelegate glUniform4iv;
        [ThreadStatic] public static glUniformMatrix2fvDelegate glUniformMatrix2fv;
        [ThreadStatic] public static glUniformMatrix3fvDelegate glUniformMatrix3fv;
        [ThreadStatic] public static glUniformMatrix4fvDelegate glUniformMatrix4fv;
        [ThreadStatic] public static glUseProgramDelegate glUseProgram;
        [ThreadStatic] public static glValidateProgramDelegate glValidateProgram;
        [ThreadStatic] public static glVertexAttrib1fDelegate glVertexAttrib1f;
        [ThreadStatic] public static glVertexAttrib1fvDelegate glVertexAttrib1fv;
        [ThreadStatic] public static glVertexAttrib2fDelegate glVertexAttrib2f;
        [ThreadStatic] public static glVertexAttrib2fvDelegate glVertexAttrib2fv;
        [ThreadStatic] public static glVertexAttrib3fDelegate glVertexAttrib3f;
        [ThreadStatic] public static glVertexAttrib3fvDelegate glVertexAttrib3fv;
        [ThreadStatic] public static glVertexAttrib4fDelegate glVertexAttrib4f;
        [ThreadStatic] public static glVertexAttrib4fvDelegate glVertexAttrib4fv;
        [ThreadStatic] public static glVertexAttribPointerDelegate glVertexAttribPointer;
        [ThreadStatic] public static glViewportDelegate glViewport;
        #endregion

        #region Loader
        public static void LoadApi(Func<string, IntPtr> getProcAddress)
        {
            glActiveTexture = Marshal.GetDelegateForFunctionPointer<glActiveTextureDelegate>(getProcAddress("glActiveTexture"));
            glAttachShader = Marshal.GetDelegateForFunctionPointer<glAttachShaderDelegate>(getProcAddress("glAttachShader"));
            glBindAttribLocation = Marshal.GetDelegateForFunctionPointer<glBindAttribLocationDelegate>(getProcAddress("glBindAttribLocation"));
            glBindBuffer = Marshal.GetDelegateForFunctionPointer<glBindBufferDelegate>(getProcAddress("glBindBuffer"));
            glBindFramebuffer = Marshal.GetDelegateForFunctionPointer<glBindFramebufferDelegate>(getProcAddress("glBindFramebuffer"));
            glBindRenderbuffer = Marshal.GetDelegateForFunctionPointer<glBindRenderbufferDelegate>(getProcAddress("glBindRenderbuffer"));
            glBindTexture = Marshal.GetDelegateForFunctionPointer<glBindTextureDelegate>(getProcAddress("glBindTexture"));
            glBlendColor = Marshal.GetDelegateForFunctionPointer<glBlendColorDelegate>(getProcAddress("glBlendColor"));
            glBlendEquation = Marshal.GetDelegateForFunctionPointer<glBlendEquationDelegate>(getProcAddress("glBlendEquation"));
            glBlendEquationSeparate = Marshal.GetDelegateForFunctionPointer<glBlendEquationSeparateDelegate>(getProcAddress("glBlendEquationSeparate"));
            glBlendFunc = Marshal.GetDelegateForFunctionPointer<glBlendFuncDelegate>(getProcAddress("glBlendFunc"));
            glBlendFuncSeparate = Marshal.GetDelegateForFunctionPointer<glBlendFuncSeparateDelegate>(getProcAddress("glBlendFuncSeparate"));
            glBufferData = Marshal.GetDelegateForFunctionPointer<glBufferDataDelegate>(getProcAddress("glBufferData"));
            glBufferSubData = Marshal.GetDelegateForFunctionPointer<glBufferSubDataDelegate>(getProcAddress("glBufferSubData"));
            glCheckFramebufferStatus = Marshal.GetDelegateForFunctionPointer<glCheckFramebufferStatusDelegate>(getProcAddress("glCheckFramebufferStatus"));
            glClear = Marshal.GetDelegateForFunctionPointer<glClearDelegate>(getProcAddress("glClear"));
            glClearColor = Marshal.GetDelegateForFunctionPointer<glClearColorDelegate>(getProcAddress("glClearColor"));
            glClearDepthf = Marshal.GetDelegateForFunctionPointer<glClearDepthfDelegate>(getProcAddress("glClearDepthf"));
            glClearStencil = Marshal.GetDelegateForFunctionPointer<glClearStencilDelegate>(getProcAddress("glClearStencil"));
            glColorMask = Marshal.GetDelegateForFunctionPointer<glColorMaskDelegate>(getProcAddress("glColorMask"));
            glCompileShader = Marshal.GetDelegateForFunctionPointer<glCompileShaderDelegate>(getProcAddress("glCompileShader"));
            glCompressedTexImage2D = Marshal.GetDelegateForFunctionPointer<glCompressedTexImage2DDelegate>(getProcAddress("glCompressedTexImage2D"));
            glCompressedTexSubImage2D = Marshal.GetDelegateForFunctionPointer<glCompressedTexSubImage2DDelegate>(getProcAddress("glCompressedTexSubImage2D"));
            glCopyTexImage2D = Marshal.GetDelegateForFunctionPointer<glCopyTexImage2DDelegate>(getProcAddress("glCopyTexImage2D"));
            glCopyTexSubImage2D = Marshal.GetDelegateForFunctionPointer<glCopyTexSubImage2DDelegate>(getProcAddress("glCopyTexSubImage2D"));
            glCreateProgram = Marshal.GetDelegateForFunctionPointer<glCreateProgramDelegate>(getProcAddress("glCreateProgram"));
            glCreateShader = Marshal.GetDelegateForFunctionPointer<glCreateShaderDelegate>(getProcAddress("glCreateShader"));
            glCullFace = Marshal.GetDelegateForFunctionPointer<glCullFaceDelegate>(getProcAddress("glCullFace"));
            glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<glDeleteBuffersDelegate>(getProcAddress("glDeleteBuffers"));
            glDeleteFramebuffers = Marshal.GetDelegateForFunctionPointer<glDeleteFramebuffersDelegate>(getProcAddress("glDeleteFramebuffers"));
            glDeleteProgram = Marshal.GetDelegateForFunctionPointer<glDeleteProgramDelegate>(getProcAddress("glDeleteProgram"));
            glDeleteRenderbuffers = Marshal.GetDelegateForFunctionPointer<glDeleteRenderbuffersDelegate>(getProcAddress("glDeleteRenderbuffers"));
            glDeleteShader = Marshal.GetDelegateForFunctionPointer<glDeleteShaderDelegate>(getProcAddress("glDeleteShader"));
            glDeleteTextures = Marshal.GetDelegateForFunctionPointer<glDeleteTexturesDelegate>(getProcAddress("glDeleteTextures"));
            glDepthFunc = Marshal.GetDelegateForFunctionPointer<glDepthFuncDelegate>(getProcAddress("glDepthFunc"));
            glDepthMask = Marshal.GetDelegateForFunctionPointer<glDepthMaskDelegate>(getProcAddress("glDepthMask"));
            glDepthRangef = Marshal.GetDelegateForFunctionPointer<glDepthRangefDelegate>(getProcAddress("glDepthRangef"));
            glDetachShader = Marshal.GetDelegateForFunctionPointer<glDetachShaderDelegate>(getProcAddress("glDetachShader"));
            glDisable = Marshal.GetDelegateForFunctionPointer<glDisableDelegate>(getProcAddress("glDisable"));
            glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<glDisableVertexAttribArrayDelegate>(getProcAddress("glDisableVertexAttribArray"));
            glDrawArrays = Marshal.GetDelegateForFunctionPointer<glDrawArraysDelegate>(getProcAddress("glDrawArrays"));
            glDrawElements = Marshal.GetDelegateForFunctionPointer<glDrawElementsDelegate>(getProcAddress("glDrawElements"));
            glEnable = Marshal.GetDelegateForFunctionPointer<glEnableDelegate>(getProcAddress("glEnable"));
            glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<glEnableVertexAttribArrayDelegate>(getProcAddress("glEnableVertexAttribArray"));
            glFinish = Marshal.GetDelegateForFunctionPointer<glFinishDelegate>(getProcAddress("glFinish"));
            glFlush = Marshal.GetDelegateForFunctionPointer<glFlushDelegate>(getProcAddress("glFlush"));
            glFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<glFramebufferRenderbufferDelegate>(getProcAddress("glFramebufferRenderbuffer"));
            glFramebufferTexture2D = Marshal.GetDelegateForFunctionPointer<glFramebufferTexture2DDelegate>(getProcAddress("glFramebufferTexture2D"));
            glFrontFace = Marshal.GetDelegateForFunctionPointer<glFrontFaceDelegate>(getProcAddress("glFrontFace"));
            glGenBuffers = Marshal.GetDelegateForFunctionPointer<glGenBuffersDelegate>(getProcAddress("glGenBuffers"));
            glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<glGenerateMipmapDelegate>(getProcAddress("glGenerateMipmap"));
            glGenFramebuffers = Marshal.GetDelegateForFunctionPointer<glGenFramebuffersDelegate>(getProcAddress("glGenFramebuffers"));
            glGenRenderbuffers = Marshal.GetDelegateForFunctionPointer<glGenRenderbuffersDelegate>(getProcAddress("glGenRenderbuffers"));
            glGenTextures = Marshal.GetDelegateForFunctionPointer<glGenTexturesDelegate>(getProcAddress("glGenTextures"));
            glGetActiveAttrib = Marshal.GetDelegateForFunctionPointer<glGetActiveAttribDelegate>(getProcAddress("glGetActiveAttrib"));
            glGetActiveUniform = Marshal.GetDelegateForFunctionPointer<glGetActiveUniformDelegate>(getProcAddress("glGetActiveUniform"));
            glGetAttachedShaders = Marshal.GetDelegateForFunctionPointer<glGetAttachedShadersDelegate>(getProcAddress("glGetAttachedShaders"));
            glGetAttribLocation = Marshal.GetDelegateForFunctionPointer<glGetAttribLocationDelegate>(getProcAddress("glGetAttribLocation"));
            glGetboolv = Marshal.GetDelegateForFunctionPointer<glGetboolvDelegate>(getProcAddress("glGetboolv"));
            glGetBufferParameteriv = Marshal.GetDelegateForFunctionPointer<glGetBufferParameterivDelegate>(getProcAddress("glGetBufferParameteriv"));
            glGetError = Marshal.GetDelegateForFunctionPointer<glGetErrorDelegate>(getProcAddress("glGetError"));
            glGetFloatv = Marshal.GetDelegateForFunctionPointer<glGetFloatvDelegate>(getProcAddress("glGetFloatv"));
            glGetFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<glGetFramebufferAttachmentParameterivDelegate>(getProcAddress("glGetFramebufferAttachmentParameteriv"));
            glGetIntegerv = Marshal.GetDelegateForFunctionPointer<glGetIntegervDelegate>(getProcAddress("glGetIntegerv"));
            glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<glGetProgramInfoLogDelegate>(getProcAddress("glGetProgramInfoLog"));
            glGetProgramiv = Marshal.GetDelegateForFunctionPointer<glGetProgramivDelegate>(getProcAddress("glGetProgramiv"));
            glGetRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<glGetRenderbufferParameterivDelegate>(getProcAddress("glGetRenderbufferParameteriv"));
            glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<glGetShaderInfoLogDelegate>(getProcAddress("glGetShaderInfoLog"));
            glGetShaderiv = Marshal.GetDelegateForFunctionPointer<glGetShaderivDelegate>(getProcAddress("glGetShaderiv"));
            glGetShaderPrecisionFormat = Marshal.GetDelegateForFunctionPointer<glGetShaderPrecisionFormatDelegate>(getProcAddress("glGetShaderPrecisionFormat"));
            glGetShaderSource = Marshal.GetDelegateForFunctionPointer<glGetShaderSourceDelegate>(getProcAddress("glGetShaderSource"));
            glGetString = Marshal.GetDelegateForFunctionPointer<glGetStringDelegate>(getProcAddress("glGetString"));
            glGetTexParameterfv = Marshal.GetDelegateForFunctionPointer<glGetTexParameterfvDelegate>(getProcAddress("glGetTexParameterfv"));
            glGetTexParameteriv = Marshal.GetDelegateForFunctionPointer<glGetTexParameterivDelegate>(getProcAddress("glGetTexParameteriv"));
            glGetUniformfv = Marshal.GetDelegateForFunctionPointer<glGetUniformfvDelegate>(getProcAddress("glGetUniformfv"));
            glGetUniformiv = Marshal.GetDelegateForFunctionPointer<glGetUniformivDelegate>(getProcAddress("glGetUniformiv"));
            glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<glGetUniformLocationDelegate>(getProcAddress("glGetUniformLocation"));
            glGetVertexAttribfv = Marshal.GetDelegateForFunctionPointer<glGetVertexAttribfvDelegate>(getProcAddress("glGetVertexAttribfv"));
            glGetVertexAttribiv = Marshal.GetDelegateForFunctionPointer<glGetVertexAttribivDelegate>(getProcAddress("glGetVertexAttribiv"));
            glGetVertexAttribPointerv = Marshal.GetDelegateForFunctionPointer<glGetVertexAttribPointervDelegate>(getProcAddress("glGetVertexAttribPointerv"));
            glHint = Marshal.GetDelegateForFunctionPointer<glHintDelegate>(getProcAddress("glHint"));
            glIsBuffer = Marshal.GetDelegateForFunctionPointer<glIsBufferDelegate>(getProcAddress("glIsBuffer"));
            glIsEnabled = Marshal.GetDelegateForFunctionPointer<glIsEnabledDelegate>(getProcAddress("glIsEnabled"));
            glIsFramebuffer = Marshal.GetDelegateForFunctionPointer<glIsFramebufferDelegate>(getProcAddress("glIsFramebuffer"));
            glIsProgram = Marshal.GetDelegateForFunctionPointer<glIsProgramDelegate>(getProcAddress("glIsProgram"));
            glIsRenderbuffer = Marshal.GetDelegateForFunctionPointer<glIsRenderbufferDelegate>(getProcAddress("glIsRenderbuffer"));
            glIsShader = Marshal.GetDelegateForFunctionPointer<glIsShaderDelegate>(getProcAddress("glIsShader"));
            glIsTexture = Marshal.GetDelegateForFunctionPointer<glIsTextureDelegate>(getProcAddress("glIsTexture"));
            glLineWidth = Marshal.GetDelegateForFunctionPointer<glLineWidthDelegate>(getProcAddress("glLineWidth"));
            glLinkProgram = Marshal.GetDelegateForFunctionPointer<glLinkProgramDelegate>(getProcAddress("glLinkProgram"));
            glPixelStorei = Marshal.GetDelegateForFunctionPointer<glPixelStoreiDelegate>(getProcAddress("glPixelStorei"));
            glPolygonOffset = Marshal.GetDelegateForFunctionPointer<glPolygonOffsetDelegate>(getProcAddress("glPolygonOffset"));
            glReadPixels = Marshal.GetDelegateForFunctionPointer<glReadPixelsDelegate>(getProcAddress("glReadPixels"));
            glReleaseShaderCompiler = Marshal.GetDelegateForFunctionPointer<glReleaseShaderCompilerDelegate>(getProcAddress("glReleaseShaderCompiler"));
            glRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<glRenderbufferStorageDelegate>(getProcAddress("glRenderbufferStorage"));
            glSampleCoverage = Marshal.GetDelegateForFunctionPointer<glSampleCoverageDelegate>(getProcAddress("glSampleCoverage"));
            glScissor = Marshal.GetDelegateForFunctionPointer<glScissorDelegate>(getProcAddress("glScissor"));
            glShaderBinary = Marshal.GetDelegateForFunctionPointer<glShaderBinaryDelegate>(getProcAddress("glShaderBinary"));
            glShaderSource = Marshal.GetDelegateForFunctionPointer<glShaderSourceDelegate>(getProcAddress("glShaderSource"));
            glStencilFunc = Marshal.GetDelegateForFunctionPointer<glStencilFuncDelegate>(getProcAddress("glStencilFunc"));
            glStencilFuncSeparate = Marshal.GetDelegateForFunctionPointer<glStencilFuncSeparateDelegate>(getProcAddress("glStencilFuncSeparate"));
            glStencilMask = Marshal.GetDelegateForFunctionPointer<glStencilMaskDelegate>(getProcAddress("glStencilMask"));
            glStencilMaskSeparate = Marshal.GetDelegateForFunctionPointer<glStencilMaskSeparateDelegate>(getProcAddress("glStencilMaskSeparate"));
            glStencilOp = Marshal.GetDelegateForFunctionPointer<glStencilOpDelegate>(getProcAddress("glStencilOp"));
            glStencilOpSeparate = Marshal.GetDelegateForFunctionPointer<glStencilOpSeparateDelegate>(getProcAddress("glStencilOpSeparate"));
            glTexImage2D = Marshal.GetDelegateForFunctionPointer<glTexImage2DDelegate>(getProcAddress("glTexImage2D"));
            glTexParameterf = Marshal.GetDelegateForFunctionPointer<glTexParameterfDelegate>(getProcAddress("glTexParameterf"));
            glTexParameterfv = Marshal.GetDelegateForFunctionPointer<glTexParameterfvDelegate>(getProcAddress("glTexParameterfv"));
            glTexParameteri = Marshal.GetDelegateForFunctionPointer<glTexParameteriDelegate>(getProcAddress("glTexParameteri"));
            glTexParameteriv = Marshal.GetDelegateForFunctionPointer<glTexParameterivDelegate>(getProcAddress("glTexParameteriv"));
            glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<glTexSubImage2DDelegate>(getProcAddress("glTexSubImage2D"));
            glUniform1f = Marshal.GetDelegateForFunctionPointer<glUniform1fDelegate>(getProcAddress("glUniform1f"));
            glUniform1fv = Marshal.GetDelegateForFunctionPointer<glUniform1fvDelegate>(getProcAddress("glUniform1fv"));
            glUniform1i = Marshal.GetDelegateForFunctionPointer<glUniform1iDelegate>(getProcAddress("glUniform1i"));
            glUniform1iv = Marshal.GetDelegateForFunctionPointer<glUniform1ivDelegate>(getProcAddress("glUniform1iv"));
            glUniform2f = Marshal.GetDelegateForFunctionPointer<glUniform2fDelegate>(getProcAddress("glUniform2f"));
            glUniform2fv = Marshal.GetDelegateForFunctionPointer<glUniform2fvDelegate>(getProcAddress("glUniform2fv"));
            glUniform2i = Marshal.GetDelegateForFunctionPointer<glUniform2iDelegate>(getProcAddress("glUniform2i"));
            glUniform2iv = Marshal.GetDelegateForFunctionPointer<glUniform2ivDelegate>(getProcAddress("glUniform2iv"));
            glUniform3f = Marshal.GetDelegateForFunctionPointer<glUniform3fDelegate>(getProcAddress("glUniform3f"));
            glUniform3fv = Marshal.GetDelegateForFunctionPointer<glUniform3fvDelegate>(getProcAddress("glUniform3fv"));
            glUniform3i = Marshal.GetDelegateForFunctionPointer<glUniform3iDelegate>(getProcAddress("glUniform3i"));
            glUniform3iv = Marshal.GetDelegateForFunctionPointer<glUniform3ivDelegate>(getProcAddress("glUniform3iv"));
            glUniform4f = Marshal.GetDelegateForFunctionPointer<glUniform4fDelegate>(getProcAddress("glUniform4f"));
            glUniform4fv = Marshal.GetDelegateForFunctionPointer<glUniform4fvDelegate>(getProcAddress("glUniform4fv"));
            glUniform4i = Marshal.GetDelegateForFunctionPointer<glUniform4iDelegate>(getProcAddress("glUniform4i"));
            glUniform4iv = Marshal.GetDelegateForFunctionPointer<glUniform4ivDelegate>(getProcAddress("glUniform4iv"));
            glUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<glUniformMatrix2fvDelegate>(getProcAddress("glUniformMatrix2fv"));
            glUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<glUniformMatrix3fvDelegate>(getProcAddress("glUniformMatrix3fv"));
            glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<glUniformMatrix4fvDelegate>(getProcAddress("glUniformMatrix4fv"));
            glUseProgram = Marshal.GetDelegateForFunctionPointer<glUseProgramDelegate>(getProcAddress("glUseProgram"));
            glValidateProgram = Marshal.GetDelegateForFunctionPointer<glValidateProgramDelegate>(getProcAddress("glValidateProgram"));
            glVertexAttrib1f = Marshal.GetDelegateForFunctionPointer<glVertexAttrib1fDelegate>(getProcAddress("glVertexAttrib1f"));
            glVertexAttrib1fv = Marshal.GetDelegateForFunctionPointer<glVertexAttrib1fvDelegate>(getProcAddress("glVertexAttrib1fv"));
            glVertexAttrib2f = Marshal.GetDelegateForFunctionPointer<glVertexAttrib2fDelegate>(getProcAddress("glVertexAttrib2f"));
            glVertexAttrib2fv = Marshal.GetDelegateForFunctionPointer<glVertexAttrib2fvDelegate>(getProcAddress("glVertexAttrib2fv"));
            glVertexAttrib3f = Marshal.GetDelegateForFunctionPointer<glVertexAttrib3fDelegate>(getProcAddress("glVertexAttrib3f"));
            glVertexAttrib3fv = Marshal.GetDelegateForFunctionPointer<glVertexAttrib3fvDelegate>(getProcAddress("glVertexAttrib3fv"));
            glVertexAttrib4f = Marshal.GetDelegateForFunctionPointer<glVertexAttrib4fDelegate>(getProcAddress("glVertexAttrib4f"));
            glVertexAttrib4fv = Marshal.GetDelegateForFunctionPointer<glVertexAttrib4fvDelegate>(getProcAddress("glVertexAttrib4fv"));
            glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<glVertexAttribPointerDelegate>(getProcAddress("glVertexAttribPointer"));
            glViewport = Marshal.GetDelegateForFunctionPointer<glViewportDelegate>(getProcAddress("glViewport"));
        }
        #endregion

        #region helpers

        public static void GetInteger<T>(GetPName pname, out T data)
            where T : struct
        {
            data = default(T);

            unsafe
            {
                TypedReference refData = __makeref(data);
                IntPtr refDataPtr = *(IntPtr*)(&refData);

                glGetIntegerv(pname, refDataPtr.ToPointer());
            }
        }

        public static void ShaderSource(uint shader, string[] @string)
        {
            var lengths = @string.Select(x => x?.Length ?? 0).ToArray();
            var count = @string.Length;

            unsafe
            {
                fixed (int* p_length = lengths)
                {
                    glShaderSource(shader, count, @string, p_length);
                }
            }
        }

        public static void GetFloat<T>(GetPName pname, out T data)
            where T : struct
        {
            data = default(T);

            unsafe
            {
                TypedReference refData = __makeref(data);
                IntPtr refDataPtr = *(IntPtr*)(&refData);

                glGetFloatv(pname, refDataPtr.ToPointer());
            }
        }

        public static void SetFeature(EnableCap feature, bool value)
        {
            if (value)
            {
                glEnable(feature);
            }
            else
            {
                glDisable(feature);
            }
        }



        #endregion
    }
}