using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace MyWeb.Jobs
{
    public class JobListener : IJobListener
    {
        public string Name => "Test Job Listener";

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job vetoted: {context.JobDetail.Key}");
        }

        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job is to be executed: {context.JobDetail.Key}");
        }

        public async  Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job executed: {context.JobDetail.Key}");
        }
    }
}