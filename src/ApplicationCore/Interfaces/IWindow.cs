using System;

namespace ApplicationCore.Interfaces
{
    public interface IWindow
    {
        IntPtr Handle { get; }
        string Title { get; }
        bool IsVisible { get; }
        IWindowStyles Styles { get; }
        string ClassName { get; }
        string ProcessName { get; }
        int ProcessId { get; }
        bool IsCloaked { get; }
    }
}