using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace MyWeb.Jobs
{
    public class TriggerListener : ITriggerListener
    {
        public string Name => "Test Trigger Listener";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Trigger Completed: {trigger.Key.Name}");
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Trigger Fired: {trigger.Key.Name}");
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine($"Trigger Misfired: {trigger.Key.Name}");
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
           return false;
        }
    }
}