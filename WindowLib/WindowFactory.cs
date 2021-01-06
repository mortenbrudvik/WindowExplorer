using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using PInvoke;
using window_lib.Interfaces;

namespace window_lib
{
    public class WindowFactory : IWindowFactory
    {
        public IWindow Create(IntPtr handle)
        {
            Guard.Against.Default(handle, nameof(handle));

            return new Window(handle);
        }

        public List<Window> GetWindows(Predicate<Window> match)
        {
            Guard.Against.Null(match, nameof(match));

            var windows = new List<Window>();
            User32.EnumWindows((handle, param) =>
            {
                var window = new Window(handle);
                if(match(window))
                    windows.Add(window);

                return true;
            }, IntPtr.Zero);

            return windows;
        }
    }
}