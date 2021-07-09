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
            ProcessArguments = window.GetCommandLine();
        }

        public int ProcessId { get; }
        public string ProcessArguments { get; }
        public string Handle { get; }
        public string ProcessName { get; }
        public string ClassName { get; }
        public string Title { get; }
    }
}