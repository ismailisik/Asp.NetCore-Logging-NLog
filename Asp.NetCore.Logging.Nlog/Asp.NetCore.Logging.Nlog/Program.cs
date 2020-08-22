using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Asp.NetCore.Logging.Nlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build(); //Bana Host bilgisi döner.
            //var logger = host.Services.GetRequiredService<ILogger<Program>>(); //Host bilgisinden servislerden ihtiyacým olanýn instancesini bana verir.
            //logger.LogInformation("Proje Ayaða Kalkýyor....."); //Output tan gözlemleyebilirsin.

            //host.Run(); //Tabiki run etmem lazým...


            CreateHostBuilder(args).Build().Run();
        }


        //Default olarak gelen console, debug ve eventSource porvider'ýn hesi kalkýyor. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging(logging =>
                    {

                        //Default olarak gelen tüm providerlarý kaldýrýr. Artýk yaptýðýn hiçbir logu output ta göremezsin.
                        logging.ClearProviders();

                        //Custom oalrak hangi providerlarýn eklenmesini istiyorsak ekleyebiliriz.
                        logging.AddDebug();

                    }).UseNLog();

                    //Nlog kullanýcaðýmý yukarýdaki gibi belirtiyorum...
                });
    }
}
