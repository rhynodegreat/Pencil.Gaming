#region License
// Copyright (c) 2013 Antonie Blom
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Runtime.InteropServices;

namespace Pencil.Gaming.MathUtils {
	/// <summary>
	/// Represents a 4x4 Matrix
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Matrix4x4 : IEquatable<Matrix4x4> {
        #region Fields

        public float
            M11, M12, M13, M14,
            M21, M22, M23, M24,
            M31, M32, M33, M34,
            M41, M42, M43, M44;
 
		/// <summary>
		/// The identity matrix.
		/// </summary>
		public static readonly Matrix4x4 Identity = new Matrix4x4(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
            );

		/// <summary>
		/// The zero matrix.
		/// </summary>
		public static readonly Matrix4x4 Zero = new Matrix4x4(
            0, 0, 0, 0,
            0, 0, 0, 0, 
            0, 0, 0, 0,
            0, 0, 0, 0
            );

		#endregion

		#region Constructors

		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		/// <param name="m00">First item of the first row of the matrix.</param>
		/// <param name="m01">Second item of the first row of the matrix.</param>
		/// <param name="m02">Third item of the first row of the matrix.</param>
		/// <param name="m03">Fourth item of the first row of the matrix.</param>
		/// <param name="m10">First item of the second row of the matrix.</param>
		/// <param name="m11">Second item of the second row of the matrix.</param>
		/// <param name="m12">Third item of the second row of the matrix.</param>
		/// <param name="m13">Fourth item of the second row of the matrix.</param>
		/// <param name="m20">First item of the third row of the matrix.</param>
		/// <param name="m21">Second item of the third row of the matrix.</param>
		/// <param name="m22">Third item of the third row of the matrix.</param>
		/// <param name="m23">First item of the third row of the matrix.</param>
		/// <param name="m30">Fourth item of the fourth row of the matrix.</param>
		/// <param name="m31">Second item of the fourth row of the matrix.</param>
		/// <param name="m32">Third item of the fourth row of the matrix.</param>
		/// <param name="m33">Fourth item of the fourth row of the matrix.</param>
		public Matrix4x4(
			float m00, float m01, float m02, float m03,
			float m10, float m11, float m12, float m13,
			float m20, float m21, float m22, float m23,
			float m30, float m31, float m32, float m33) {
            M11 = m00;
            M12 = m01;
            M13 = m02;
            M14 = m03;
            M21 = m10;
            M22 = m11;
            M23 = m12;
            M24 = m13;
            M31 = m20;
            M32 = m21;
            M33 = m22;
            M34 = m23;
            M41 = m30;
            M42 = m31;
            M43 = m32;
            M44 = m33;
        }

		#endregion

		#region Public Members

		#region Properties

		/// <summary>
		/// Gets the determinant of this matrix.
		/// </summary>
		public float Determinant {
			get {
				float m11 = M11, m12 = M12, m13 = M13, m14 = M14,
				m21 = M21, m22 = M22, m23 = M23, m24 = M24,
				m31 = M31, m32 = M32, m33 = M33, m34 = M34,
				m41 = M41, m42 = M42, m43 = M43, m44 = M44;

				return
					m11 * m22 * m33 * m44 - m11 * m22 * m34 * m43 + m11 * m23 * m34 * m42 - m11 * m23 * m32 * m44
					+ m11 * m24 * m32 * m43 - m11 * m24 * m33 * m42 - m12 * m23 * m34 * m41 + m12 * m23 * m31 * m44
					- m12 * m24 * m31 * m43 + m12 * m24 * m33 * m41 - m12 * m21 * m33 * m44 + m12 * m21 * m34 * m43
					+ m13 * m24 * m31 * m42 - m13 * m24 * m32 * m41 + m13 * m21 * m32 * m44 - m13 * m21 * m34 * m42
					+ m13 * m22 * m34 * m41 - m13 * m22 * m31 * m44 - m14 * m21 * m32 * m43 + m14 * m21 * m33 * m42
					- m14 * m22 * m33 * m41 + m14 * m22 * m31 * m43 - m14 * m23 * m31 * m42 + m14 * m23 * m32 * m41;
			}
		}

        /// <summary>
        /// Gets the first row of this matrix.
        /// </summary>

        public Vector4 Row0 {
            get { return new Vector4(M11, M12, M13, M14); }
            set {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
                M14 = value.W;
            }
        }

        /// <summary>
        /// Gets the second row of this matrix.
        /// </summary>

        public Vector4 Row1 {
            get { return new Vector4(M11, M12, M13, M14); }
            set {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
                M14 = value.W;
            }
        }

        /// <summary>
        /// Gets the third row of this matrix.
        /// </summary>

        public Vector4 Row2 {
            get { return new Vector4(M11, M12, M13, M14); }
            set {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
                M14 = value.W;
            }
        }

        /// <summary>
        /// Gets the fourth row of this matrix.
        /// </summary>

        public Vector4 Row3 {
            get { return new Vector4(M11, M12, M13, M14); }
            set {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
                M14 = value.W;
            }
        }

        /// <summary>
        /// Gets the first column of this matrix.
        /// </summary>
        public Vector4 Column1 {
			get { return new Vector4(M11, M21, M31, M41); }
			set {
				M11 = value.X;
				M21 = value.Y;
				M31 = value.Z;
				M41 = value.W;
			}
		}

		/// <summary>
		/// Gets the second column of this matrix.
		/// </summary>
		public Vector4 Column2 {
			get { return new Vector4(M12, M22, M32, M42); }
			set {
				M12 = value.X;
				M22 = value.Y;
				M32 = value.Z;
				M42 = value.W;
			}
		}

		/// <summary>
		/// Gets the third column of this matrix.
		/// </summary>
		public Vector4 Column3 {
			get { return new Vector4(M13, M23, M33, M43); }
			set {
				M13 = value.X;
				M23 = value.Y;
				M33 = value.Z;
				M43 = value.W;
			}
		}

		/// <summary>
		/// Gets the fourth column of this matrix.
		/// </summary>
		public Vector4 Column4 {
			get { return new Vector4(M14, M24, M34, M44); }
			set {
				M14 = value.X;
				M24 = value.Y;
				M34 = value.Z;
				M44 = value.W;
			}
		}

		#endregion

		#region Indexers

        /// <summary>
        /// Gets of sets the value at a specified index.
        /// </summary>

        public float this [int index] {
            get {
                switch (index) {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                    default: throw new IndexOutOfRangeException(String.Format("Tried to access matrix at row {0} (range is [0, 15])", index));
                }
            }
            set {
                switch (index) {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                    default: throw new IndexOutOfRangeException(String.Format("Tried to access matrix at row {0} (range is [0, 15])", index));
                }
            }
        }

        /// <summary>
        /// Gets or sets the value at a specified row and column.
        /// </summary>
        public float this [int rowIndex, int columnIndex] {
			get {
                if (rowIndex > 3 || rowIndex < 0)
                    throw new IndexOutOfRangeException(String.Format("Tried to access matrix at row {0} (range is [0, 3])", rowIndex));
                if (columnIndex > 3 || columnIndex < 0)
                    throw new IndexOutOfRangeException(String.Format("Tried to access matrix at column {0} (range is [0, 3])", columnIndex));

                int index = (rowIndex * 4) + columnIndex;
                return this[index];
			}
			set {
                if (rowIndex > 3 || rowIndex < 0)
                    throw new IndexOutOfRangeException(String.Format("Tried to access matrix at row {0} (range is [0, 3])", rowIndex));
                if (columnIndex > 3 || columnIndex < 0)
                    throw new IndexOutOfRangeException(String.Format("Tried to access matrix at column {0} (range is [0, 3])", columnIndex));

                int index = (rowIndex * 4) + columnIndex;
                this[index] = value;
            }
		}

		#endregion

		#region Instance

		#region public void Invert()

		/// <summary>
		/// Converts this instance into its inverse.
		/// </summary>
		public void Invert() {
			this = Matrix4x4.Invert(this);
		}

		#endregion

		#region public void Transpose()

		/// <summary>
		/// Converts this instance into its transpose.
		/// </summary>
		public void Transpose() {
			this = Matrix4x4.Transpose(this);
		}

		#endregion

		#endregion

		#region Static
		
		#region CreateFromAxisAngle
		
		/// <summary>
		/// Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <param name="result">A matrix instance.</param>
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix4x4 result) {
			// normalize and create a local copy of the vector.
			axis.Normalize();
			float axisX = axis.X, axisY = axis.Y, axisZ = axis.Z;

			// calculate angles
			float cos = (float)System.Math.Cos(-angle);
			float sin = (float)System.Math.Sin(-angle);
			float t = 1.0f - cos;

			// do the conversion math once
			float tXX = t * axisX * axisX,
			tXY = t * axisX * axisY,
			tXZ = t * axisX * axisZ,
			tYY = t * axisY * axisY,
			tYZ = t * axisY * axisZ,
			tZZ = t * axisZ * axisZ;

			float sinX = sin * axisX,
			sinY = sin * axisY,
			sinZ = sin * axisZ;

			result.M11 = tXX + cos;
			result.M12 = tXY - sinZ;
			result.M13 = tXZ + sinY;
			result.M14 = 0;
			result.M21 = tXY + sinZ;
			result.M22 = tYY + cos;
			result.M23 = tYZ - sinX;
			result.M24 = 0;
			result.M31 = tXZ - sinY;
			result.M32 = tYZ + sinX;
			result.M33 = tZZ + cos;
			result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;
		}
		
		/// <summary>
		/// Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix4x4 CreateFromAxisAngle(Vector3 axis, float angle) {
			Matrix4x4 result;
			CreateFromAxisAngle(axis, angle, out result);
			return result;
		}
		
		#endregion

		#region CreateFromQuaternion

		/// <summary>
		/// Builds a rotation matrix from a quaternion.
		/// </summary>
		/// <param name="q">The quaternion to rotate by.</param>
		/// <param name="result">A matrix instance.</param>
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix4x4 result) {
			Vector3 axis;
			float angle;
			q.ToAxisAngle(out axis, out angle);
			CreateFromAxisAngle(axis, angle, out result);
		}

		/// <summary>
		/// Builds a rotation matrix from a quaternion.
		/// </summary>
		/// <param name="q">The quaternion to rotate by.</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix4x4 CreateFromQuaternion(Quaternion q) {
			Matrix4x4 result;
			CreateFromQuaternion(ref q, out result);
			return result;
		}

		#endregion

		#region CreateRotation[XYZ]

		/// <summary>
		/// Builds a rotation matrix for a rotation around the x-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationX(float angle, out Matrix4x4 result) {
			float cos = (float)System.Math.Cos(angle);
			float sin = (float)System.Math.Sin(angle);

			result = Identity;
			result.M22 = cos;
			result.M23 = sin;
			result.M32 = -sin;
			result.M33 = cos;
		}

		/// <summary>
		/// Builds a rotation matrix for a rotation around the x-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateRotationX(float angle) {
			Matrix4x4 result;
			CreateRotationX(angle, out result);
			return result;
		}

		/// <summary>
		/// Builds a rotation matrix for a rotation around the y-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationY(float angle, out Matrix4x4 result) {
			float cos = (float)System.Math.Cos(angle);
			float sin = (float)System.Math.Sin(angle);

			result = Identity;
			result.M11 = cos;
			result.M13 = -sin;
			result.M31 = sin;
			result.M33 = cos;
		}

		/// <summary>
		/// Builds a rotation matrix for a rotation around the y-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateRotationY(float angle) {
			Matrix4x4 result;
			CreateRotationY(angle, out result);
			return result;
		}

		/// <summary>
		/// Builds a rotation matrix for a rotation around the z-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationZ(float angle, out Matrix4x4 result) {
			float cos = (float)System.Math.Cos(angle);
			float sin = (float)System.Math.Sin(angle);

			result = Identity;
			result.M11 = cos;
			result.M12 = sin;
			result.M21 = -sin;
			result.M22 = cos;
		}

		/// <summary>
		/// Builds a rotation matrix for a rotation around the z-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateRotationZ(float angle) {
			Matrix4x4 result;
			CreateRotationZ(angle, out result);
			return result;
		}

		#endregion

		#region CreateTranslation

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="x">X translation.</param>
		/// <param name="y">Y translation.</param>
		/// <param name="z">Z translation.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateTranslation(float x, float y, float z, out Matrix4x4 result) {
			result = Identity;
			result.M41 = x;
			result.M42 = y;
			result.M43 = z;
		}

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="vector">The translation vector.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateTranslation(ref Vector3 vector, out Matrix4x4 result) {
			result = Identity;
			result.M41 = vector.X;
			result.M42 = vector.Y;
			result.M43 = vector.Z;
		}

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="x">X translation.</param>
		/// <param name="y">Y translation.</param>
		/// <param name="z">Z translation.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateTranslation(float x, float y, float z) {
			Matrix4x4 result;
			CreateTranslation(x, y, z, out result);
			return result;
		}

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="vector">The translation vector.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateTranslation(Vector3 vector) {
			Matrix4x4 result;
			CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		#endregion

		#region CreateScale

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4x4 CreateScale(float scale) {
			Matrix4x4 result;
			CreateScale(scale, out result);
			return result;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4x4 CreateScale(Vector3 scale) {
			Matrix4x4 result;
			CreateScale(ref scale, out result);
			return result;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="x">Scale factor for the x axis.</param>
		/// <param name="y">Scale factor for the y axis.</param>
		/// <param name="z">Scale factor for the z axis.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4x4 CreateScale(float x, float y, float z) {
			Matrix4x4 result;
			CreateScale(x, y, z, out result);
			return result;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(float scale, out Matrix4x4 result) {
			result = Identity;
			result.M11 = scale;
			result.M22 = scale;
			result.M33 = scale;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(ref Vector3 scale, out Matrix4x4 result) {
			result = Identity;
			result.M11 = scale.X;
			result.M22 = scale.Y;
			result.M33 = scale.Z;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="x">Scale factor for the x axis.</param>
		/// <param name="y">Scale factor for the y axis.</param>
		/// <param name="z">Scale factor for the z axis.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(float x, float y, float z, out Matrix4x4 result) {
			result = Identity;
			result.M11 = x;
			result.M22 = y;
			result.M33 = z;
		}

		#endregion

		#region CreateOrthographic

		/// <summary>
		/// Creates an orthographic projection matrix.
		/// </summary>
		/// <param name="width">The width of the projection volume.</param>
		/// <param name="height">The height of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateOrthographic(float width, float height, float zNear, float zFar, out Matrix4x4 result) {
			CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, zNear, zFar, out result);
		}

		/// <summary>
		/// Creates an orthographic projection matrix.
		/// </summary>
		/// <param name="width">The width of the projection volume.</param>
		/// <param name="height">The height of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <rereturns>The resulting Matrix4 instance.</rereturns>
		public static Matrix4x4 CreateOrthographic(float width, float height, float zNear, float zFar) {
			Matrix4x4 result;
			CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, zNear, zFar, out result);
			return result;
		}

		#endregion

		#region CreateOrthographicOffCenter

		/// <summary>
		/// Creates an orthographic projection matrix.
		/// </summary>
		/// <param name="left">The left edge of the projection volume.</param>
		/// <param name="right">The right edge of the projection volume.</param>
		/// <param name="bottom">The bottom edge of the projection volume.</param>
		/// <param name="top">The top edge of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4x4 result) {
			result = Identity;

			float invRL = 1.0f / (right - left);
			float invTB = 1.0f / (top - bottom);
			float invFN = 1.0f / (zFar - zNear);

			result.M11 = 2 * invRL;
			result.M22 = 2 * invTB;
			result.M33 = -2 * invFN;

			result.M41 = -(right + left) * invRL;
			result.M42 = -(top + bottom) * invTB;
			result.M43 = -(zFar + zNear) * invFN;
		}

		/// <summary>
		/// Creates an orthographic projection matrix.
		/// </summary>
		/// <param name="left">The left edge of the projection volume.</param>
		/// <param name="right">The right edge of the projection volume.</param>
		/// <param name="bottom">The bottom edge of the projection volume.</param>
		/// <param name="top">The top edge of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4x4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar) {
			Matrix4x4 result;
			CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		#endregion
		
		#region CreatePerspectiveFieldOfView
		
		/// <summary>
		/// Creates a perspective projection matrix.
		/// </summary>
		/// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
		/// <param name="aspect">Aspect ratio of the view (width / height)</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <param name="result">A projection matrix that transforms camera space to raster space</param>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Thrown under the following conditions:
		/// <list type="bullet">
		/// <item>fovy is zero, less than zero or larger than Math.PI</item>
		/// <item>aspect is negative or zero</item>
		/// <item>zNear is negative or zero</item>
		/// <item>zFar is negative or zero</item>
		/// <item>zNear is larger than zFar</item>
		/// </list>
		/// </exception>
		public static void CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar, out Matrix4x4 result) {
			if (fovy <= 0 || fovy > System.Math.PI) {
				throw new ArgumentOutOfRangeException("fovy");
			}
			if (aspect <= 0) {
				throw new ArgumentOutOfRangeException("aspect");
			}
			if (zNear <= 0) {
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0) {
				throw new ArgumentOutOfRangeException("zFar");
			}
			
			float yMax = zNear * (float)System.Math.Tan(0.5f * fovy);
			float yMin = -yMax;
			float xMin = yMin * aspect;
			float xMax = yMax * aspect;

			CreatePerspectiveOffCenter(xMin, xMax, yMin, yMax, zNear, zFar, out result);
		}
		
		/// <summary>
		/// Creates a perspective projection matrix.
		/// </summary>
		/// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
		/// <param name="aspect">Aspect ratio of the view (width / height)</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <returns>A projection matrix that transforms camera space to raster space</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Thrown under the following conditions:
		/// <list type="bullet">
		/// <item>fovy is zero, less than zero or larger than Math.PI</item>
		/// <item>aspect is negative or zero</item>
		/// <item>zNear is negative or zero</item>
		/// <item>zFar is negative or zero</item>
		/// <item>zNear is larger than zFar</item>
		/// </list>
		/// </exception>
		public static Matrix4x4 CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar) {
			Matrix4x4 result;
			CreatePerspectiveFieldOfView(fovy, aspect, zNear, zFar, out result);
			return result;
		}
		
		#endregion
		
		#region CreatePerspectiveOffCenter
		
		/// <summary>
		/// Creates an perspective projection matrix.
		/// </summary>
		/// <param name="left">Left edge of the view frustum</param>
		/// <param name="right">Right edge of the view frustum</param>
		/// <param name="bottom">Bottom edge of the view frustum</param>
		/// <param name="top">Top edge of the view frustum</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <param name="result">A projection matrix that transforms camera space to raster space</param>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Thrown under the following conditions:
		/// <list type="bullet">
		/// <item>zNear is negative or zero</item>
		/// <item>zFar is negative or zero</item>
		/// <item>zNear is larger than zFar</item>
		/// </list>
		/// </exception>
		public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4x4 result) {
			if (zNear <= 0) {
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0) {
				throw new ArgumentOutOfRangeException("zFar");
			}
			if (zNear >= zFar) {
				throw new ArgumentOutOfRangeException("zNear");
			}
			
			float x = (2.0f * zNear) / (right - left);
			float y = (2.0f * zNear) / (top - bottom);
			float a = (right + left) / (right - left);
			float b = (top + bottom) / (top - bottom);
			float c = -(zFar + zNear) / (zFar - zNear);
			float d = -(2.0f * zFar * zNear) / (zFar - zNear);

			result.M11 = x;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = y;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = a;
			result.M32 = b;
			result.M33 = c;
			result.M34 = -1;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = d;
			result.M44 = 0;
		}
		
		/// <summary>
		/// Creates an perspective projection matrix.
		/// </summary>
		/// <param name="left">Left edge of the view frustum</param>
		/// <param name="right">Right edge of the view frustum</param>
		/// <param name="bottom">Bottom edge of the view frustum</param>
		/// <param name="top">Top edge of the view frustum</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <returns>A projection matrix that transforms camera space to raster space</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Thrown under the following conditions:
		/// <list type="bullet">
		/// <item>zNear is negative or zero</item>
		/// <item>zFar is negative or zero</item>
		/// <item>zNear is larger than zFar</item>
		/// </list>
		/// </exception>
		public static Matrix4x4 CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar) {
			Matrix4x4 result;
			CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		#endregion

		#region Camera Helper Functions

		/// <summary>
		/// Build a world space to camera space matrix
		/// </summary>
		/// <param name="eye">Eye (camera) position in world space</param>
		/// <param name="target">Target position in world space</param>
		/// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <returns>A Matrix4 that transforms world space to camera space</returns>
		public static Matrix4x4 LookAt(Vector3 eye, Vector3 target, Vector3 up) {
			Vector3 z = Vector3.Normalize(eye - target);
			Vector3 x = Vector3.Normalize(Vector3.Cross(up, z));
			Vector3 y = Vector3.Normalize(Vector3.Cross(z, x));

			Matrix4x4 result;

			result.M11 = x.X;
			result.M12 = y.X;
			result.M13 = z.X;
			result.M14 = 0;
			result.M21 = x.Y;
			result.M22 = y.Y;
			result.M23 = z.Y;
			result.M24 = 0;
			result.M31 = x.Z;
			result.M32 = y.Z;
			result.M33 = z.Z;
			result.M34 = 0;
			result.M41 = -((x.X * eye.X) + (x.Y * eye.Y) + (x.Z * eye.Z));
			result.M42 = -((y.X * eye.X) + (y.Y * eye.Y) + (y.Z * eye.Z));
			result.M43 = -((z.X * eye.X) + (z.Y * eye.Y) + (z.Z * eye.Z));
			result.M44 = 1;

			return result;
		}

		/// <summary>
		/// Build a world space to camera space matrix
		/// </summary>
		/// <param name="eyeX">Eye (camera) position in world space</param>
		/// <param name="eyeY">Eye (camera) position in world space</param>
		/// <param name="eyeZ">Eye (camera) position in world space</param>
		/// <param name="targetX">Target position in world space</param>
		/// <param name="targetY">Target position in world space</param>
		/// <param name="targetZ">Target position in world space</param>
		/// <param name="upX">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <param name="upY">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <param name="upZ">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <returns>A Matrix4 that transforms world space to camera space</returns>
		public static Matrix4x4 LookAt(float eyeX, float eyeY, float eyeZ, float targetX, float targetY, float targetZ, float upX, float upY, float upZ) {
			return LookAt(new Vector3(eyeX, eyeY, eyeZ), new Vector3(targetX, targetY, targetZ), new Vector3(upX, upY, upZ));
		}

		#endregion

		#region Multiply Functions

		/// <summary>
		/// Multiplies two instances.
		/// </summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <returns>A new instance that is the result of the multiplication.</returns>
		public static Matrix4x4 Mult(Matrix4x4 left, Matrix4x4 right) {
			Matrix4x4 result;
			Mult(ref left, ref right, out result);
			return result;
		}

		/// <summary>
		/// Multiplies two instances.
		/// </summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <param name="result">A new instance that is the result of the multiplication.</param>
		public static void Mult(ref Matrix4x4 left, ref Matrix4x4 right, out Matrix4x4 result) {
			float lM11 = left.M11, lM12 = left.M12, lM13 = left.M13, lM14 = left.M14,
			lM21 = left.M21, lM22 = left.M22, lM23 = left.M23, lM24 = left.M24,
			lM31 = left.M31, lM32 = left.M32, lM33 = left.M33, lM34 = left.M34,
			lM41 = left.M41, lM42 = left.M42, lM43 = left.M43, lM44 = left.M44,
			rM11 = right.M11, rM12 = right.M12, rM13 = right.M13, rM14 = right.M14,
			rM21 = right.M21, rM22 = right.M22, rM23 = right.M23, rM24 = right.M24,
			rM31 = right.M31, rM32 = right.M32, rM33 = right.M33, rM34 = right.M34,
			rM41 = right.M41, rM42 = right.M42, rM43 = right.M43, rM44 = right.M44;

			result.M11 = (((lM11 * rM11) + (lM12 * rM21)) + (lM13 * rM31)) + (lM14 * rM41);
			result.M12 = (((lM11 * rM12) + (lM12 * rM22)) + (lM13 * rM32)) + (lM14 * rM42);
			result.M13 = (((lM11 * rM13) + (lM12 * rM23)) + (lM13 * rM33)) + (lM14 * rM43);
			result.M14 = (((lM11 * rM14) + (lM12 * rM24)) + (lM13 * rM34)) + (lM14 * rM44);
			result.M21 = (((lM21 * rM11) + (lM22 * rM21)) + (lM23 * rM31)) + (lM24 * rM41);
			result.M22 = (((lM21 * rM12) + (lM22 * rM22)) + (lM23 * rM32)) + (lM24 * rM42);
			result.M23 = (((lM21 * rM13) + (lM22 * rM23)) + (lM23 * rM33)) + (lM24 * rM43);
			result.M24 = (((lM21 * rM14) + (lM22 * rM24)) + (lM23 * rM34)) + (lM24 * rM44);
			result.M31 = (((lM31 * rM11) + (lM32 * rM21)) + (lM33 * rM31)) + (lM34 * rM41);
			result.M32 = (((lM31 * rM12) + (lM32 * rM22)) + (lM33 * rM32)) + (lM34 * rM42);
			result.M33 = (((lM31 * rM13) + (lM32 * rM23)) + (lM33 * rM33)) + (lM34 * rM43);
			result.M34 = (((lM31 * rM14) + (lM32 * rM24)) + (lM33 * rM34)) + (lM34 * rM44);
			result.M41 = (((lM41 * rM11) + (lM42 * rM21)) + (lM43 * rM31)) + (lM44 * rM41);
			result.M42 = (((lM41 * rM12) + (lM42 * rM22)) + (lM43 * rM32)) + (lM44 * rM42);
			result.M43 = (((lM41 * rM13) + (lM42 * rM23)) + (lM43 * rM33)) + (lM44 * rM43);
			result.M44 = (((lM41 * rM14) + (lM42 * rM24)) + (lM43 * rM34)) + (lM44 * rM44);
		}
		/// <summary>
		/// Mult the specified left and right where left is a Vector4 should only be used for debuging
		/// and seeing if the point you are tryng to draw is in screen space
		/// </summary>
		/// <param name='left'>
		/// Left.
		/// </param>
		/// <param name='right'>
		/// Right.
		/// </param>
		public static Vector4 Mult(Vector4 left,Matrix4x4 right)
		{
			return new Vector4(left.X*right.M11 + left.Y*right.M21+ left.Z*right.M31+ left.W*right.M41,
			                   left.X*right.M12 + left.Y*right.M22+ left.Z*right.M32+ left.W*right.M42,
			                   left.X*right.M13 + left.Y*right.M23+ left.Z*right.M33+ left.W*right.M43,
			                   left.X*right.M14 + left.Y*right.M24+ left.Z*right.M34+ left.W*right.M44);
		}
		public static Vector4 operator*(Vector4 left, Matrix4x4 right)
		{
			return Mult(left, right);
		}
		#endregion

		#region Invert Functions

		/// <summary>
		/// Calculate the inverse of the given matrix
		/// </summary>
		/// <param name="mat">The matrix to invert</param>
		/// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular</param>
		/// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
		public static void Invert(ref Matrix4x4 mat, out Matrix4x4 result) {
            float s0 = mat.M11 * mat.M22 - mat.M21 * mat.M12;
            float s1 = mat.M11 * mat.M23 - mat.M21 * mat.M13;
            float s2 = mat.M11 * mat.M24 - mat.M21 * mat.M14;
            float s3 = mat.M12 * mat.M23 - mat.M22 * mat.M13;
            float s4 = mat.M12 * mat.M24 - mat.M22 * mat.M14;
            float s5 = mat.M13 * mat.M24 - mat.M23 * mat.M14;

            float c5 = mat.M33 * mat.M44 - mat.M43 * mat.M34;
            float c4 = mat.M32 * mat.M44 - mat.M42 * mat.M34;
            float c3 = mat.M32 * mat.M43 - mat.M42 * mat.M33;
            float c2 = mat.M31 * mat.M44 - mat.M41 * mat.M34;
            float c1 = mat.M31 * mat.M43 - mat.M41 * mat.M33;
            float c0 = mat.M31 * mat.M42 - mat.M41 * mat.M32;

            float inverseDeterminant = 1.0f / (s0 * c5 - s1 * c4 + s2 * c3 + s3 * c2 - s4 * c1 + s5 * c0);

            float m11 = mat.M11;
            float m12 = mat.M12;
            float m13 = mat.M13;
            float m14 = mat.M14;
            float m21 = mat.M21;
            float m22 = mat.M22;
            float m23 = mat.M23;
            float m31 = mat.M31;
            float m32 = mat.M32;
            float m33 = mat.M33;

            float m41 = mat.M41;
            float m42 = mat.M42;

            result = new Matrix4x4();
            result.M11 = (mat.M22 * c5 - mat.M23 * c4 + mat.M24 * c3) * inverseDeterminant;
            result.M12 = (-mat.M12 * c5 + mat.M13 * c4 - mat.M14 * c3) * inverseDeterminant;
            result.M13 = (mat.M42 * s5 - mat.M43 * s4 + mat.M44 * s3) * inverseDeterminant;
            result.M14 = (-mat.M32 * s5 + mat.M33 * s4 - mat.M34 * s3) * inverseDeterminant;

            result.M21 = (-mat.M21 * c5 + mat.M23 * c2 - mat.M24 * c1) * inverseDeterminant;
            result.M22 = (m11 * c5 - m13 * c2 + m14 * c1) * inverseDeterminant;
            result.M23 = (-mat.M41 * s5 + mat.M43 * s2 - mat.M44 * s1) * inverseDeterminant;
            result.M24 = (mat.M31 * s5 - mat.M33 * s2 + mat.M34 * s1) * inverseDeterminant;

            result.M31 = (m21 * c4 - m22 * c2 + mat.M24 * c0) * inverseDeterminant;
            result.M32 = (-m11 * c4 + m12 * c2 - m14 * c0) * inverseDeterminant;
            result.M33 = (mat.M41 * s4 - mat.M42 * s2 + mat.M44 * s0) * inverseDeterminant;
            result.M34 = (-m31 * s4 + m32 * s2 - mat.M34 * s0) * inverseDeterminant;

            result.M41 = (-m21 * c3 + m22 * c1 - m23 * c0) * inverseDeterminant;
            result.M42 = (m11 * c3 - m12 * c1 + m13 * c0) * inverseDeterminant;
            result.M43 = (-m41 * s3 + m42 * s1 - mat.M43 * s0) * inverseDeterminant;
            result.M44 = (m31 * s3 - m32 * s1 + m33 * s0) * inverseDeterminant;
		}

		/// <summary>
		/// Calculate the inverse of the given matrix
		/// </summary>
		/// <param name="mat">The matrix to invert</param>
		/// <returns>The inverse of the given matrix if it has one, or the input if it is singular</returns>
		/// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
		public static Matrix4x4 Invert(Matrix4x4 mat) {
			Matrix4x4 result;
			Invert(ref mat, out result);
			return result;
		}

		#endregion

		#region Transpose

		/// <summary>
		/// Calculate the transpose of the given matrix
		/// </summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <returns>The transpose of the given matrix</returns>
		public static Matrix4x4 Transpose(Matrix4x4 mat) {
			return new Matrix4x4(
                mat.M11, mat.M21, mat.M31, mat.M41,
                mat.M12, mat.M22, mat.M32, mat.M42,
                mat.M13, mat.M23, mat.M33, mat.M43,
                mat.M14, mat.M24, mat.M34, mat.M44
                );
		}


		/// <summary>
		/// Calculate the transpose of the given matrix
		/// </summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <param name="result">The result of the calculation</param>
		public static void Transpose(ref Matrix4x4 mat, out Matrix4x4 result) {
            result.M11 = mat.M11;
            result.M12 = mat.M21;
            result.M13 = mat.M31;
            result.M14 = mat.M41;
            result.M21 = mat.M12;
            result.M22 = mat.M22;
            result.M23 = mat.M32;
            result.M24 = mat.M42;
            result.M31 = mat.M13;
            result.M32 = mat.M23;
            result.M33 = mat.M33;
            result.M34 = mat.M43;
            result.M41 = mat.M14;
            result.M42 = mat.M24;
            result.M43 = mat.M34;
            result.M44 = mat.M44;
        }

		#endregion

		#endregion

		#region Operators

		/// <summary>
		/// Matrix multiplication
		/// </summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix4 which holds the result of the multiplication</returns>
		public static Matrix4x4 operator *(Matrix4x4 left, Matrix4x4 right) {
			return Matrix4x4.Mult(left, right);
		}

		/// <summary>
		/// Compares two instances for equality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left equals right; false otherwise.</returns>
		public static bool operator ==(Matrix4x4 left, Matrix4x4 right) {
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two instances for inequality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left does not equal right; false otherwise.</returns>
		public static bool operator !=(Matrix4x4 left, Matrix4x4 right) {
			return !left.Equals(right);
		}

		#endregion

		#region Overrides

		#region public override string ToString()

		/// <summary>
		/// Returns a System.String that represents the current Matrix4.
		/// </summary>
		/// <returns>The string representation of the matrix.</returns>
		public override string ToString() {
			return String.Format($@"[
                {M11} {M12} {M13} {M14};
                {M21} {M22} {M23} {M24};
                {M31} {M32} {M33} {M34};
                {M41} {M42} {M43} {M44};
            ]");
		}

		#endregion

		#region public override int GetHashCode()

		/// <summary>
		/// Returns the hashcode for this instance.
		/// </summary>
		/// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
		public override int GetHashCode() {
            int hash = 0;
            hash ^= M11.GetHashCode();
            hash ^= M12.GetHashCode();
            hash ^= M13.GetHashCode();
            hash ^= M14.GetHashCode();
            hash ^= M21.GetHashCode();
            hash ^= M22.GetHashCode();
            hash ^= M23.GetHashCode();
            hash ^= M24.GetHashCode();
            hash ^= M31.GetHashCode();
            hash ^= M32.GetHashCode();
            hash ^= M33.GetHashCode();
            hash ^= M34.GetHashCode();
            hash ^= M41.GetHashCode();
            hash ^= M42.GetHashCode();
            hash ^= M43.GetHashCode();
            hash ^= M44.GetHashCode();
            return hash;
		}

		#endregion

		#region public override bool Equals(object obj)

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">The object to compare tresult.</param>
		/// <returns>True if the instances are equal; false otherwise.</returns>
		public override bool Equals(object obj) {
            if (obj is Matrix4x4) {
			    return this.Equals((Matrix4x4)obj);
            } else {
				return false;
			}

		}

		#endregion

		#endregion

		#endregion

		#region IEquatable<Matrix4> Members

		/// <summary>Indicates whether the current matrix is equal to another matrix.</summary>
		/// <param name="other">An matrix to compare with this matrix.</param>
		/// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
		public bool Equals(Matrix4x4 other) {
            return
                M11 == other.M11 &&
                M12 == other.M12 &&
                M13 == other.M13 &&
                M14 == other.M14 &&
                M21 == other.M21 &&
                M22 == other.M22 &&
                M23 == other.M23 &&
                M24 == other.M24 &&
                M31 == other.M31 &&
                M32 == other.M32 &&
                M33 == other.M33 &&
                M34 == other.M34 &&
                M41 == other.M41 &&
                M42 == other.M42 &&
                M43 == other.M43 &&
                M44 == other.M44;
        }

		#endregion
	}
}
