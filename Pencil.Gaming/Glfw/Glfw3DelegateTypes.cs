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

namespace Pencil.Gaming.GLFW {
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwErrorFun(GlfwError code,[MarshalAs(UnmanagedType.LPStr)] string desc);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwMonitorFun(MonitorPtr mtor,ConnectionState @enum);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowCloseFun(WindowPtr wnd);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowPosFun(WindowPtr wnd,int x,int y);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowRefreshFun(WindowPtr wnd);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowSizeFun(WindowPtr wnd,int width,int height);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowFocusFun(WindowPtr wnd,bool focus);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwKeyFun(WindowPtr wnd,Key key,int scanCode,KeyAction action,KeyModifiers mods);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwCharFun(WindowPtr wnd,char ch);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwMouseButtonFun(WindowPtr wnd,MouseButton btn,KeyAction action);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwWindowIconifyFun(WindowPtr wnd,bool iconify);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwCursorPosFun(WindowPtr wnd,double x,double y);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwCursorEnterFun(WindowPtr wnd,bool enter);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwScrollFun(WindowPtr wnd,double xoffset,double yoffset);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GlfwFramebufferSizeFun(WindowPtr wnd,int width,int height);
}