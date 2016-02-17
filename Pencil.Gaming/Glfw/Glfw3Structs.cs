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

namespace Pencil.Gaming.GLFW {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct VideoMode {
		public int
			Width;
		public int
			Height;
		public int
			RedBits;
		public int
			BlueBits;
		public int
			GreenBits;
		public int
			RefreshRate;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct GammaRampInternal {
        public IntPtr Red, Blue, Green;
		public uint Length;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GammaRamp {
		[MarshalAs(UnmanagedType.LPArray)]
		public short[] Red;
		[MarshalAs(UnmanagedType.LPArray)]
		public short[] Green;
		[MarshalAs(UnmanagedType.LPArray)]
		public short[] Blue;
		internal uint Length;

        internal GammaRamp(uint length) {
            Red = new short[length];
            Green = new short[length];
            Blue = new short[length];
            Length = length;
        }
	}

	#pragma warning disable 0414

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MonitorPtr {
		private MonitorPtr(IntPtr ptr) {
			inner_ptr = ptr;
		}
        
		private IntPtr
			inner_ptr;

		public readonly static MonitorPtr Null = new MonitorPtr(IntPtr.Zero);
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct WindowPtr {
		private WindowPtr(IntPtr ptr) {
			inner_ptr = ptr;
		}

		private IntPtr
			inner_ptr;

		public readonly static WindowPtr Null = new WindowPtr(IntPtr.Zero);

        public static bool operator == (WindowPtr a, WindowPtr b) {
            return a.inner_ptr == b.inner_ptr;
        }

        public static bool operator !=(WindowPtr a, WindowPtr b) {
            return a.inner_ptr != b.inner_ptr;
        }

        public override int GetHashCode() {
            return inner_ptr.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj is WindowPtr) {
                WindowPtr other = (WindowPtr)obj;
                return this == other;
            }
            return false;
        }
    }

	#pragma warning restore 0414
}

