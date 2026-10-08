using System;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp2
{
    class MyThread
    {
        Thread t;
        volatile bool running = false;
        int x = 0;
        Form1 form;
        static BooleanSwitch logSwitch = new BooleanSwitch("LogSwitch", "Naplozas be/ki");
        public delegate void DrawDelegate(int x);
        DrawDelegate draw;
        Func<int> width;

        public MyThread(DrawDelegate draw, Func<int> width)
        {
            this.draw = draw;
            this.width = width;
        }

        public void Start()
        {
            if (t == null || !t.IsAlive)
            {
                running = true;
                t = new Thread(Run);
                t.Start();
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void Run()
        {
            while (running)
            {
                draw(x);
                if (x < form.ClientSize.Width - 100)
                {
                    x += 5;
                }
                else
                {
                    x = 0;
                }
                Trace.WriteLineIf(logSwitch.Enabled, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - x: " + x);
                Thread.Sleep(100);
            }
        }
    }
}