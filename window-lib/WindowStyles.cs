using System;
using System.Collections.Generic;
using PInvoke;
using window_lib.Extensions;

namespace window_lib
{
    public class WindowStyles
    {
        private readonly User32.WindowStyles _windowStyles;
        private readonly User32.WindowStylesEx _windowStylesExtended;

        public IEnumerable<Enum> StylesSetFlags => _windowStyles.GetUniqueFlags();
        public IEnumerable<Enum> StylesExSetFlags => _windowStylesExtended.GetUniqueFlags();

        public WindowStyles(IntPtr handle)
        {
            _windowStyles = (User32.WindowStyles)User32.GetWindowLong(handle, User32.WindowLongIndexFlags.GWL_STYLE);
            _windowStylesExtended = (User32.WindowStylesEx)User32.GetWindowLong(handle, User32.WindowLongIndexFlags.GWL_EXSTYLE);
        }

        public bool HasSizingBorder => (_windowStyles & User32.WindowStyles.WS_SIZEFRAME) == User32.WindowStyles.WS_SIZEFRAME;
        public bool IsChild => (_windowStyles & User32.WindowStyles.WS_CHILD) == User32.WindowStyles.WS_CHILD;
        public bool IsPopup => (_windowStyles & User32.WindowStyles.WS_POPUP) == User32.WindowStyles.WS_POPUP;

        public bool IsToolWindow => (_windowStylesExtended & User32.WindowStylesEx.WS_EX_TOOLWINDOW) == User32.WindowStylesEx.WS_EX_TOOLWINDOW;
    }
}