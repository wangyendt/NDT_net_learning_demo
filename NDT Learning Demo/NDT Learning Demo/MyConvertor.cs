using System;

namespace NDT_Learning_Demo
{
    public static class MyConvertor
    {
        unsafe public static UInt32 getaddress(byte[] b)
        {
            fixed (byte* p0 = b)
            {
                byte* p = p0;
                return (UInt32)p;
            }
        }

        public static int bytetoint(int v)
        {
            if (v >= UInt16.MaxValue / 2)
            {
                v = v - UInt16.MaxValue;
            }
            return v;
        }
    }
}