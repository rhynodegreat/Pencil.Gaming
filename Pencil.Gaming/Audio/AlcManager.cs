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
using System.Diagnostics;
using System.Collections.Generic;

namespace Pencil.Gaming.Audio {
	internal sealed class AlcManager {
		private static IntPtr alcDeviceHandle;
		private static IntPtr alcContextHandle;

		private delegate bool CloseDevice(IntPtr hndl);
		private delegate IntPtr OpenDevice(string str);
		private delegate bool IsExtensionPresent(IntPtr hndl,string extnsn);
		private delegate void GetIntegerv(IntPtr hndl,int @int,int count,int[] @out);
		private delegate IntPtr CreateContext(IntPtr hndl,int[] attribs);
		private delegate bool MakeContextCurrent(IntPtr hndl);

		public AlcManager() {
			alcDeviceHandle = Alc64.alcOpenDevice(null);
			if (alcDeviceHandle == IntPtr.Zero) {
				// TODO: Named devices
				throw new Exception("Could not find audio device.");
			}

			List<int> attributes = new List<int> { 4105, 0, };
			if (Alc64.alcIsExtensionPresent(alcDeviceHandle, "ALC_EXT_EFX")) {
				int[] alcInteger = new int[1];
                Alc64.alcGetIntegerv(alcDeviceHandle, 131065, 1, alcInteger);
				attributes.Add(131065);
				attributes.Add(alcInteger[0]);
			}
			attributes.Add(0);

			alcContextHandle = Alc64.alcCreateContext(alcDeviceHandle, attributes.ToArray());

			if (alcContextHandle == IntPtr.Zero) {
                Alc64.alcCloseDevice(alcDeviceHandle);
				throw new Exception("Failed to create ALC context.");
			}

            Alc64.alcMakeContextCurrent(alcContextHandle);

#if DEBUG
			sw.Stop();
			Console.WriteLine("Initializing ALC took {0} milliseconds.", sw.ElapsedMilliseconds);
#endif
		}

		public void Close() {
			Alc64.alcCloseDevice(alcDeviceHandle);
		}
	}
}

