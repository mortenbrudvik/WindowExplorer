using System;
using ApplicationCore.Window;

namespace ApplicationCore.Interfaces
{
    public interface IWindow
    {
        IntPtr Handle { get; }
        string Title { get; }
        bool IsVisible { get; }
        bool IsWindow { get; }
        bool IsOwner { get; }
        bool IsTaskListDeleted { get; }
        WindowStyleFlags Styles { get; }
        ExtendedWindowStyleFlags ExtendedStyles { get; }
        string ClassName { get; }
        string ProcessName { get; }
        int ProcessId { get; }
        bool IsCloaked { get; }
        string GetCommandLine();
    }
}