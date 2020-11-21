using System;

namespace window_lib.Interfaces
{
    public interface IWindow
    {
        IntPtr Handle { get; }
        string Title { get; }
        bool IsVisible { get; }
        WindowStyles Styles { get; }
    }
}