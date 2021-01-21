using System;
using System.Diagnostics;
using ApplicationCore.Interfaces;
using Infrastructure.Common;
using PInvoke;

namespace Infrastructure
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
        public IWindowStyles Styles => new WindowStyles(Handle);

        public string ProcessName => Process.GetProcessById(ProcessId).ProcessName.Trim();
        public int ProcessId
        {
            get
            {
                User32.GetWindowThreadProcessId(Handle, out var processId);
                return processId;
            }
        }

        public bool IsCloaked
        {
            get
            {
                
                DwmApi.DwmGetWindowAttribute(Handle, DwmApi.DWMWA_CLOAKED, out int cloaked, sizeof(int));
                return cloaked != 0;
            }
        } 


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