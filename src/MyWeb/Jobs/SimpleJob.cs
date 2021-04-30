using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MyWeb.Models;
using MyWeb.Services;
using Quartz;

namespace MyWeb.Jobs
{
    public class SimpleJob : IJob
    {
        readonly IEmailService _emailService;
        public SimpleJob(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // var dataMap = context.MergedJobDataMap;
            // var triggerParam = dataMap.GetString("triggerparam");
            // // var dataMap = context.JobDetail.JobDataMap;
            // // var username = dataMap.GetString("username");
            // // var password = dataMap.GetString("password");
            // var user = (JobUserParameter) dataMap.Get("user");


            // var message = $"Simple executed with username: {user.Username} and password: {user.Password} with triggeredparam: {triggerParam}";
            // Debug.WriteLine(message);
            _emailService.Send("info@devhow.net", "DI", "dependecy injection in quartz job");
        }
    }
}