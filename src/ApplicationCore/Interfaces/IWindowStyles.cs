using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IWindowStyles
    {
        ICollection<string> StylesSetFlags { get; }
        ICollection<string> StylesExSetFlags { get; }
        bool HasSizingBorder { get; }
        bool IsChild { get; }
        bool IsPopup { get; }
        bool IsToolWindow { get; }
    }
}