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

using Pencil.Gaming.Input;

using static Pencil.Gaming.GLFW.Glfw_Native;

namespace Pencil.Gaming.GLFW {
	public static partial class Glfw {
		private static GlfwErrorFun errorCallback;

		public static bool Init() {
			return glfwInit() == 1;
		}
		public static void Terminate() {
			glfwTerminate();
		}
		public static void GetVersion(out int major, out int minor, out int rev) {
			glfwGetVersion(out major, out minor, out rev);
		}
		public static string GetVersionString() {
			return Marshal.PtrToStringAnsi(glfwGetVersionString());
		}
		public static GlfwErrorFun SetErrorCallback(GlfwErrorFun cbfun) {
			errorCallback = cbfun;
			return glfwSetErrorCallback(cbfun);
		}
		public static MonitorPtr[] GetMonitors() {
			int count;
			IntPtr ptr = glfwGetMonitors(out count);
			MonitorPtr[] result = new MonitorPtr[count];
			for (int i = 0; i < count; ++i) {
                int offset = i * Marshal.SizeOf<MonitorPtr>();
				result[i] = Marshal.PtrToStructure<MonitorPtr>(ptr + offset);
			}
			return result;
		}
		public static MonitorPtr GetPrimaryMonitor() {
			return glfwGetPrimaryMonitor();
		}
		public static void GetMonitorPos(MonitorPtr monitor, out int xpos, out int ypos) {
			glfwGetMonitorPos(monitor, out xpos, out ypos);
		}
		public static void GetMonitorPhysicalSize(MonitorPtr monitor, out int width, out int height) {
			glfwGetMonitorPhysicalSize(monitor, out width, out height);
		}
		public static string GetMonitorName(MonitorPtr monitor) {
			return Marshal.PtrToStringAnsi(glfwGetMonitorName(monitor));
		}
		public static VideoMode[] GetVideoModes(MonitorPtr monitor) {
			int count;
			IntPtr ptr = glfwGetVideoModes(monitor, out count);
			VideoMode[] result = new VideoMode[count];
			for (int i = 0; i < count; ++i) {
                int offset = i * Marshal.SizeOf<VideoMode>();
				result[i] = Marshal.PtrToStructure<VideoMode>(ptr + offset);
			}
			return result;
		}
		public static VideoMode GetVideoMode(MonitorPtr monitor) {
            IntPtr ptr = glfwGetVideoMode(monitor);
            VideoMode returnMode = Marshal.PtrToStructure<VideoMode>(ptr);
            return returnMode;
		}
		public static void SetGamma(MonitorPtr monitor, float gamma) {
			glfwSetGamma(monitor, gamma);
		}
		public static GammaRamp GetGammaRamp(MonitorPtr monitor) {
			GammaRampInternal rampI;
			glfwGetGammaRamp(monitor, out rampI);
			uint length = rampI.Length;
			GammaRamp ramp = new GammaRamp(length);
			for (int i = 0; i < ramp.Red.Length; ++i) {
                int offset = i * sizeof(ushort);
                ramp.Red[i] = Marshal.PtrToStructure<short>(rampI.Red + offset);
				ramp.Green[i] = Marshal.PtrToStructure<short>(rampI.Green + offset);
                ramp.Blue[i] = Marshal.PtrToStructure<short>(rampI.Blue + offset);
            }
            return ramp;
		}
		public static void SetGammaRamp(MonitorPtr monitor, ref GammaRamp ramp) {
			ramp.Length = (uint)ramp.Red.Length;
			glfwSetGammaRamp(monitor, ref ramp);
		}
		public static void DefaultWindowHints() {
			glfwDefaultWindowHints();
		}
		public static void WindowHint(WindowHint target, int hint) {
			glfwWindowHint(target, hint);
		}
		public static WindowPtr CreateWindow(int width, int height, string title, MonitorPtr monitor, WindowPtr share) {
			return glfwCreateWindow(width, height, title, monitor, share);
		}
		public static void DestroyWindow(WindowPtr window) {
			glfwDestroyWindow(window);
		}
		public static void GetFramebufferSize(WindowPtr window, out int width, out int height) {
			glfwGetFramebufferSize(window, out width, out height);
		}
		public static bool WindowShouldClose(WindowPtr window) {
			return glfwWindowShouldClose(window) == 1;
		}
		public static void SetWindowShouldClose(WindowPtr window, bool value) {
			glfwSetWindowShouldClose(window, value ? 1 : 0);
		}
		public static void SetWindowTitle(WindowPtr window, string title) {
			glfwSetWindowTitle(window, title);
		}
		public static void GetWindowPos(WindowPtr window, out int xpos, out int ypos) {
			glfwGetWindowPos(window, out xpos, out ypos);
		}
		public static void SetWindowPos(WindowPtr window, int xpos, int ypos) {
			glfwSetWindowPos(window, xpos, ypos);
		}
		public static void GetWindowSize(WindowPtr window, out int width, out int height) {
			glfwGetWindowSize(window, out width, out height);
		}
		public static void SetWindowSize(WindowPtr window, int width, int height) {
			glfwSetWindowSize(window, width, height);
		}
		public static void IconifyWindow(WindowPtr window) {
			glfwIconifyWindow(window);
		}
		public static void RestoreWindow(WindowPtr window) {
			glfwRestoreWindow(window);
		}
		public static void ShowWindow(WindowPtr window) {
			glfwShowWindow(window);
		}
		public static void HideWindow(WindowPtr window) {
			glfwHideWindow(window);
		}
		public static MonitorPtr GetWindowMonitor(WindowPtr window) {
			return glfwGetWindowMonitor(window);
		}
		public static int GetWindowAttrib(WindowPtr window, WindowAttrib param) {
			return glfwGetWindowAttrib(window, (int)param);
		}
		public static int GetWindowAttrib(WindowPtr window, WindowHint param) {
			return glfwGetWindowAttrib(window, (int)param);
		}
		public static void SetWindowUserPointer(WindowPtr window, IntPtr pointer) {
			glfwSetWindowUserPointer(window, pointer);
		}
		public static IntPtr GetWindowUserPointer(WindowPtr window) {
			return glfwGetWindowUserPointer(window);
		}
		private static GlfwFramebufferSizeFun framebufferSizeFun;
		public static GlfwFramebufferSizeFun SetFramebufferSizeCallback(WindowPtr window, GlfwFramebufferSizeFun cbfun) {
			framebufferSizeFun = cbfun;
			return glfwSetFramebufferSizeCallback(window, cbfun);
		}
		private static GlfwWindowPosFun windowPosFun;
		public static GlfwWindowPosFun SetWindowPosCallback(WindowPtr window, GlfwWindowPosFun cbfun) {
			windowPosFun = cbfun;
			return glfwSetWindowPosCallback(window, cbfun);
		}
		private static GlfwWindowSizeFun windowSizeFun;
		public static GlfwWindowSizeFun SetWindowSizeCallback(WindowPtr window, GlfwWindowSizeFun cbfun) {
			windowSizeFun = cbfun;
			return glfwSetWindowSizeCallback(window, cbfun);
		}
		private static GlfwWindowCloseFun windowCloseFun;
		public static GlfwWindowCloseFun SetWindowCloseCallback(WindowPtr window, GlfwWindowCloseFun cbfun) {
			windowCloseFun = cbfun;
			return glfwSetWindowCloseCallback(window, cbfun);
		}
		private static GlfwWindowRefreshFun windowRefreshFun;
		public static GlfwWindowRefreshFun SetWindowRefreshCallback(WindowPtr window, GlfwWindowRefreshFun cbfun) {
			windowRefreshFun = cbfun;
			return glfwSetWindowRefreshCallback(window, cbfun);
		}
		private static GlfwWindowFocusFun windowFocusFun;
		public static GlfwWindowFocusFun SetWindowFocusCallback(WindowPtr window, GlfwWindowFocusFun cbfun) {
			windowFocusFun = cbfun;
			return glfwSetWindowFocusCallback(window, cbfun);
		}
		private static GlfwWindowIconifyFun windowIconifyFun;
		public static GlfwWindowIconifyFun SetWindowIconifyCallback(WindowPtr window, GlfwWindowIconifyFun cbfun) {
			windowIconifyFun = cbfun;
			return glfwSetWindowIconifyCallback(window, cbfun);
		}
		public static void PollEvents() {
			glfwPollEvents();
		}
		public static void WaitEvents() {
			glfwWaitEvents();
		}
		public static int GetInputMode(WindowPtr window, InputMode mode) {
			return glfwGetInputMode(window, mode);
		}
		public static void SetInputMode(WindowPtr window, InputMode mode, CursorMode value) {
			glfwSetInputMode(window, mode, value);
		}
		public static bool GetKey(WindowPtr window, Key key) {
			return glfwGetKey(window, key) != 0;
		}
		public static bool GetMouseButton(WindowPtr window, MouseButton button) {
			return glfwGetMouseButton(window, button) != 0;
		}
		public static void GetCursorPos(WindowPtr window, out double xpos, out double ypos) {
			glfwGetCursorPos(window, out xpos, out ypos);
		}
		public static void SetCursorPos(WindowPtr window, double xpos, double ypos) {
			glfwSetCursorPos(window, xpos, ypos);
		}
		private static GlfwKeyFun keyFun;
		public static GlfwKeyFun SetKeyCallback(WindowPtr window, GlfwKeyFun cbfun) {
			keyFun = cbfun;
			return glfwSetKeyCallback(window, cbfun);
		}
		private static GlfwCharFun charFun;
		public static GlfwCharFun SetCharCallback(WindowPtr window, GlfwCharFun cbfun) {
			charFun = cbfun;
			return glfwSetCharCallback(window, cbfun);
		}
		private static GlfwMouseButtonFun mouseButtonFun;
		public static GlfwMouseButtonFun SetMouseButtonCallback(WindowPtr window, GlfwMouseButtonFun cbfun) {
			mouseButtonFun = cbfun;
			return glfwSetMouseButtonCallback(window, cbfun);
		}
		private static GlfwCursorPosFun cursorPosFun;
		public static GlfwCursorPosFun SetCursorPosCallback(WindowPtr window, GlfwCursorPosFun cbfun) {
			cursorPosFun = cbfun;
			return glfwSetCursorPosCallback(window, cbfun);
		}
		private static GlfwCursorEnterFun cursorEnterFun;
		public static GlfwCursorEnterFun SetCursorEnterCallback(WindowPtr window, GlfwCursorEnterFun cbfun) {
			cursorEnterFun = cbfun;
			return glfwSetCursorEnterCallback(window, cbfun);
		}
		private static GlfwScrollFun scrollFun;
		public static GlfwScrollFun SetScrollCallback(WindowPtr window, GlfwScrollFun cbfun) {
			scrollFun = cbfun;
			return glfwSetScrollCallback(window, cbfun);
		}
		public static bool JoystickPresent(Joystick joy) {
			return glfwJoystickPresent(joy) == 1;
		}
		public static float[] GetJoystickAxes(Joystick joy) {
			int numaxes;
			IntPtr ptr = glfwGetJoystickAxes(joy, out numaxes);
			float[] result = new float[numaxes];
			for (int i = 0; i < numaxes; ++i) {
                int offset = i * sizeof(float);
                result[i] = Marshal.PtrToStructure<float>(ptr + offset);
			}
			return result;
		}
		public static byte[] GetJoystickButtons(Joystick joy) {
			int numbuttons;
			IntPtr ptr = glfwGetJoystickButtons(joy, out numbuttons);
			byte[] result = new byte[numbuttons];
			for (int i = 0; i < numbuttons; ++i) {
                int offset = i * Marshal.SizeOf<byte>();
				result[i] = Marshal.PtrToStructure<byte>(ptr + offset);
			}
			return result;
		}
		public static string GetJoystickName(Joystick joy) {
			return Marshal.PtrToStringAnsi(glfwGetJoystickName(joy));
		}
		public static void SetClipboardString(WindowPtr window, string @string) {
			glfwSetClipboardString(window,  @string);
		}
		public static string GetClipboardString(WindowPtr window) {
			return Marshal.PtrToStringAnsi(glfwGetClipboardString(window));
		}
		public static double GetTime() {
			return glfwGetTime();
		}
		public static void SetTime(double time) {
			glfwSetTime(time);
		}
		public static void MakeContextCurrent(WindowPtr window) {
			glfwMakeContextCurrent(window);
		}
		public static WindowPtr GetCurrentContext() {
			return glfwGetCurrentContext();
		}
		public static void SwapBuffers(WindowPtr window) {
			glfwSwapBuffers(window);
		}
		public static void SwapInterval(int interval) {
			glfwSwapInterval(interval);
		}
		public static bool ExtensionSupported(string extension) {
			return glfwExtensionSupported(extension) == 1;
		}
		public static IntPtr GetProcAddress(string procname) {
			return glfwGetProcAddress(procname);
		}
	}
}
