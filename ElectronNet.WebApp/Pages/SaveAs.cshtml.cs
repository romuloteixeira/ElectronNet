using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ElectronNet.WebApp.Pages
{
    public class SaveAsModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(string path)
        {
            var writer = new System.IO.StringWriter();
            writer.WriteLine("Id, Process Name, Physical Memory");

            var items = Process
                            .GetProcesses()
                            .Where(p => !string.IsNullOrEmpty(p.ProcessName))
                            .ToList();
            items.ForEach(p =>
            {
                var processName = p.MainModule is not null
                                    ? p.MainModule.ModuleName
                                    : p.ProcessName;
                var text = $"{p.Id}, {processName}, {p.WorkingSet64}";
                writer.WriteLine(text);
            });

            await System.IO.File.WriteAllTextAsync(path, writer.ToString());
            return RedirectToPage("Index");
        }
    }
}
