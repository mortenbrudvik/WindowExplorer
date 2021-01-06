using System;
using System.Collections.Generic;

namespace window_lib.Interfaces
{
    public interface IWindowFactory
    {
        IWindow Create(IntPtr handle);
        List<Window> GetWindows(Predicate<Window> match);
    }
}