using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ElectronNet.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Process> Processes { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Processes = Process
                            .GetProcesses()
                            .Where(p => !string.IsNullOrEmpty(p.ProcessName)
                                        //&& !p.ProcessName.Length
                                        )
                            .ToList();
        }
    }
}
