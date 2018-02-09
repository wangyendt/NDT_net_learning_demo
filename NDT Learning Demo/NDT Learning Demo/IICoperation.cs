using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NDT_Learning_Demo
{
    public static class IICoperation
    {
        [DllImport("USBIOX.DLL")]
        private static extern UInt32 USBIO_OpenDevice(UInt32 iIndex);

        [DllImport("USBIOX.DLL")]
        private static extern UInt32 USBIO_CloseDevice(UInt32 iIndex);

        [DllImport("USBIOX.DLL")]
        private static extern bool USBIO_SetStream(UInt32 iIndex, UInt32 iMode);

        [DllImport("USBIOX.DLL")]
        private static extern bool USBIO_StreamI2C(UInt32 iIndex, UInt32 iWriteLength, UInt32 iWriteBuffer,
            UInt32 iReadLength, UInt32 oReadBuffer);

        private static byte[] _IIcWriteBuffer = new byte[256];
        private static byte[] _IIcReadBuffer = new byte[256];
        private static bool _bIICOpened;

        private static uint INVALID_HANDLE_VALUE = 0xFFFFFFFF;
        public enum Reg
        {
            REG_HOST_STATUS = 0x50,

            REG_DEBUG_MODE = 0x60,
            REG_DATA_READY = 0x61,
            REG_DEBUG_DATA1 = 0x62,
            REG_DEBUG_DATA2 = 0x63,
            REG_DEBUG_DATA3 = 0x64,
            REG_DEBUG_DATA4 = 0x65,
            REG_DEBUG_DATA5 = 0x66,
            REG_DEBUG_DATA6 = 0x67,
            REG_DEBUG_DATA7 = 0x68,
            REG_DEBUG_DATA8 = 0x69,
            REG_DEBUG_DATA9 = 0x6A,
            REG_DEBUG_DATA10 = 0x6B,
            REG_DEBUG_DATA11 = 0x6C,
            REG_DEBUG_DATA12 = 0x6D,
            REG_DEBUG_DATA13 = 0x6E,
            REG_DEBUG_DATA14 = 0x6F,

            REG_DEBUG_MODEB = 0x80,
            REG_DATA_READYB = 0x81,
            REG_DEBUG_DATAB = 0x82,

            REG_DEBUG_MODEC = 0x83,
            REG_DATA_READYC = 0x84,
            REG_DEBUG_DATAC = 0x85,

            REG_POINTER_NUMBER = 0x10,
            REG_POINTER1_DATA = 0x11,
            REG_FORCE_DATA_NUMBER = 0x20,
            REG_FORCE_DATA1 = 0x21,

            REG_DEVICE_ID = 0x02,
            REG_MANUFACTURER_ID = 0x03,
            REG_MODULE_ID = 0x04,
            REG_FW_VERSION = 0x05,

            REG_TASK_ENABLE = 0x0A,

            REG_TEST_REG = 0x1F,

            REG_UART_PRINT_ENABLE = 0xD4
        }

        private enum Host
        {
            HOST_STATUS_NORMAL = 0x00
        }

        private enum DataReady
        {
            DATA_READY_CLEAR = 0x00
        }

        private enum DebugMode
        {
            DEBUG_MODE_OFF = 0x00,
            DEBUG_MODE_RAWDATA_OUT = 0x01,
            DEBUG_MODE_AFE_INFO = 0x04,
            DEBUG_MODE_RAED_PARAMETER = 0x06,
            DEBUG_MODE_DIRECTLY_PARAMETER = 0x08,
            DEBUG_MODE_WRITE_CAL_DATA_CHANNEL = 0x0A,
            DEBUG_MODE_READ_CAL_DATA_CHANNEL = 0x0B,
            DEBUG_MODE_RAWDATA_CRC16 = 0x10,
            DEBUG_MODE_NOISE_CALCULATE = 0x11,
            DEBUG_MODE_RAWDATA_COUNT_CRC16 = 0x21,
            DEBUG_MODE_ADCRAWDATA_COUNT_CRC16 = 0x22,
            DEBUG_MODE_RAWDATA_COUNT_FRAMES_CRC16 = 0x23,
            DEBUG_MODE_ADCRAWDATA_COUNT_FRAMES_CRC16 = 0x24
        }


        public static unsafe byte[] getbytes(UInt32 address, int iReadLength)
        {
            byte* p = (byte*)address;
            byte[] ret = new byte[iReadLength];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = *(p + i);
            }
            return ret;
        }


        public static bool IICInit()
        {
            if (_bIICOpened)
            {
                return false;
            }

            uint val_Handle;
            try
            {
                val_Handle = USBIO_OpenDevice(0);
            }
            catch
            {
                MessageBox.Show("Please check if the file \"USBIOX.DLL\" and \"usbio.dll\" are in the root directory!");
                return false;
            }
            if (val_Handle == INVALID_HANDLE_VALUE || val_Handle == 0)
            {
                MessageBox.Show("IIC detected failed!");
                return false;
            }
            USBIO_SetStream(0, 0x81);
            _bIICOpened = true;
            return true;
        }

        public static void IICDeInit()
        {
            if (_bIICOpened)
            {
                USBIO_CloseDevice(0);
                _bIICOpened = false;
            }
        }

        public static bool IICWriteRead(UInt32 iIndex, UInt32 iWriteLength, UInt32 iWriteBuffer, UInt32 iReadLength,
            UInt32 iReadBuffer)
        {
            bool bResult = USBIO_StreamI2C(iIndex, iWriteLength, iWriteBuffer, iReadLength, iReadBuffer);

            return bResult;
        }

        public static bool StartNDTModule()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODE;
            _IIcWriteBuffer[2] = 0x41;

            return IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static byte QueryDataReady()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READY; //0x61;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 1, MyConvertor.getaddress(_IIcReadBuffer));

            return _IIcReadBuffer[0];
        }

        public static void WriteDataReady(byte value)
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READY; // 0x61;
            _IIcWriteBuffer[2] = value;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static byte[] GetRawdata(byte chnl)
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = chnl;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 2, MyConvertor.getaddress(_IIcReadBuffer));

            return _IIcReadBuffer;
        }
    }
}