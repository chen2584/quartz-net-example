using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace MyWeb.Jobs
{
    public class SchedulerListener : ISchedulerListener
    {
        public async Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Added: {jobDetail.Key.Name}");
        }

        public async Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Deleted: {jobKey}");
        }

        public async Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Interrupted: {jobKey}");
        }

        public async Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Paused: {jobKey}");
        }

        public async Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Resumed: {jobKey}");
        }

        public async Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Scheduled: {trigger.Key.Name}");
        }

        public async Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Group Paused: {jobGroup}");
        }

        public async Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Group Resumed: {jobGroup}");
        }

        public async Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Job Unscheduled: {triggerKey}");
        }

        public async Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Scheduler Error: {msg}");
        }

        public async Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulerInStandbyMode");
        }

        public async Task SchedulerShutdown(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulerShutdown");
        }

        public async Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulerShuttingdown");
        }

        public async Task SchedulerStarted(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulerStarted");
        }

        public async Task SchedulerStarting(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulerStarting");
        }

        public async Task SchedulingDataCleared(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"SchedulingDataCleared");
        }

        public async Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"TriggerFinalized: {trigger.Key.Name}");
        }

        public async Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"TriggerPaused: {triggerKey.Name}");
        }

        public async Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"TriggerResumed: {triggerKey.Name}");
        }

        public async Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"TriggersPaused Group: {triggerGroup}");
        }

        public async Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"TriggersResumed Group: {triggerGroup}");
        }
    }
}