using System;
using System.Windows.Forms;

namespace NDT_Learning_Demo
{
    public static class MyDelay
    {
        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
        }
    }
}