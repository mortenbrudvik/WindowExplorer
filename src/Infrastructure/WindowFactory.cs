using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using PInvoke;

namespace Infrastructure
{
    public class WindowFactory : IWindowFactory
    {
        public IWindow Create(IntPtr handle)
        {
            Guard.Against.Default(handle, nameof(handle));

            return new Window(handle);
        }

        public List<IWindow> GetWindows(Predicate<IWindow> match)
        {
            Guard.Against.Null(match, nameof(match));

            var windows = new List<IWindow>();
            User32.EnumWindows((handle, _) =>
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