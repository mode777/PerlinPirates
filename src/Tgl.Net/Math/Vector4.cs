using System;
using System.Runtime.InteropServices;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4 : IEquatable<Vector4>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector4(Vector4 a)
        {
            X = a.X;
            Y = a.Y;
            Z = a.Z;
            W = a.W;
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static void Add(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = a.X + b.X;
            @out.Y = a.Y + b.Y;
            @out.Z = a.Z + b.Z;
            @out.W = a.W + b.W;
        }

        public static void Subtract(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = a.X - b.X;
            @out.Y = a.Y - b.Y;
            @out.Z = a.Z - b.Z;
            @out.W = a.W - b.W;
        }

        public static void Multiply(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = a.X * b.X;
            @out.Y = a.Y * b.Y;
            @out.Z = a.Z * b.Z;
            @out.W = a.W * b.W;
        }

        public static void Divide(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = a.X / b.X;
            @out.Y = a.Y / b.Y;
            @out.Z = a.Z / b.Z;
            @out.W = a.W / b.W;
        }

        public static void Ceil(ref Vector4 @out, ref Vector4 a)
        {
            @out.X = (float) System.Math.Ceiling(a.X);
            @out.Y = (float) System.Math.Ceiling(a.Y);
            @out.Z = (float) System.Math.Ceiling(a.Z);
            @out.W = (float) System.Math.Ceiling(a.W);
        }

        public static void Floor(ref Vector4 @out, ref Vector4 a)
        {
            @out.X = (float) System.Math.Floor(a.X);
            @out.Y = (float) System.Math.Floor(a.Y);
            @out.Z = (float) System.Math.Floor(a.Z);
            @out.W = (float) System.Math.Floor(a.W);
        }

        public static void Min(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = System.Math.Min(a.X, b.X);
            @out.Y = System.Math.Min(a.Y, b.Y);
            @out.Z = System.Math.Min(a.Z, b.Z);
            @out.W = System.Math.Min(a.W, b.W);
        }

        public static void Max(ref Vector4 @out, ref Vector4 a, ref Vector4 b)
        {
            @out.X = System.Math.Max(a.X, b.X);
            @out.Y = System.Math.Max(a.Y, b.Y);
            @out.Z = System.Math.Max(a.Z, b.Z);
            @out.W = System.Math.Max(a.W, b.W);
        }

        public static void Round(ref Vector4 @out, ref Vector4 a)
        {
            @out.X = (float) System.Math.Round(a.X);
            @out.Y = (float) System.Math.Round(a.Y);
            @out.Z = (float) System.Math.Round(a.Z);
            @out.W = (float) System.Math.Round(a.W);
        }

        public static void Scale(ref Vector4 @out, ref Vector4 a, float b)
        {
            @out.X = a.X * b;
            @out.Y = a.Y * b;
            @out.Z = a.Z * b;
            @out.W = a.W * b;
        }

        public static void ScaleAndAdd(ref Vector4 @out, ref Vector4 a, ref Vector4 b, float scale)
        {
            @out.X = a.X + (b.X * scale);
            @out.Y = a.Y + (b.Y * scale);
            @out.Z = a.Z + (b.Z * scale);
            @out.W = a.W + (b.W * scale);
        }

        public static float Distance(ref Vector4 a, ref Vector4 b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            var z = b.Z - a.Z;
            var w = b.W - a.W;
            return (float) System.Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public static float SquaredDistance(ref Vector4 a, ref Vector4 b)
        {
            var x = b.X - a.X;
            var y = b.Y - a.Y;
            var z = b.Z - a.Z;
            var w = b.W - a.W;
            return x * x + y * y + z * z + w * w;
        }

        public static float Length(ref Vector4 a)
        {
            var x = a.X;
            var y = a.Y;
            var z = a.Z;
            var w = a.W;
            return (float) System.Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public static float SquaredLength(ref Vector4 a)
        {
            var x = a.X;
            var y = a.Y;
            var z = a.Z;
            var w = a.W;
            return x * x + y * y + z * z + w * w;
        }

        public static void Negate(ref Vector4 @out, ref Vector4 a)
        {
            @out.X = -a.X;
            @out.Y = -a.Y;
            @out.Z = -a.Z;
            @out.W = -a.W;
        }

        public static void Inverse(ref Vector4 @out, ref Vector4 a)
        {
            @out.X = 1.0f / a.X;
            @out.Y = 1.0f / a.Y;
            @out.Z = 1.0f / a.Z;
            @out.W = 1.0f / a.W;
        }

        public static void Normalize(ref Vector4 @out, ref Vector4 a)
        {
            var x = a.X;
            var y = a.Y;
            var z = a.Z;
            var w = a.W;
            var len = x * x + y * y + z * z + w * w;
            if (len > 0)
            {
                len = 1 / (float)System.Math.Sqrt(len);
            }
            @out.X = x * len;
            @out.Y = y * len;
            @out.Z = z * len;
            @out.W = w * len;
        }

        public static float Dot(Vector4 a, Vector4 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        }

        public static void Lerp(ref Vector4 @out, ref Vector4 a, ref Vector4 b, float t)
        {
            var ax = a.X;
            var ay = a.Y;
            var az = a.Z;
            var aw = a.W;
            @out.X = ax + t * (b.X - ax);
            @out.Y = ay + t * (b.Y - ay);
            @out.Z = az + t * (b.Z - az);
            @out.W = aw + t * (b.W - aw);
        }

        public static void Random(ref Vector4 @out, float scale)
        {
            scale = scale == default(float) ? 1.0f : scale;
            var r = new Random();


            // MarsagliVector4 a, George. Choosing a Point from the Surface of a
            // Sphere. Ann. Math. Statist. 43 (1972), no. 2, 645--646.
            // http://projecteuclid.org/euclid.aoms/1177692644;
            float v1, v2, v3, v4;
            float s1, s2;

            do
            {
                v1 = (float)r.NextDouble() * 2 - 1;
                v2 = (float)r.NextDouble() * 2 - 1;
                s1 = v1 * v1 + v2 * v2;
            } while (s1 >= 1);

            do
            {
                v3 = (float)r.NextDouble() * 2 - 1;
                v4 = (float)r.NextDouble() * 2 - 1;
                s2 = v3 * v3 + v4 * v4;
            } while (s2 >= 1);

            var d = (float)System.Math.Sqrt((1 - s1) / s2);
            @out.X = scale * v1;
            @out.Y = scale * v2;
            @out.Z = scale * v3 * d;
            @out.W = scale * v4 * d;
        }

        //public static void TransformMat4(ref Vector4 @out, ref Vector4 a, Matrix4 m)
        //{
        //    float x = a.X, y = a.Y, z = a.Z, w = a.W;
        //    @out.X = m[0] * x + m[4] * y + m[8] * z + m[12] * w;
        //    @out.Y = m[1] * x + m[5] * y + m[9] * z + m[13] * w;
        //    @out.Z = m[2] * x + m[6] * y + m[10] * z + m[14] * w;
        //    @out.W = m[3] * x + m[7] * y + m[11] * z + m[15] * w;
        //}

        public static Vector4 TransformQuat(Vector4 @out, Vector4 a, Quaternion q)
        {
            float x = a.X, y = a.Y, z = a.Z;
            float qx = q.X, qy = q.Y, qz = q.Z, qw = q.W;

            // calculate quat * vec
            var ix = qw * x + qy * z - qz * y;
            var iy = qw * y + qz * x - qx * z;
            var iz = qw * z + qx * y - qy * x;
            var iw = -qx * x - qy * y - qz * z;

            // calculate result * inverse quat
            @out.X = ix * qw + iw * -qx + iy * -qz - iz * -qy;
            @out.Y = iy * qw + iw * -qy + iz * -qx - ix * -qz;
            @out.Z = iz * qw + iw * -qz + ix * -qy - iy * -qx;
            @out.W = a.W;
            return @out;
        }

        public override string ToString()
        {
            return $"vec4({X}, {Y}, {Z}, {W})";
        }

        public static bool ExactEquals(ref Vector4 a, ref Vector4 b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
        }

        //public static Vector4 Equals(Vector4 a, Vector4 b)
        //{
        //    var a0 = a.X, a1 = a.Y, a2 = a.Z, a3 = a.W;
        //    var b0 = b.X, b1 = b.Y, b2 = b.Z, b3 = b.W;
        //    return (System.Math.abs(a0 - b0) <= glMatrix.EPSILON * System.Math.max(1.0, System.Math.abs(a0), System.Math.abs(b0)) &&
        //            System.Math.abs(a1 - b1) <= glMatrix.EPSILON * System.Math.max(1.0, System.Math.abs(a1), System.Math.abs(b1)) &&
        //            System.Math.abs(a2 - b2) <= glMatrix.EPSILON * System.Math.max(1.0, System.Math.abs(a2), System.Math.abs(b2)) &&
        //            System.Math.abs(a3 - b3) <= glMatrix.EPSILON * System.Math.max(1.0, System.Math.abs(a3), System.Math.abs(b3)));
        //}
        public bool Equals(Vector4 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }
    }
}
