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
using System.Security;

namespace Pencil.Gaming.Audio {
    [SuppressUnmanagedCodeSecurity]
	internal static class AL_Native {
		private const string lib = "openal32";

        [DllImport(lib)]
        internal static extern bool alcCloseDevice(IntPtr device);
        [DllImport(lib)]
        internal static extern IntPtr alcOpenDevice([MarshalAs(UnmanagedType.LPStr)] string devicename);
        [DllImport(lib)]
        internal static extern bool alcIsExtensionPresent(IntPtr device, [MarshalAs(UnmanagedType.LPStr)] string extname);
        [DllImport(lib)]
        internal static extern void alcGetIntegerv(IntPtr device, int param, int size, [MarshalAs(UnmanagedType.LPArray)] int[] data);
        [DllImport(lib)]
        internal static extern IntPtr alcCreateContext(IntPtr device, [MarshalAs(UnmanagedType.LPArray)] int[] attrlist);
        [DllImport(lib)]
        internal static extern bool alcMakeContextCurrent(IntPtr context);

        [DllImport(lib)]
		internal static extern void alEnable(int capability);
		[DllImport(lib)]
		internal static extern void alDisable(int capability); 
		[DllImport(lib)]
		internal static extern bool alIsEnabled(int capability); 
		[DllImport(lib)]
		internal static extern IntPtr alGetString(int param);
		[DllImport(lib)]
		internal static extern void alGetBooleanv(int param, [MarshalAs(UnmanagedType.LPArray)] bool[] data);
		[DllImport(lib)]
		internal static extern void alGetIntegerv(int param, [MarshalAs(UnmanagedType.LPArray)] int[] data);
		[DllImport(lib)]
		internal static extern void alGetFloatv(int param, [MarshalAs(UnmanagedType.LPArray)] float[] data);
		[DllImport(lib)]
		internal static extern void alGetDoublev(int param, [MarshalAs(UnmanagedType.LPArray)] double[] data);
		[DllImport(lib)]
		internal static extern bool alGetBoolean(int param);
		[DllImport(lib)]
		internal static extern int alGetInteger(int param);
		[DllImport(lib)]
		internal static extern float alGetFloat(int param);
		[DllImport(lib)]
		internal static extern double alGetDouble(int param);
		[DllImport(lib)]
		internal static extern int alGetError();
		[DllImport(lib)]
		internal static extern bool alIsExtensionPresent([MarshalAs(UnmanagedType.LPStr)] string extname);
		[DllImport(lib)]
		internal static extern IntPtr alGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string fname);
		[DllImport(lib)]
		internal static extern int alGetEnumValue([MarshalAs(UnmanagedType.LPStr)] string ename);
		[DllImport(lib)]
		internal static extern void alListenerf(int param, float value);
		[DllImport(lib)]
		internal static extern void alListener3f(int param, float value1, float value2, float value3);
		[DllImport(lib)]
		internal static extern void alListenerfv(int param, [MarshalAs(UnmanagedType.LPArray)] float[] values); 
		[DllImport(lib)]
		internal static extern void alListeneri(int param, int value);
		[DllImport(lib)]
		internal static extern void alListener3i(int param, int value1, int value2, int value3);
		[DllImport(lib)]
		internal static extern void alListeneriv(int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alGetListenerf(int param, out float value);
		[DllImport(lib)]
		internal static extern void alGetListener3f(int param, out float value1, out float value2, out float value3);
		[DllImport(lib)]
		internal static extern void alGetListenerfv(int param, [MarshalAs(UnmanagedType.LPArray)] float[] values);
		[DllImport(lib)]
		internal static extern void alGetListeneri(int param, out int value);
		[DllImport(lib)]
		internal static extern void alGetListener3i(int param, out int value1, out int value2, out int value3);
		[DllImport(lib)]
		internal static extern void alGetListeneriv(int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alGenSources(int n, [MarshalAs(UnmanagedType.LPArray)] uint[] sources); 
		[DllImport(lib, EntryPoint = "alGenSources")]
		internal static extern void alGenSource(int n, out uint source); 
		[DllImport(lib)]
		internal static extern void alDeleteSources(int n, [MarshalAs(UnmanagedType.LPArray)] uint[] sources);
		[DllImport(lib, EntryPoint = "alDeleteSources")]
		internal static extern void alDeleteSource(int n, ref uint sources);
		[DllImport(lib)]
		internal static extern bool alIsSource(uint sid); 
		[DllImport(lib)]
		internal static extern void alSourcef(uint sid, int param, float value); 
		[DllImport(lib)]
		internal static extern void alSource3f(uint sid, int param, float value1, float value2, float value3);
		[DllImport(lib)]
		internal static extern void alSourcefv(uint sid, int param, [MarshalAs(UnmanagedType.LPArray)] float[] values); 
		[DllImport(lib)]
		internal static extern void alSourcei(uint sid, int param, int value); 
		[DllImport(lib)]
		internal static extern void alSource3i(uint sid, int param, int value1, int value2, int value3);
		[DllImport(lib)]
		internal static extern void alSourceiv(uint sid, int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alGetSourcef(uint sid, int param, out float value);
		[DllImport(lib)]
		internal static extern void alGetSource3f(uint sid, int param, out float value1, out float value2, out float value3);
		[DllImport(lib)]
		internal static extern void alGetSourcefv(uint sid, int param, [MarshalAs(UnmanagedType.LPArray)] float[] values);
		[DllImport(lib)]
		internal static extern void alGetSourcei(uint sid, int param, out int value);
		[DllImport(lib)]
		internal static extern void alGetSource3i(uint sid, int param, out int value1, out int value2, out int value3);
		[DllImport(lib)]
		internal static extern void alGetSourceiv(uint sid, int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alSourcePlayv(int ns, [MarshalAs(UnmanagedType.LPArray)] uint[]sids);
		[DllImport(lib)]
		internal static extern void alSourceStopv(int ns, [MarshalAs(UnmanagedType.LPArray)] uint[]sids);
		[DllImport(lib)]
		internal static extern void alSourceRewindv(int ns, [MarshalAs(UnmanagedType.LPArray)] uint[]sids);
		[DllImport(lib)]
		internal static extern void alSourcePausev(int ns, [MarshalAs(UnmanagedType.LPArray)] uint[]sids);
		[DllImport(lib)]
		internal static extern void alSourcePlay(uint sid);
		[DllImport(lib)]
		internal static extern void alSourceStop(uint sid);
		[DllImport(lib)]
		internal static extern void alSourceRewind(uint sid);
		[DllImport(lib)]
		internal static extern void alSourcePause(uint sid);
		[DllImport(lib)]
		internal static extern void alSourceQueueBuffers(uint sid, int numEntries, [MarshalAs(UnmanagedType.LPArray)] uint[]bids);
		[DllImport(lib)]
		internal static extern void alSourceUnqueueBuffers(uint sid, int numEntries, [MarshalAs(UnmanagedType.LPArray)] uint[]bids);
		[DllImport(lib)]
		internal static extern void alGenBuffers(int n, [MarshalAs(UnmanagedType.LPArray)] uint[] buffers);
		[DllImport(lib, EntryPoint = "alGenBuffers")]
		internal static extern void alGenBuffer(int n, out uint buffer);
		[DllImport(lib)]
		internal static extern void alDeleteBuffers(int n, [MarshalAs(UnmanagedType.LPArray)] uint[] buffers);
		[DllImport(lib, EntryPoint = "alDeleteBuffers")]
		internal static extern void alDeleteBuffer(int n, ref uint buffer);
		[DllImport(lib)]
		internal static extern bool alIsBuffer(uint bid);
		[DllImport(lib)]
		internal static extern void alBufferData(uint bid, int format, IntPtr data, int size, int freq);
		[DllImport(lib)]
		internal static extern void alBufferf(uint bid, int param, float value);
		[DllImport(lib)]
		internal static extern void alBuffer3f(uint bid, int param, float value1, float value2, float value3);
		[DllImport(lib)]
		internal static extern void alBufferfv(uint bid, int param, [MarshalAs(UnmanagedType.LPArray)] float[] values);
		[DllImport(lib)]
		internal static extern void alBufferi(uint bid, int param, int value);
		[DllImport(lib)]
		internal static extern void alBuffer3i(uint bid, int param, int value1, int value2, int value3);
		[DllImport(lib)]
		internal static extern void alBufferiv(uint bid, int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alGetBufferf(uint bid, int param, out float value);
		[DllImport(lib)]
		internal static extern void alGetBuffer3f(uint bid, int param, out float value1, out float value2, out float value3);
		[DllImport(lib)]
		internal static extern void alGetBufferfv(uint bid, int param, [MarshalAs(UnmanagedType.LPArray)] float[] values);
		[DllImport(lib)]
		internal static extern void alGetBufferi(uint bid, int param, out int value);
		[DllImport(lib)]
		internal static extern void alGetBuffer3i(uint bid, int param, out int value1, out int value2, out int value3);
		[DllImport(lib)]
		internal static extern void alGetBufferiv(uint bid, int param, [MarshalAs(UnmanagedType.LPArray)] int[] values);
		[DllImport(lib)]
		internal static extern void alDopplerFactor(float value);
		[DllImport(lib)]
		internal static extern void alDopplerVelocity(float value);
		[DllImport(lib)]
		internal static extern void alSpeedOfSound(float value);
		[DllImport(lib)]
		internal static extern void alDistanceModel(int distanceModel);
	}
}

