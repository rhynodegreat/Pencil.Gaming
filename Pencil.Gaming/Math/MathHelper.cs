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
using System.Collections.Generic;
using System.Text;

namespace Pencil.Gaming.Math {
	/// <summary>
	/// Contains common mathematical functions and constants.
	/// </summary>
	public static class MathHelper {
		/// <summary>
		/// Defines the value of tau divided by two as a <see cref="System.Single"/>.
		/// </summary>
		public const float Pi = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930382f;

		/// <summary>
		/// Defines the value of tau as a <see cref="System.Single"/>.
		/// </summary>
		public const float Tau = 2 * Pi;

		/// <summary>
		/// Defines the value of E as a <see cref="System.Single"/>.
		/// </summary>
		public const float E = 2.71828182845904523536f;

		/// <summary>
		/// Defines the base-10 logarithm of E.
		/// </summary>
		public const float Log10E = 0.434294482f;

		/// <summary>
		/// Defines the base-2 logarithm of E.
		/// </summary>
		public const float Log2E = 1.442695041f;


		/// <summary>
		/// Returns the next power of two that is larger than the specified number.
		/// </summary>
		/// <param name="n">The specified number.</param>
		/// <returns>The next power of two.</returns>
		public static long NextPowerOfTwo(long n) {
			if (n < 0) {
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (long)System.Math.Pow(2, System.Math.Ceiling(System.Math.Log((double)n, 2)));
		}

		/// <summary>
		/// Returns the next power of two that is larger than the specified number.
		/// </summary>
		/// <param name="n">The specified number.</param>
		/// <returns>The next power of two.</returns>
		public static int NextPowerOfTwo(int n) {
			if (n < 0) {
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (int)System.Math.Pow(2, System.Math.Ceiling(System.Math.Log((double)n, 2)));
		}

		/// <summary>
		/// Returns the next power of two that is larger than the specified number.
		/// </summary>
		/// <param name="n">The specified number.</param>
		/// <returns>The next power of two.</returns>
		public static float NextPowerOfTwo(float n) {
			if (n < 0) {
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return (float)System.Math.Pow(2, System.Math.Ceiling(System.Math.Log((double)n, 2)));
		}

		/// <summary>
		/// Returns the next power of two that is larger than the specified number.
		/// </summary>
		/// <param name="n">The specified number.</param>
		/// <returns>The next power of two.</returns>
		public static double NextPowerOfTwo(double n) {
			if (n < 0) {
				throw new ArgumentOutOfRangeException("n", "Must be positive.");
			}
			return System.Math.Pow(2, System.Math.Ceiling(System.Math.Log((double)n, 2)));
		}

		/// <summary>Calculates the factorial of a given natural number.
		/// </summary>
		/// <param name="n">The number.</param>
		/// <returns>n!</returns>
		public static long Factorial(int n) {
			long result = 1;

			for (; n > 1; n--) {
				result *= n;
			}

			return result;
		}

		/// <summary>
		/// Calculates the binomial coefficient <paramref name="n"/> above <paramref name="k"/>.
		/// </summary>
		/// <param name="n">The n.</param>
		/// <param name="k">The k.</param>
		/// <returns>n! / (k! * (n - k)!)</returns>
		public static long BinomialCoefficient(int n, int k) {
			return Factorial(n) / (Factorial(k) * Factorial(n - k));
		}

		/// <summary>
		/// Convert degrees to radians
		/// </summary>
		/// <param name="degrees">An angle in degrees</param>
		/// <returns>The angle expressed in radians</returns>
		public static float ToRadians(float degrees) {
			const float degToRad = (float)Tau / 360.0f;
			return degrees * degToRad;
		}

		/// <summary>
		/// Convert radians to degrees
		/// </summary>
		/// <param name="radians">An angle in radians</param>
		/// <returns>The angle expressed in degrees</returns>
		public static float ToDegrees(float radians) {
			const float radToDeg = 360.0f / (float)Tau;
			return radians * radToDeg;
		}

		/// <summary>
		/// Convert degrees to radians
		/// </summary>
		/// <param name="degrees">An angle in degrees</param>
		/// <returns>The angle expressed in radians</returns>
		public static double ToRadians(double degrees) {
			const double degToRad = System.Math.PI / 180.0;
			return degrees * degToRad;
		}

		/// <summary>
		/// Convert radians to degrees
		/// </summary>
		/// <param name="radians">An angle in radians</param>
		/// <returns>The angle expressed in degrees</returns>
		public static double ToDegrees(double radians) {
			const double radToDeg = 180.0 / System.Math.PI;
			return radians * radToDeg;
		}
	}
}
