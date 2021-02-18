using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Window;

namespace ApplicationCore.Services
{
    public class WindowService
    {
        private readonly IWindowFactory _factory;

        public WindowService(IWindowFactory factory)
        {
            _factory = factory;
        }
        
        public IReadOnlyCollection<WindowModel> GetWindows()
        {
            return _factory.GetWindows(WindowFilter.NormalWindow)
                .Select(x => new WindowModel(x)).ToList();
        }
    }
}