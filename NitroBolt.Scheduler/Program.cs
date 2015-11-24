using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace NitroBolt.Scheduler
{

    class Scheduler
    {
        public void Start()
        {
        }
        public void Stop()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                
            {
                x.Service<Scheduler>(s =>
                {
                    s.ConstructUsing(name => new Scheduler());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.StartAutomaticallyDelayed();
                x.RunAsLocalSystem();

                x.SetDescription("NitroBolt.Scheduler");
                x.SetDisplayName("NitroBolt.Scheduler");
                x.SetServiceName("NitroBolt.Scheduler");

                x.EnableServiceRecovery(r =>
                 {
                     r.OnCrashOnly();
                     r.RestartService(1);
                     r.SetResetPeriod(1);
                 }
                );
            });                                                       

        }
    }
}
