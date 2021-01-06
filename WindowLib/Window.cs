using System;
using PInvoke;
using window_lib.Interfaces;

namespace window_lib
{
    public class Window : IWindow
    {
        public Window(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }
        public string Title => User32.GetWindowText(Handle);
        public bool IsVisible => User32.IsWindowVisible(Handle);
        public string ClassName => User32.GetClassName(Handle);
        public WindowStyles Styles => new(Handle);

        public override bool Equals(object obj)
        {
            return obj != null && Equals((Window)obj);
        }

        protected bool Equals(Window other)
        {
            return ((int)Handle).Equals((int)other.Handle);
        }

        public override int GetHashCode()
        {
            return ((int)Handle).GetHashCode();
        }
    }
}