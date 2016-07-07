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
	internal static class Glfw_Native {
        const string lib = "natives";
		[DllImport(lib)] 
		internal static extern int glfwInit();
		[DllImport(lib)] 
		internal static extern void glfwTerminate();
		[DllImport(lib)] 
		internal static extern void glfwGetVersion(out int major, out int minor, out int rev);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetVersionString();
		[DllImport(lib)]
		internal static extern GlfwErrorFun glfwSetErrorCallback(GlfwErrorFun cbfun);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetMonitors(out int count);
		[DllImport(lib)] 
		internal static extern MonitorPtr glfwGetPrimaryMonitor();
		[DllImport(lib)] 
		internal static extern void glfwGetMonitorPos(MonitorPtr monitor, out int xpos, out int ypos);
		[DllImport(lib)] 
		internal static extern void glfwGetMonitorPhysicalSize(MonitorPtr monitor, out int width, out int height);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetMonitorName(MonitorPtr monitor);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetVideoModes(MonitorPtr monitor, out int count);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetVideoMode(MonitorPtr monitor);
		[DllImport(lib)] 
		internal static extern void glfwSetGamma(MonitorPtr monitor, float gamma);
		[DllImport(lib)] 
		internal static extern void glfwGetGammaRamp(MonitorPtr monitor, out GammaRampInternal ramp);
		[DllImport(lib)] 
		internal static extern void glfwSetGammaRamp(MonitorPtr monitor, ref GammaRamp ramp);
		[DllImport(lib)] 
		internal static extern void glfwDefaultWindowHints();
		[DllImport(lib)] 
		internal static extern void glfwWindowHint(WindowHint target, int hint);
		[DllImport(lib)] 
		internal static extern WindowPtr glfwCreateWindow(int width, int height, [MarshalAs(UnmanagedType.LPStr)] string title, MonitorPtr monitor, WindowPtr share);
		[DllImport(lib)] 
		internal static extern void glfwDestroyWindow(WindowPtr window);
		[DllImport(lib)] 
		internal static extern int glfwWindowShouldClose(WindowPtr window);
		[DllImport(lib)] 
		internal static extern void glfwSetWindowShouldClose(WindowPtr window, int value);
		[DllImport(lib)] 
		internal static extern void glfwSetWindowTitle(WindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string title);
		[DllImport(lib)] 
		internal static extern void glfwGetWindowPos(WindowPtr window, out int xpos, out int ypos);
		[DllImport(lib)] 
		internal static extern void glfwSetWindowPos(WindowPtr window, int xpos, int ypos);
		[DllImport(lib)]
		internal static extern void glfwGetWindowSize(WindowPtr window, out int width, out int height);
		[DllImport(lib)] 
		internal static extern void glfwSetWindowSize(WindowPtr window, int width, int height);
		[DllImport(lib)] 
		internal static extern void glfwIconifyWindow(WindowPtr window);
		[DllImport(lib)] 
		internal static extern void glfwRestoreWindow(WindowPtr window);
		[DllImport(lib)] 
		internal static extern void glfwShowWindow(WindowPtr window);
		[DllImport(lib)] 
		internal static extern void glfwHideWindow(WindowPtr window);
		[DllImport(lib)] 
		internal static extern MonitorPtr glfwGetWindowMonitor(WindowPtr window);
		[DllImport(lib)] 
		internal static extern int glfwGetWindowAttrib(WindowPtr window, int param);
		[DllImport(lib)] 
		internal static extern void glfwSetWindowUserPointer(WindowPtr window, IntPtr pointer);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetWindowUserPointer(WindowPtr window);
		[DllImport(lib)]
		internal static extern GlfwWindowPosFun glfwSetWindowPosCallback(WindowPtr window, GlfwWindowPosFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwWindowSizeFun glfwSetWindowSizeCallback(WindowPtr window, GlfwWindowSizeFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwWindowCloseFun glfwSetWindowCloseCallback(WindowPtr window, GlfwWindowCloseFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwWindowRefreshFun glfwSetWindowRefreshCallback(WindowPtr window, GlfwWindowRefreshFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwWindowFocusFun glfwSetWindowFocusCallback(WindowPtr window, GlfwWindowFocusFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwWindowIconifyFun glfwSetWindowIconifyCallback(WindowPtr window, GlfwWindowIconifyFun cbfun);
		[DllImport(lib)] 
		internal static extern void glfwPollEvents();
		[DllImport(lib)] 
		internal static extern void glfwWaitEvents();
		[DllImport(lib)] 
		internal static extern int glfwGetInputMode(WindowPtr window, InputMode mode);
		[DllImport(lib)] 
		internal static extern void glfwSetInputMode(WindowPtr window, InputMode mode, CursorMode value);
		[DllImport(lib)] 
		internal static extern int glfwGetKey(WindowPtr window, Key key);
		[DllImport(lib)] 
		internal static extern int glfwGetMouseButton(WindowPtr window, MouseButton button);
		[DllImport(lib)] 
		internal static extern void glfwGetCursorPos(WindowPtr window, out double xpos, out double ypos);
		[DllImport(lib)] 
		internal static extern void glfwSetCursorPos(WindowPtr window, double xpos, double ypos);
		[DllImport(lib)]
		internal static extern GlfwKeyFun glfwSetKeyCallback(WindowPtr window, GlfwKeyFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwCharFun glfwSetCharCallback(WindowPtr window, GlfwCharFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwMouseButtonFun glfwSetMouseButtonCallback(WindowPtr window, GlfwMouseButtonFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwCursorPosFun glfwSetCursorPosCallback(WindowPtr window, GlfwCursorPosFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwCursorEnterFun glfwSetCursorEnterCallback(WindowPtr window, GlfwCursorEnterFun cbfun);
		[DllImport(lib)]
		internal static extern GlfwScrollFun glfwSetScrollCallback(WindowPtr window, GlfwScrollFun cbfun);
		[DllImport(lib)] 
		internal static extern int glfwJoystickPresent(Joystick joy);
		[DllImport(lib)]
		internal static extern IntPtr glfwGetJoystickAxes(Joystick joy, out int numaxes);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetJoystickButtons(Joystick joy, out int numbuttons);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetJoystickName(Joystick joy);
		[DllImport(lib)] 
		internal static extern void glfwSetClipboardString(WindowPtr window, [MarshalAs(UnmanagedType.LPStr)] string @string);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetClipboardString(WindowPtr window);
		[DllImport(lib)] 
		internal static extern double glfwGetTime();
		[DllImport(lib)] 
		internal static extern void glfwSetTime(double time);
		[DllImport(lib)] 
		internal static extern void glfwMakeContextCurrent(WindowPtr window);
		[DllImport(lib)] 
		internal static extern WindowPtr glfwGetCurrentContext();
		[DllImport(lib)] 
		internal static extern void glfwSwapBuffers(WindowPtr window);
		[DllImport(lib)] 
		internal static extern void glfwSwapInterval(int interval);
		[DllImport(lib)] 
		internal static extern int glfwExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);
		[DllImport(lib)] 
		internal static extern IntPtr glfwGetProcAddress([MarshalAs(UnmanagedType.LPStr)] string procname);
		[DllImport(lib)]
		internal static extern void glfwGetFramebufferSize(WindowPtr window, out int width, out int height);
		[DllImport(lib)]
		internal static extern GlfwFramebufferSizeFun glfwSetFramebufferSizeCallback(WindowPtr window, GlfwFramebufferSizeFun cbfun);
        [DllImport(lib)]
        internal static extern IntPtr glfwGetAddressOfGetProc();
    }
}
