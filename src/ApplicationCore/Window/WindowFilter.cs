using ApplicationCore.Interfaces;

namespace ApplicationCore.Window
{
    public static class WindowFilter
    {
        public static bool NormalWindow(IWindow window)
        {
            if (IsHiddenWindowStoreApp(window,  window.ClassName)) return false;

            return !IsToolWindow(window.ExtendedStyles) && window.IsVisible;
        }
        
        private static bool IsToolWindow(ExtendedWindowStyleFlags styleFlags) =>
            (styleFlags & ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW) == ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW;

        private static bool IsHiddenWindowStoreApp(IWindow window, string className) 
            => (className == "ApplicationFrameWindow" || className == "Windows.UI.Core.CoreWindow") && window.IsCloaked;
    }
}