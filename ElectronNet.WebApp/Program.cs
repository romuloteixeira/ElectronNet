using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ElectronNET.API;

namespace ElectronNet.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //todo: Electron
                    webBuilder.UseElectron(args);
                    //todo: Electron
                    webBuilder.UseEnvironment("Development");


                    webBuilder.UseStartup<Startup>();
                });
    }
}
