using System;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;

namespace MyWeb.Jobs
{
    public class AspnetCoreJobFactory : SimpleJobFactory
    {
        readonly IServiceProvider _provider;
        public AspnetCoreJobFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob) _provider.GetService(bundle.JobDetail.JobType);
            }
            catch (Exception)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from Asp net core IOC", bundle.JobDetail.Key));
            }
        }
    }
}