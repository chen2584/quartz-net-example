using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MyWeb.Models;
using Quartz;

namespace MyWeb.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            var triggerParam = dataMap.GetString("triggerparam");
            // var dataMap = context.JobDetail.JobDataMap;
            // var username = dataMap.GetString("username");
            // var password = dataMap.GetString("password");
            var user = (JobUserParameter) dataMap.Get("user");


            var message = $"Simple executed with username: {user.Username} and password: {user.Password} with triggeredparam: {triggerParam}";
            Debug.WriteLine(message);
        }
    }
}