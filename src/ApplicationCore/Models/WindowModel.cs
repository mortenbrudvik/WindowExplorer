using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces;
using ApplicationCore.Window;

namespace ApplicationCore.Models
{
    public class WindowModel
    {
        public WindowModel(IWindow window, bool includeStyleFlags)
        {
            Handle = window.Handle.ToString();
            Title = window.Title;
            ClassName = window.ClassName;
            ProcessName = window.ProcessName;
            ProcessId = window.ProcessId;
            ProcessArguments = window.GetCommandLine();
            Styles = includeStyleFlags ? string.Join(',',Convert(window.Styles).ToList()) : "";
            ExtendedStyles = includeStyleFlags ?  string.Join(',',Convert(window.ExtendedStyles).ToList()) : "";
        }
        
        public int ProcessId { get; }
        public string ProcessArguments { get; }
        public string Handle { get; }
        public string ProcessName { get; }
        public string ClassName { get; }
        public string Title { get; }
        public string Styles { get; }
        public string ExtendedStyles { get; }
        
        private static IEnumerable<string> Convert(WindowStyleFlags styles) => 
            from styleName in Enum.GetNames(typeof(WindowStyleFlags)) let style = (WindowStyleFlags) Enum.Parse(typeof(WindowStyleFlags), styleName) where (styles & style) == style select $"{styleName} (0x{(uint) style:X8})";

        private static IEnumerable<string> Convert(ExtendedWindowStyleFlags styles) =>
            from styleName in Enum.GetNames(typeof(ExtendedWindowStyleFlags)) let style = (ExtendedWindowStyleFlags) Enum.Parse(typeof(ExtendedWindowStyleFlags), styleName) where (styles & style) == style select $"{styleName} (0x{(uint) style:X8})";
    }
}