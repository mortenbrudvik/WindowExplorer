using ApplicationCore.Interfaces;

namespace ApplicationCore.Window
{
    public static class WindowFilter
    {
        public static bool IsNormalWindow(IWindow window)
        {
            var styles = window.Styles;
            return !(styles.IsPopup || styles.IsToolWindow || styles.IsChild ) && styles.HasSizingBorder && !string.IsNullOrWhiteSpace(window.Title);
        }
    }
}