using ElectronNET.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ElectronNET.API;
using ElectronNET.API.Entities;
using System.Runtime.InteropServices;
using System.Linq;

namespace ElectronNet.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            //todo: Electron
            if (HybridSupport.IsElectronActive)
            {
                CreateWindow();
            }
        }

        private void CreateMenu()
        {
            //var isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            //MenuItem[] menu = null;

            //var appMenu = new MenuItem[]
            //{
            //    new MenuItem{ Role = MenuRole.about},
            //    new MenuItem{ Type = MenuType.separator},
            //    new MenuItem{ Role = MenuRole.services},
            //    new MenuItem{ Type = MenuType.separator},
            //    new MenuItem{ Role = MenuRole.hide},
            //    new MenuItem{ Role = MenuRole.hideothers},
            //    new MenuItem{ Role = MenuRole.unhide},
            //    new MenuItem{ Type = MenuType.separator},
            //    new MenuItem{ Role = MenuRole.quit},
            //};

            //var fileMenu = new MenuItem[]
            //{
            //    new MenuItem { Label = "Save As...", Type = MenuType.normal, Click = async () => {
            //        var mainWindow = Electron.WindowManager.BrowserWindows.First();
            //        var options = new SaveDialogOptions
            //        {
            //            Filters = new FileFilter[]
            //            {
            //                new FileFilter{Name= "CSV Files", Extensions = new string.}
            //            }
            //        };
            //    } 
            //    },
            //};
        }


        private async void CreateWindow()
        {
            CreateMenu();
            var window = await Electron.WindowManager.CreateWindowAsync();
            window.OnClosed += () =>
            {
                Electron.App.Quit();
            };
        }
    }
}
