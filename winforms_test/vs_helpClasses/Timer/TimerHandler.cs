using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

class TimerHandler
{
    public void create_setCallback_and_init_timer(System.Timers.Timer timer, int interval, ElapsedEventHandler elapsedCallback, bool autoReset, bool enabled)
    {
        timer = new System.Timers.Timer();
        timer.Interval = interval;
        timer.Elapsed += elapsedCallback;
        timer.AutoReset = autoReset;
        timer.Enabled = enabled;
    }
}
