using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace ElectronNet.WebApp.Pages
{
    public class DrivesModel : PageModel
    {
        public DrivesModel()
        {
            AllDrives = DriveInfo.GetDrives();
        }

        public DriveInfo[] AllDrives { get; set; }

        public void OnGet()
        {
        }
    }
}
