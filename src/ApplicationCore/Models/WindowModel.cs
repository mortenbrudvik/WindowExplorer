using ApplicationCore.Interfaces;

namespace ApplicationCore.Models
{
    public class WindowModel
    {
        public WindowModel(IWindow window)
        {
            Handle = window.Handle.ToString();
            Title = window.Title;
            ClassName = window.ClassName;
            ProcessName = window.ProcessName;
            ProcessId = window.ProcessId;
        }

        public int ProcessId { get; set; }

        public string Handle { get; set; }

        public string ProcessName { get; set; }

        public string ClassName { get; set; }

        public string Title { get; set; }
    }
}