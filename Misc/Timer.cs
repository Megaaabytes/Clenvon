using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Clenvon.Misc
{
    public class Timer
    {
        private bool timerActive = false;
        private Time finalTime;

        public void StartTimer()
        {
            timerActive = true;
            Thread timerThread = new Thread(new ThreadStart(timer));
            timerThread.Start();
        }

        public string StopTimer()
        {
            timerActive = false;
            return $"{finalTime.s}.{finalTime.ms}";
        }

        private void timer()
        {
            if(timerActive == true)
            {
                double ms = 0;
                double seconds = 0;

                while (true)
                {
                    ms++;
                    if(ms == 1000)
                    {
                        ms -= 1000;
                        seconds = seconds + 1.0;
                    }
                    if(timerActive == false)
                    {
                        break;
                    }
                    finalTime = new Time(ms, seconds);
                    Thread.Sleep(1);
                }
            }
        }

        private struct Time
        {
            public double ms { get; }
            public double s { get; }

            public Time(double ms, double s)
            {
                this.ms = ms;
                this.s = s;
            }
        }
    }
}
