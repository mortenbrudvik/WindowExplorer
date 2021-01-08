using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using PInvoke;

namespace Infrastructure
{
    public class WindowStyles : IWindowStyles
    {
        private readonly User32.WindowStyles _windowStyles;
        private readonly User32.WindowStylesEx _windowStylesExtended;

        public ICollection<string> StylesSetFlags => _windowStyles.GetUniqueFlags().Select(x=>x.ToString()).ToList();
        public ICollection<string> StylesExSetFlags => _windowStylesExtended.GetUniqueFlags().Select(x=>x.ToString()).ToList();

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