using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWeb.Jobs;
using MyWeb.Models;
using Quartz;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IScheduler _quartzScheduler;
        public HomeController(ILogger<HomeController> logger, IScheduler quartzScheduler)
        {
            _logger = logger;
            _quartzScheduler = quartzScheduler;
        }

        [HttpPost]
        public async Task<IActionResult> StartSimpleJob()
        {
            var job = JobBuilder.Create<SimpleJob>()
                // .UsingJobData("username", "devhow")
                // .UsingJobData("password", "Security!!")
                .WithIdentity("simplejob", "quartzexamples")
                .StoreDurably()
                .Build();

            job.JobDataMap.Put("user", new JobUserParameter { Username = "devhow", Password = "Security!!" });

            await _quartzScheduler.AddJob(job, true);
            var trigger = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerparam", "Simple trigger 1 parameter")
                .WithIdentity("testrigger", "quartexamples")
                // .StartNow()
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(22, 37))
                // .WithCronSchedule("0 0/1 * 1/1 * ? *")
                // .WithCalendarIntervalSchedule(x => 
                //     x.WithIntervalInDays(1)
                //     .PreserveHourOfDayAcrossDaylightSavings(true)
                //     .SkipDayIfHourDoesNotExist(true))
                // .WithDailyTimeIntervalSchedule(x => 
                //     x.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(21, 0))
                //     .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(22, 0))
                //     .OnDaysOfTheWeek(DayOfWeek.Thursday)
                //     .WithIntervalInSeconds(5))
                // .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever())
                .Build();

            // await _quartzScheduler.ScheduleJob(job, trigger);
            await _quartzScheduler.ScheduleJob(trigger);
            
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
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
