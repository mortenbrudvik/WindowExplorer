using ApplicationCore.Interfaces;

namespace ApplicationCore.Window
{
    /// <summary>
    /// Based on PowerToys window filtering
    /// https://github.com/microsoft/PowerToys/blob/fa92f2e581e8c74c8968c385b49a72af4266a352/src/modules/launcher/Plugins/Microsoft.Plugin.WindowWalker/Components/OpenWindows.cs#L83
    /// </summary>
    public static class WindowFilter
    {
        public static bool NormalWindow(IWindow window)
        {
            return window.IsVisible &&
                   window.IsWindow &&
                   window.IsOwner &&
                   window.Title.Length > 0 &&
                   (!IsToolWindow(window.ExtendedStyles) || IsAppWindow(window.ExtendedStyles)) &&
                   !window.IsTaskListDeleted &&
                   window.ClassName != "Windows.UI.Core.CoreWindow";
        }

        private static bool IsToolWindow(ExtendedWindowStyleFlags styleFlags) =>
            (styleFlags & ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW) == ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW;
        
        private static bool IsAppWindow(ExtendedWindowStyleFlags styleFlags) =>
            (styleFlags & ExtendedWindowStyleFlags.WS_EX_APPWINDOW) == ExtendedWindowStyleFlags.WS_EX_APPWINDOW;
    }
}