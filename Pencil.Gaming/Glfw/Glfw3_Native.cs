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
using System.Security;
using System.Runtime.InteropServices;

using Pencil.Gaming.Input;

namespace Pencil.Gaming.GLFW {
    [SuppressUnmanagedCodeSecurity]
	public static partial class Glfw_Native {
		[DllImport("glfw3")] 
		internal static extern int glfwInit();
		[DllImport("glfw3")] 
		internal static extern void glfwTerminate();
		[DllImport("glfw3")] 
		internal static extern void glfwGetVersion(out int major, out int minor, out int rev);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetVersionString();
		[DllImport("glfw3")]
		internal static extern GlfwErrorFun glfwSetErrorCallback(GlfwErrorFun cbfun);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetMonitors(out int count);
		[DllImport("glfw3")] 
		internal static extern MonitorPtr glfwGetPrimaryMonitor();
		[DllImport("glfw3")] 
		internal static extern void glfwGetMonitorPos(MonitorPtr monitor, out int xpos, out int ypos);
		[DllImport("glfw3")] 
		internal static extern void glfwGetMonitorPhysicalSize(MonitorPtr monitor, out int width, out int height);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetMonitorName(MonitorPtr monitor);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetVideoModes(MonitorPtr monitor, out int count);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetVideoMode(MonitorPtr monitor);
		[DllImport("glfw3")] 
		internal static extern void glfwSetGamma(MonitorPtr monitor, float gamma);
		[DllImport("glfw3")] 
		internal static extern void glfwGetGammaRamp(MonitorPtr monitor, out GammaRampInternal ramp);
		[DllImport("glfw3")] 
		internal static extern void glfwSetGammaRamp(MonitorPtr monitor, ref GammaRamp ramp);
		[DllImport("glfw3")] 
		internal static extern void glfwDefaultWindowHints();
		[DllImport("glfw3")] 
		internal static extern void glfwWindowHint(WindowHint target, int hint);
		[DllImport("glfw3")] 
		internal static extern WindowPtr glfwCreateWindow(int width, int height, [MarshalAs(UnmanagedType.LPStr)] string title, MonitorPtr monitor, WindowPtr share);
		[DllImport("glfw3")] 
		internal static extern void glfwDestroyWindow(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern int glfwWindowShouldClose(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern void glfwSetWindowShouldClose(WindowPtr window, int value);
		[DllImport("glfw3")] 
		internal static extern void glfwSetWindowTitle(WindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string title);
		[DllImport("glfw3")] 
		internal static extern void glfwGetWindowPos(WindowPtr window, out int xpos, out int ypos);
		[DllImport("glfw3")] 
		internal static extern void glfwSetWindowPos(WindowPtr window, int xpos, int ypos);
		[DllImport("glfw3")]
		internal static extern void glfwGetWindowSize(WindowPtr window, out int width, out int height);
		[DllImport("glfw3")] 
		internal static extern void glfwSetWindowSize(WindowPtr window, int width, int height);
		[DllImport("glfw3")] 
		internal static extern void glfwIconifyWindow(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern void glfwRestoreWindow(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern void glfwShowWindow(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern void glfwHideWindow(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern MonitorPtr glfwGetWindowMonitor(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern int glfwGetWindowAttrib(WindowPtr window, int param);
		[DllImport("glfw3")] 
		internal static extern void glfwSetWindowUserPointer(WindowPtr window, IntPtr pointer);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetWindowUserPointer(WindowPtr window);
		[DllImport("glfw3")]
		internal static extern GlfwWindowPosFun glfwSetWindowPosCallback(WindowPtr window, GlfwWindowPosFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwWindowSizeFun glfwSetWindowSizeCallback(WindowPtr window, GlfwWindowSizeFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwWindowCloseFun glfwSetWindowCloseCallback(WindowPtr window, GlfwWindowCloseFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwWindowRefreshFun glfwSetWindowRefreshCallback(WindowPtr window, GlfwWindowRefreshFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwWindowFocusFun glfwSetWindowFocusCallback(WindowPtr window, GlfwWindowFocusFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwWindowIconifyFun glfwSetWindowIconifyCallback(WindowPtr window, GlfwWindowIconifyFun cbfun);
		[DllImport("glfw3")] 
		internal static extern void glfwPollEvents();
		[DllImport("glfw3")] 
		internal static extern void glfwWaitEvents();
		[DllImport("glfw3")] 
		internal static extern int glfwGetInputMode(WindowPtr window, InputMode mode);
		[DllImport("glfw3")] 
		internal static extern void glfwSetInputMode(WindowPtr window, InputMode mode, CursorMode value);
		[DllImport("glfw3")] 
		internal static extern int glfwGetKey(WindowPtr window, Key key);
		[DllImport("glfw3")] 
		internal static extern int glfwGetMouseButton(WindowPtr window, MouseButton button);
		[DllImport("glfw3")] 
		internal static extern void glfwGetCursorPos(WindowPtr window, out double xpos, out double ypos);
		[DllImport("glfw3")] 
		internal static extern void glfwSetCursorPos(WindowPtr window, double xpos, double ypos);
		[DllImport("glfw3")]
		internal static extern GlfwKeyFun glfwSetKeyCallback(WindowPtr window, GlfwKeyFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwCharFun glfwSetCharCallback(WindowPtr window, GlfwCharFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwMouseButtonFun glfwSetMouseButtonCallback(WindowPtr window, GlfwMouseButtonFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwCursorPosFun glfwSetCursorPosCallback(WindowPtr window, GlfwCursorPosFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwCursorEnterFun glfwSetCursorEnterCallback(WindowPtr window, GlfwCursorEnterFun cbfun);
		[DllImport("glfw3")]
		internal static extern GlfwScrollFun glfwSetScrollCallback(WindowPtr window, GlfwScrollFun cbfun);
		[DllImport("glfw3")] 
		internal static extern int glfwJoystickPresent(Joystick joy);
		[DllImport("glfw3")]
		internal static extern IntPtr glfwGetJoystickAxes(Joystick joy, out int numaxes);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetJoystickButtons(Joystick joy, out int numbuttons);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetJoystickName(Joystick joy);
		[DllImport("glfw3")] 
		internal static extern void glfwSetClipboardString(WindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string @string);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetClipboardString(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern double glfwGetTime();
		[DllImport("glfw3")] 
		internal static extern void glfwSetTime(double time);
		[DllImport("glfw3")] 
		internal static extern void glfwMakeContextCurrent(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern WindowPtr glfwGetCurrentContext();
		[DllImport("glfw3")] 
		internal static extern void glfwSwapBuffers(WindowPtr window);
		[DllImport("glfw3")] 
		internal static extern void glfwSwapInterval(int interval);
		[DllImport("glfw3")] 
		internal static extern int glfwExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);
		[DllImport("glfw3")] 
		internal static extern IntPtr glfwGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string procname);

		[DllImport("glfw3")]
		internal static extern void glfwGetFramebufferSize(WindowPtr window, out int width, out int height);
		[DllImport("glfw3")]
		internal static extern GlfwFramebufferSizeFun glfwSetFramebufferSizeCallback(WindowPtr window, GlfwFramebufferSizeFun cbfun);
	}
}
