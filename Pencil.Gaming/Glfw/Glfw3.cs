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

namespace Pencil.Gaming {
	public static unsafe partial class Glfw {
		#pragma warning disable 0414

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
			return new string(glfwGetVersionString());
		}
		private static GlfwErrorFun errorCallback;
		public static GlfwErrorFun SetErrorCallback(GlfwErrorFun cbfun) {
			errorCallback = cbfun;
			return glfwSetErrorCallback(cbfun);
		}
		public static unsafe GlfwMonitorPtr[] GetMonitors() {
			int count;
			GlfwMonitorPtr * array = glfwGetMonitors(out count);
			GlfwMonitorPtr[] result = new GlfwMonitorPtr[count];
			for (int i = 0; i < count; ++i) {
				result[i] = array[i];
			}
			return result;
		}
		public static GlfwMonitorPtr GetPrimaryMonitor() {
			return glfwGetPrimaryMonitor();
		}
		public static void GetMonitorPos(GlfwMonitorPtr monitor, out int xpos, out int ypos) {
			glfwGetMonitorPos(monitor, out xpos, out ypos);
		}
		public static void GetMonitorPhysicalSize(GlfwMonitorPtr monitor, out int width, out int height) {
			glfwGetMonitorPhysicalSize(monitor, out width, out height);
		}
		public static string GetMonitorName(GlfwMonitorPtr monitor) {
			return new string(glfwGetMonitorName(monitor));
		}
		public static GlfwVidMode[] GetVideoModes(GlfwMonitorPtr monitor) {
			int count;
			GlfwVidMode * array = glfwGetVideoModes(monitor, out count);
			GlfwVidMode[] result = new GlfwVidMode[count];
			for (int i = 0; i < count; ++i) {
				result[i] = array[i];
			}
			return result;
		}
		public static GlfwVidMode GetVideoMode(GlfwMonitorPtr monitor) {
            GlfwVidMode* vidMode = glfwGetVideoMode(monitor);
            GlfwVidMode returnMode = new GlfwVidMode {
                RedBits = vidMode->RedBits,
                GreenBits = vidMode->GreenBits,
                BlueBits = vidMode->BlueBits,
                RefreshRate = vidMode->RefreshRate,
                Width = vidMode->Width,
                Height = vidMode->Height
            };
            return returnMode;
		}
		public static void SetGamma(GlfwMonitorPtr monitor, float gamma) {
			glfwSetGamma(monitor, gamma);
		}
		public static void GetGammaRamp(GlfwMonitorPtr monitor, out GlfwGammaRamp ramp) {
			GlfwGammaRampInternal rampI;
			glfwGetGammaRamp(monitor, out rampI);
			uint length = rampI.Length;
			ramp = new GlfwGammaRamp();
			ramp.Red = new uint[length];
			ramp.Green = new uint[length];
			ramp.Blue = new uint[length];
			for (int i = 0; i < ramp.Red.Length; ++i) {
				ramp.Red[i] = rampI.Red[i];
			}
			for (int i = 0; i < ramp.Green.Length; ++i) {
				ramp.Green[i] = rampI.Green[i];
			}
			for (int i = 0; i < ramp.Blue.Length; ++i) {
				ramp.Blue[i] = rampI.Blue[i];
			}
		}
		public static void SetGammaRamp(GlfwMonitorPtr monitor, ref GlfwGammaRamp ramp) {
			ramp.Length = (uint)ramp.Red.Length;
			glfwSetGammaRamp(monitor, ref ramp);
		}
		public static void DefaultWindowHints() {
			glfwDefaultWindowHints();
		}
		public static void WindowHint(WindowHint target, int hint) {
			glfwWindowHint(target, hint);
		}
		public static GlfwWindowPtr CreateWindow(int width, int height, string title, GlfwMonitorPtr monitor, GlfwWindowPtr share) {
			return glfwCreateWindow(width, height, title, monitor, share);
		}
		public static void DestroyWindow(GlfwWindowPtr window) {
			glfwDestroyWindow(window);
		}
		public static void GetFramebufferSize(GlfwWindowPtr window, out int width, out int height) {
			glfwGetFramebufferSize(window, out width, out height);
		}
		public static bool WindowShouldClose(GlfwWindowPtr window) {
			return glfwWindowShouldClose(window) == 1;
		}
		public static void SetWindowShouldClose(GlfwWindowPtr window, bool value) {
			glfwSetWindowShouldClose(window, value ? 1 : 0);
		}
		public static void SetWindowTitle(GlfwWindowPtr window, string title) {
			glfwSetWindowTitle(window, title);
		}
		public static void GetWindowPos(GlfwWindowPtr window, out int xpos, out int ypos) {
			glfwGetWindowPos(window, out xpos, out ypos);
		}
		public static void SetWindowPos(GlfwWindowPtr window, int xpos, int ypos) {
			glfwSetWindowPos(window, xpos, ypos);
		}
		public static void GetWindowSize(GlfwWindowPtr window, out int width, out int height) {
			glfwGetWindowSize(window, out width, out height);
		}
		public static void SetWindowSize(GlfwWindowPtr window, int width, int height) {
			glfwSetWindowSize(window, width, height);
		}
		public static void IconifyWindow(GlfwWindowPtr window) {
			glfwIconifyWindow(window);
		}
		public static void RestoreWindow(GlfwWindowPtr window) {
			glfwRestoreWindow(window);
		}
		public static void ShowWindow(GlfwWindowPtr window) {
			glfwShowWindow(window);
		}
		public static void HideWindow(GlfwWindowPtr window) {
			glfwHideWindow(window);
		}
		public static GlfwMonitorPtr GetWindowMonitor(GlfwWindowPtr window) {
			return glfwGetWindowMonitor(window);
		}
		public static int GetWindowAttrib(GlfwWindowPtr window, WindowAttrib param) {
			return glfwGetWindowAttrib(window, (int)param);
		}
		public static int GetWindowAttrib(GlfwWindowPtr window, WindowHint param) {
			return glfwGetWindowAttrib(window, (int)param);
		}
		public static void SetWindowUserPointer(GlfwWindowPtr window, IntPtr pointer) {
			glfwSetWindowUserPointer(window, pointer);
		}
		public static IntPtr GetWindowUserPointer(GlfwWindowPtr window) {
			return glfwGetWindowUserPointer(window);
		}
		private static GlfwFramebufferSizeFun framebufferSizeFun;
		public static GlfwFramebufferSizeFun SetFramebufferSizeCallback(GlfwWindowPtr window, GlfwFramebufferSizeFun cbfun) {
			framebufferSizeFun = cbfun;
			return glfwSetFramebufferSizeCallback(window, cbfun);
		}
		private static GlfwWindowPosFun windowPosFun;
		public static GlfwWindowPosFun SetWindowPosCallback(GlfwWindowPtr window, GlfwWindowPosFun cbfun) {
			windowPosFun = cbfun;
			return glfwSetWindowPosCallback(window, cbfun);
		}
		private static GlfwWindowSizeFun windowSizeFun;
		public static GlfwWindowSizeFun SetWindowSizeCallback(GlfwWindowPtr window, GlfwWindowSizeFun cbfun) {
			windowSizeFun = cbfun;
			return glfwSetWindowSizeCallback(window, cbfun);
		}
		private static GlfwWindowCloseFun windowCloseFun;
		public static GlfwWindowCloseFun SetWindowCloseCallback(GlfwWindowPtr window, GlfwWindowCloseFun cbfun) {
			windowCloseFun = cbfun;
			return glfwSetWindowCloseCallback(window, cbfun);
		}
		private static GlfwWindowRefreshFun windowRefreshFun;
		public static GlfwWindowRefreshFun SetWindowRefreshCallback(GlfwWindowPtr window, GlfwWindowRefreshFun cbfun) {
			windowRefreshFun = cbfun;
			return glfwSetWindowRefreshCallback(window, cbfun);
		}
		private static GlfwWindowFocusFun windowFocusFun;
		public static GlfwWindowFocusFun SetWindowFocusCallback(GlfwWindowPtr window, GlfwWindowFocusFun cbfun) {
			windowFocusFun = cbfun;
			return glfwSetWindowFocusCallback(window, cbfun);
		}
		private static GlfwWindowIconifyFun windowIconifyFun;
		public static GlfwWindowIconifyFun SetWindowIconifyCallback(GlfwWindowPtr window, GlfwWindowIconifyFun cbfun) {
			windowIconifyFun = cbfun;
			return glfwSetWindowIconifyCallback(window, cbfun);
		}
		public static void PollEvents() {
			glfwPollEvents();
		}
		public static void WaitEvents() {
			glfwWaitEvents();
		}
		public static int GetInputMode(GlfwWindowPtr window, InputMode mode) {
			return glfwGetInputMode(window, mode);
		}
		public static void SetInputMode(GlfwWindowPtr window, InputMode mode, CursorMode value) {
			glfwSetInputMode(window, mode, value);
		}
		public static bool GetKey(GlfwWindowPtr window, Key key) {
			return glfwGetKey(window, key) != 0;
		}
		public static bool GetMouseButton(GlfwWindowPtr window, MouseButton button) {
			return glfwGetMouseButton(window, button) != 0;
		}
		public static void GetCursorPos(GlfwWindowPtr window, out double xpos, out double ypos) {
			glfwGetCursorPos(window, out xpos, out ypos);
		}
		public static void SetCursorPos(GlfwWindowPtr window, double xpos, double ypos) {
			glfwSetCursorPos(window, xpos, ypos);
		}
		private static GlfwKeyFun keyFun;
		public static GlfwKeyFun SetKeyCallback(GlfwWindowPtr window, GlfwKeyFun cbfun) {
			keyFun = cbfun;
			return glfwSetKeyCallback(window, cbfun);
		}
		private static GlfwCharFun charFun;
		public static GlfwCharFun SetCharCallback(GlfwWindowPtr window, GlfwCharFun cbfun) {
			charFun = cbfun;
			return glfwSetCharCallback(window, cbfun);
		}
		private static GlfwMouseButtonFun mouseButtonFun;
		public static GlfwMouseButtonFun SetMouseButtonCallback(GlfwWindowPtr window, GlfwMouseButtonFun cbfun) {
			mouseButtonFun = cbfun;
			return glfwSetMouseButtonCallback(window, cbfun);
		}
		private static GlfwCursorPosFun cursorPosFun;
		public static GlfwCursorPosFun SetCursorPosCallback(GlfwWindowPtr window, GlfwCursorPosFun cbfun) {
			cursorPosFun = cbfun;
			return glfwSetCursorPosCallback(window, cbfun);
		}
		private static GlfwCursorEnterFun cursorEnterFun;
		public static GlfwCursorEnterFun SetCursorEnterCallback(GlfwWindowPtr window, GlfwCursorEnterFun cbfun) {
			cursorEnterFun = cbfun;
			return glfwSetCursorEnterCallback(window, cbfun);
		}
		private static GlfwScrollFun scrollFun;
		public static GlfwScrollFun SetScrollCallback(GlfwWindowPtr window, GlfwScrollFun cbfun) {
			scrollFun = cbfun;
			return glfwSetScrollCallback(window, cbfun);
		}
		public static bool JoystickPresent(Joystick joy) {
			return glfwJoystickPresent(joy) == 1;
		}
		public static float[] GetJoystickAxes(Joystick joy) {
			int numaxes;
			float * axes = glfwGetJoystickAxes(joy, out numaxes);
			float[] result = new float[numaxes];
			for (int i = 0; i < numaxes; ++i) {
				result[i] = axes[i];
			}
			return result;
		}
		public static byte[] GetJoystickButtons(Joystick joy) {
			int numbuttons;
			byte * buttons = glfwGetJoystickButtons(joy, out numbuttons);
			byte[] result = new byte[numbuttons];
			for (int i = 0; i < numbuttons; ++i) {
				result[i] = buttons[i];
			}
			return result;
		}
		public static string GetJoystickName(Joystick joy) {
			return new string(glfwGetJoystickName(joy));
		}
		public static void SetClipboardString(GlfwWindowPtr window, string @string) {
			glfwSetClipboardString(window,  @string);
		}
		public static string GetClipboardString(GlfwWindowPtr window) {
			return new string(glfwGetClipboardString(window));
		}
		public static double GetTime() {
			return glfwGetTime();
		}
		public static void SetTime(double time) {
			glfwSetTime(time);
		}
		public static void MakeContextCurrent(GlfwWindowPtr window) {
			glfwMakeContextCurrent(window);
		}
		public static GlfwWindowPtr GetCurrentContext() {
			return glfwGetCurrentContext();
		}
		public static void SwapBuffers(GlfwWindowPtr window) {
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

		#pragma warning restore 0414
	}
}
