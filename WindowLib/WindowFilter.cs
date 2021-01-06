namespace window_lib
{
    public static class WindowFilter
    {
        public static bool IsNormalWindow(Window window)
        {
            var styles = window.Styles;
            return !(styles.IsPopup || styles.IsToolWindow || styles.IsChild ) && styles.HasSizingBorder && !string.IsNullOrWhiteSpace(window.Title);
        }
    }
}