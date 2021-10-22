using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using ApplicationCore.Interfaces;
using ApplicationCore.Window;
using Infrastructure.Common;
using JetBrains.Annotations;
using PInvoke;

namespace Infrastructure
{
    public class Window : IWindow
    {
        public Window(IntPtr handle) => Handle = handle;

        public IntPtr Handle { get; }
        public string Title => User32.GetWindowText(Handle);
        public bool IsVisible => User32.IsWindowVisible(Handle);
        public bool IsWindow => User32.IsWindow(Handle);

        public bool IsOwner => User32.GetWindow(Handle, User32.GetWindowCommands.GW_OWNER) != null;
        public bool IsTaskListDeleted => GetProp(Handle, "ITaskList_Deleted") != IntPtr.Zero;

        public string ClassName => User32.GetClassName(Handle);
        public WindowStyleFlags Styles => GetWindowStyles(Handle);
        public ExtendedWindowStyleFlags ExtendedStyles => GetExtendedWindowStyles(Handle);

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
        
        public string GetCommandLine()
        {
            try
            {
                var process = Process.GetProcessById(ProcessId);

                var query = $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}";

                using var searcher = new ManagementObjectSearcher(query);
                using var result = searcher.Get();
                return result.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString() ?? "";
            }
            catch (Exception) // Swallow
            {
                return "";
            }
        }
        
        private static ExtendedWindowStyleFlags GetExtendedWindowStyles(IntPtr handle) =>
            (ExtendedWindowStyleFlags)User32.GetWindowLong(handle, User32.WindowLongIndexFlags.GWL_EXSTYLE);

        private static WindowStyleFlags GetWindowStyles(IntPtr handle) =>
            (WindowStyleFlags)User32.GetWindowLong(handle, User32.WindowLongIndexFlags.GWL_STYLE);
        
        [DllImport("user32.dll", SetLastError = true, BestFitMapping = false)]
        private static extern IntPtr GetProp(IntPtr hWnd, string lpString);
    }
}