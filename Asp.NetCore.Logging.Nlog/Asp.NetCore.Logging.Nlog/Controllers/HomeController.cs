using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asp.NetCore.Logging.Nlog.Models;

namespace Asp.NetCore.Logging.Nlog.Controllers
{
    public class HomeController : Controller
    {
        //Burada benden bir kategory name istiyor. HomeController verirsek artık loglama yapacağı zaman bu ismi category name kullanacak.
        //private readonly ILogger<HomeController> _logger;

        //Peki ben custom bir category name vermek ister isem aşağya bakınız...
        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            //Ör/: Aşağıdaki informationLog bize outputta şu şekilde bir çıtı verir.
            //Asp.NetCore.Logging.Nlog.Controllers.HomeController: Information: Index Controller Enterance (NameSpace + CategoryName + Message)
            //Bu loglamayı hem IIS te çalışırken hemde console da çalışırken atar. 
            //_logger.LogInformation("Index Controller Enterance");


            //Önmeli Not: Loglamanın seviyeleri var bunun için appsettings.json dosyasındaki notları bakınız.
            //Önemli Not: Log providerlar ile ilgili ayarlar için Program.cs'e bakınız.
            //Önemli Not: Program.cs te loglama yapmak istersem nasıl yapıcam. Program.cs'e bakınız.
            //Önemli Not: StartUp'ta loglama yapıcam nasıl yaparım. Sturtup.cs'e bakınız.

            //_logger.LogWarning("Index Controller Enterance");
            //_logger.LogError("Index Controller Enterance");
            //_logger.LogCritical("Index Controller Enterance");
            //_logger.LogTrace("Index Controller Enterance");
            //_logger.LogDebug("Index Controller Enterance");

            var logger = _loggerFactory.CreateLogger("Home Sınıfı Loglama"); //Artık categoryName Home Sınıfı Loglama oldu.

            logger.LogTrace("Index Controller Enterance");
            logger.LogWarning("Index Controller Enterance");
            logger.LogError("Index Controller Enterance");
            logger.LogCritical("Index Controller Enterance");
            logger.LogDebug("Index Controller Enterance");
            logger.LogInformation("Index Controller Enterance");

            //Yukarıda ben birçok seviyede loglama yapsam dahi appsettings.js dosyasında default olarak belirlediğim seviye ve onun altını loglayacaktır.

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
