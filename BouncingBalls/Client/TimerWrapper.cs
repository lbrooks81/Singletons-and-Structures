using System.Timers;
using Timer = System.Timers.Timer;

namespace BouncingBalls.Client
{
	public class TimerWrapper : Timer
	{
        private DateTime m_dueTime;

        public TimerWrapper(int time) : base(time) => this.Elapsed += this.ElapsedAction!;

        protected new void Dispose()
        {
            this.Elapsed -= this.ElapsedAction!;
            base.Dispose();
        }

        public double TimeLeft => (this.m_dueTime - DateTime.Now).TotalMilliseconds;

        public new void Start()
        {
            this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
            base.Start();
        }

        private void ElapsedAction(object sender, ElapsedEventArgs e)
        {
            if (this.AutoReset)
            {
                this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
            }
        }
    }
}
