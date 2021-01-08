using System;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IWindowFactory
    {
        IWindow Create(IntPtr handle);
        List<IWindow> GetWindows(Predicate<IWindow> match);
    }
}