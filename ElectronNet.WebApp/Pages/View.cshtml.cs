using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ElectronNet.WebApp.Pages
{
    public class ViewModel : PageModel
    {
        public ViewModel()
        {
            Properties = new string[]
            {
                "Id",
                "ProcessName",
                "PriorityClass",
                "WorkingSet64",
            };
        }

        public Process Process { get; set; }
        public string[] Properties { get; set; }

        public async Task<ActionResult> OnGet(int? id)
        {
            if (id.HasValue)
            {
                var t = Process.GetProcessById(id.Value);
                Process = t;
            }

            if (Process is null)
            {
                return NotFound();
            }

            const string message = "Are you sure you want to kill this process?";
            var options = new MessageBoxOptions(message);
            options.Type = MessageBoxType.question;
            options.Buttons = new string[2] { "No", "Yes" };
            options.DefaultId = 1;
            options.CancelId = 0;
            var resul = await Electron.Dialog.ShowMessageBoxAsync(options);

            if (resul.Response.Equals(1))
            {
                Process.Kill();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
