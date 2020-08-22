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
            //var host = CreateHostBuilder(args).Build(); //Bana Host bilgisi d�ner.
            //var logger = host.Services.GetRequiredService<ILogger<Program>>(); //Host bilgisinden servislerden ihtiyac�m olan�n instancesini bana verir.
            //logger.LogInformation("Proje Aya�a Kalk�yor....."); //Output tan g�zlemleyebilirsin.

            //host.Run(); //Tabiki run etmem laz�m...


            CreateHostBuilder(args).Build().Run();
        }


        //Default olarak gelen console, debug ve eventSource porvider'�n hesi kalk�yor. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging(logging =>
                    {

                        //Default olarak gelen t�m providerlar� kald�r�r. Art�k yapt���n hi�bir logu output ta g�remezsin.
                        logging.ClearProviders();

                        //Custom oalrak hangi providerlar�n eklenmesini istiyorsak ekleyebiliriz.
                        logging.AddDebug();

                    }).UseNLog();

                    //Nlog kullan�ca��m� yukar�daki gibi belirtiyorum...
                });
    }
}
