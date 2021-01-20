using ApplicationCore.Interfaces;

namespace ApplicationCore.Window
{
    public static class WindowFilter
    {
        public static bool IsNormalWindow(IWindow window)
        {
            if (IsHiddenWindowStoreApp(window,  window.ClassName)) return false;

            return !window.Styles.IsToolWindow && window.IsVisible;
        }

        private static bool IsHiddenWindowStoreApp(IWindow window, string className) 
            => (className == "ApplicationFrameWindow" || className == "Windows.UI.Core.CoreWindow") && window.IsCloaked;
    }
}