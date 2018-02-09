using System.Runtime.InteropServices;

namespace NDT_Learning_Demo
{
    public static class MySendKey
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event")]

        private static extern void keybd_event(
            byte bVk, //虚拟键值  
            byte bScan,// 一般为0  
            int dwFlags, //这里是整数类型 0 为按下，2为释放  
            int dwExtraInfo //这里是整数类型 一般情况下设成为0  
        );

        public static void keyPress(byte key)
        {
            if (key == 0)
            {
                return;
            }
            keybd_event(key, 0, 0, 0);
            keybd_event(key, 0, 2, 0);
        }

        public static void keyDown(byte key)
        {
            if (key == 0)
            {
                return;
            }
            keybd_event(key, 0, 0, 0);
        }

        public static void keyUp(byte key)
        {
            if (key == 0)
            {
                return;
            }
            keybd_event(key, 0, 2, 0);
        }
    }
}