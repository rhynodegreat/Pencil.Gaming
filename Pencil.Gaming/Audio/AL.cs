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

using static Pencil.Gaming.Audio.AL_Native;

namespace Pencil.Gaming.Audio {
	public static partial class AL {
        private static IntPtr alcDeviceHandle;
        private static IntPtr alcContextHandle;

        public static void Init() {
            alcDeviceHandle = alcOpenDevice(null);
            if (alcDeviceHandle == IntPtr.Zero) {
                // TODO: Named devices
                throw new Exception("Could not find audio device.");
            }

            alcContextHandle = alcCreateContext(alcDeviceHandle, null);

            if (alcContextHandle == IntPtr.Zero) {
                alcCloseDevice(alcDeviceHandle);
                throw new Exception("Failed to create ALC context.");
            }

            alcMakeContextCurrent(alcContextHandle);
        }

        public static void Terminate() {
            alcCloseDevice(alcDeviceHandle);
        }

		public static void Enable(ALCapability capability) {
			alEnable((int)capability);
		}
		public static void Disable(ALCapability capability) {
			alDisable((int)capability);
		} 
		public static bool IsEnabled(ALCapability capability) {
			return alIsEnabled((int)capability);
		} 
		public static string GetString(ALGetString param) {
			return Marshal.PtrToStringAnsi(alGetString((int)param));
		}
		public static void GetBoolean(ALGetInteger param, bool[] data) {
			alGetBooleanv((int)param, data);
		}
		public static void GetInteger(ALGetInteger param, int[] data) {
			alGetIntegerv((int)param, data);
		}
		public static void GetFloat(ALGetFloat param, float[] data) {
			alGetFloatv((int)param, data);
		}
//		public static void GetDouble(int param, double[] data) {
//			AL64.alGetDoublev(param, data);
//		}
		public static bool GetBoolean(ALGetInteger param) {
			return alGetBoolean((int)param);
		}
		public static int GetInteger(ALGetInteger param) {
			return alGetInteger((int)param);
		}
		public static float GetFloat(ALGetFloat param) {
			return alGetFloat((int)param);
		}
		public static double GetDouble(int param) {
			return alGetDouble(param);
		}
		public static int GetError() {
			return alGetError();
		}
		public static bool IsExtensionPresent(string extname) {
			return alIsExtensionPresent(extname);
		}
		public static IntPtr GetProcAddress(string fname) {
			return alGetProcAddress(fname);
		}
		public static int GetEnumValue(string ename) {
			return alGetEnumValue(ename);
		}
		public static void Listener(ALListenerf param, float value) {
			alListenerf((int)param, value);
		}
		public static void Listener(ALListener3f param, float value1, float value2, float value3) {
			alListener3f((int)param, value1, value2, value3);
		}
		public static void Listener(ALListenerfv param, float[] values) {
			alListenerfv((int)param, values);
		} 
//		public static void Listener(int param, int value) {
//			AL64.alListeneri(param, value);
//		}
//		public static void Listener(int param, int value1, int value2, int value3) {
//			AL64.alListener3i(param, value1, value2, value3);
//		}
//		public static void Listener(int param, int[] values) {
//			AL64.alListeneriv(param, values);
//		}
		public static void GetListener(ALListenerf param, out float value) {
			alGetListenerf((int)param, out value);
		}
		public static void GetListener(ALListener3f param, out float value1, out float value2, out float value3) {
			alGetListener3f((int)param, out value1, out value2, out value3);
		}
		public static void GetListener(ALListenerfv param, float[] values) {
			alGetListenerfv((int)param, values);
		}
//		public static void GetListener(int param, out int value) {
//			AL64.alGetListeneri(param, out value);
//		}
//		public static void GetListener(int param, out int value1, out int value2, out int value3) {
//			AL64.alGetListener3i(param, out value1, out value2, out value3);
//		}
//		public static void GetListener(int param, int[] values) {
//			AL64.alGetListeneriv(param, values);
//		}
		public static void GenSources(int n, uint[] sources) {
			alGenSources(n, sources);
		} 
		public static void GenSources(int n, out uint source) {
			alGenSource(n, out source);
		}
		public static void DeleteSources(int n, uint[] sources) {
			alDeleteSources(n, sources);
		}
		public static void DeleteSources(int n, ref uint source) {
			alDeleteSource(n, ref source);
		}
		public static bool IsSource(uint sid) {
			return alIsSource(sid);
		} 
		public static void Source(uint sid, ALSourcef param, float value) {
			alSourcef(sid, (int)param, value);
		} 
		public static void Source(uint sid, ALSource3f param, float value1, float value2, float value3) {
			alSource3f(sid, (int)param, value1, value2, value3);
		}
//		public static void Source(uint sid, int param, float[] values) {
//			AL64.alSourcefv(sid, param, values);
//		} 
		public static void Source(uint sid, ALSourcei param, int value) {
			alSourcei(sid, (int)param, value);
		} 
		public static void Source(uint sid, ALSource3i param, int value1, int value2, int value3) {
			alSource3i(sid, (int)param, value1, value2, value3);
		}
		public static void Source(uint sid, ALSourceb param, bool value) {
			alSourcei(sid, (int)param, value ? 1 : 0);
		}
//		public static void Source(uint sid, int param, int[] values) {
//			AL64.alSourceiv(sid, param, values);
//		}
		public static void GetSource(uint sid, ALSourcef param, out float value) {
			alGetSourcef(sid, (int)param, out value);
		}
		public static void GetSource(uint sid, ALSource3f param, out float value1, out float value2, out float value3) {
			alGetSource3f(sid, (int)param, out value1, out value2, out value3);
		}
//		public static void GetSource(uint sid, int param, float[] values) {
//			AL64.alGetSourcefv(sid, param, values);
//		}
		public static void GetSource(uint sid, ALSourcei param, out int value) {
			alGetSourcei(sid, (int)param, out value);
		}
		public static void GetSource(uint sid, ALSource3i param, out int value1, out int value2, out int value3) {
			alGetSource3i(sid, (int)param, out value1, out value2, out value3);
		}
		public static void GetSource(uint sid, ALSourceb param, out bool value) {
			int ivalue;
			alGetSourcei(sid, (int)param, out ivalue);
			value = (ivalue != 0);
		}
//		public static void GetSource(uint sid, int param, int[] values) {
//			AL64.alGetSourceiv(sid, param, values);
//		}
		public static void SourcePlay(int ns, uint[]sids) {
			alSourcePlayv(ns, sids);
		}
		public static void SourceStop(int ns, uint[]sids) {
			alSourceStopv(ns, sids);
		}
		public static void SourceRewind(int ns, uint[]sids) {
			alSourceRewindv(ns, sids);
		}
		public static void SourcePause(int ns, uint[]sids) {
			alSourcePausev(ns, sids);
		}
		public static void SourcePlay(uint sid) {
			alSourcePlay(sid);
		}
		public static void SourceStop(uint sid) {
			alSourceStop(sid);
		}
		public static void SourceRewind(uint sid) {
			alSourceRewind(sid);
		}
		public static void SourcePause(uint sid) {
			alSourcePause(sid);
		}
		public static void SourceQueueBuffers(uint sid, int numEntries, uint[]bids) {
			alSourceQueueBuffers(sid, numEntries, bids);
		}
		public static void SourceUnqueueBuffers(uint sid, int numEntries, uint[]bids) {
			alSourceUnqueueBuffers(sid, numEntries, bids);
		}
		public static void GenBuffers(int n, uint[] buffers) {
			alGenBuffers(n, buffers);
		}
		public static void GenBuffers(int n, out uint buffer) {
			alGenBuffer(n, out buffer);
		}
		public static void DeleteBuffers(int n, uint[] buffers) {
			alDeleteBuffers(n, buffers);
		}
		public static void DeleteBuffers(int n, ref uint buffer) {
			alDeleteBuffer(n, ref buffer);
		}
		public static bool IsBuffer(uint bid) {
			return alIsBuffer(bid);
		}
		public static void BufferData(uint bid, ALFormat format, IntPtr data, int size, int freq) {
			alBufferData(bid, (int)format, data, size, freq);
		}
//		public static void Buffer(uint bid, int param, float value) {
//			AL64.alBufferf(bid, param, value);
//		}
//		public static void Buffer(uint bid, int param, float value1, float value2, float value3) {
//			AL64.alBuffer3f(bid, param, value1, value2, value3);
//		}
//		public static void Buffer(uint bid, int param, float[] values) {
//			AL64.alBufferfv(bid, param, values);
//		}
//		public static void Buffer(uint bid, int param, int value) {
//			AL64.alBufferi(bid, param, value);
//		}
//		public static void Buffer(uint bid, int param, int value1, int value2, int value3) {
//			AL64.alBuffer3i(bid, param, value1, value2, value3);
//		}
//		public static void Buffer(uint bid, int param, int[] values) {
//			AL64.alBufferiv(bid, param, values);
//		}
//		public static void GetBuffer(uint bid, int param, out float value) {
//			AL64.alGetBufferf(bid, param, out value);
//		}
//		public static void GetBuffer(uint bid, int param, out float value1, out float value2, out float value3) {
//			AL64.alGetBuffer3f(bid, param, out value1, out value2, out value3);
//		}
//		public static void GetBuffer(uint bid, int param, float[] values) {
//			AL64.alGetBufferfv(bid, param, values);
//		}
		public static void GetBuffer(uint bid, ALGetBufferi param, out int value) {
			alGetBufferi(bid, (int)param, out value);
		}
//		public static void GetBuffer(uint bid, int param, out int value1, out int value2, out int value3) {
//			AL64.alGetBuffer3i(bid, param, out value1, out value2, out value3);
//		}
//		public static void GetBuffer(uint bid, int param, int[] values) {
//			AL64.alGetBufferiv(bid, param, values);
//		}
		public static void DopplerFactor(float value) {
			alDopplerFactor(value);
		}
		public static void DopplerVelocity(float value) {
			alDopplerVelocity(value);
		}
		public static void SpeedOfSound(float value) {
			alSpeedOfSound(value);
		}
		public static void DistanceModel(int distanceModel) {
			alDistanceModel(distanceModel);
		}
	}
}