using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace daTimer
{
 
    public partial class StreamTimer : Form
    {
        System.Timers.Timer timer;
        int h, m, s, ms;


        private void startBTN_Click_1(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void stopBTN_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            timer.Stop();
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            zeldaTime.Text = "00:00:00:00";
            splatoonTimer.Text = "00:00:00:00";
            
        }

        private void zeldaBTN_Click(object sender, EventArgs e)
        {
            zeldaTime.Visible = true;
            splatoonTimer.Visible = false;
            
        }

        private void splatoonBTN_Click(object sender, EventArgs e)
        {
            zeldaTime.Visible = false;
            splatoonTimer.Visible = true;
            
        }


        private void StreamTimer_Load_1(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        public StreamTimer()
        {
            InitializeComponent();
        } 


        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() => {
                ms += 1;
                if (ms == 100)
                {
                    ms = 0;
                    s += 1;
                }
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                zeldaTime.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().ToString().PadLeft(2,'0'), m.ToString().ToString().PadLeft(2, '0'), s.ToString().ToString().PadLeft(2, '0'), ms.ToString().ToString().PadLeft(2, '0'));
                splatoonTimer.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().ToString().PadLeft(2, '0'), m.ToString().ToString().PadLeft(2, '0'), s.ToString().ToString().PadLeft(2, '0'), ms.ToString().ToString().PadLeft(2, '0'));
               
            }));
        }
    }
}
