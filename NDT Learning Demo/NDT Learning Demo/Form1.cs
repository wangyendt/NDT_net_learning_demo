using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NDT_Learning_Demo
{
    public partial class Form1 : Form
    {
        private Thread _thrdCollectData;
        private Thread _thrdReadData;
        private bool _bCollectStop;
        private bool _bReadStop;
        private CheckBox[] _chboKey;
        private StringBuilder[] _sbSave = new StringBuilder[8];
        private Matrix _matW1;
        private Matrix _matB1;
        private Matrix _matW2;
        private Matrix _matB2;
        private int _prepreKey = 0;
        private int _preKey = 0;
        private int _curKey = 0;
        private int _lastFinalKey = 0;
        private int _curFinalKey = 0;
        private byte[] _keyValue = { 0, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };
        private byte[] _keyValueLower = { 0, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };

        public Form1()
        {
            InitializeComponent();
        }

        void ReadLearnedParams()
        {
            string path = ".\\learned_params\\";
            double[,] dW1 = ReadDoubleFromFile.Read(path + "W1", "\t");
            double[,] dB1 = ReadDoubleFromFile.Read(path + "B1", "\t");
            double[,] dW2 = ReadDoubleFromFile.Read(path + "W2", "\t");
            double[,] dB2 = ReadDoubleFromFile.Read(path + "B2", "\t");
            _matW1 = new Matrix(dW1);
            _matB1 = new Matrix(dB1);
            _matW2 = new Matrix(dW2);
            _matB2 = new Matrix(dB2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            _chboKey = new[] { chbo0, chbo1, chbo2, chbo3, chbo4, chbo5, chbo6, chbo7 };
            for (int i = 0; i < _sbSave.Length; i++)
            {
                _sbSave[i] = new StringBuilder();
            }
            ReadLearnedParams();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bCollectStop = true;
            IICoperation.IICDeInit();
            if (_thrdCollectData != null)
            {
                ShowLog("Aborting thread...", Color.Green);
                _thrdCollectData.Abort();
            }
            if (_thrdReadData != null)
            {
                ShowLog("Aborting thread...", Color.Green);
                _thrdReadData.Abort();
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (_thrdCollectData != null)
            {
                if (_thrdCollectData.IsAlive)
                {
                    //                    ShowLog("Aborting thread...", Color.Green);
                    _thrdCollectData.Abort();
                    IICoperation.IICDeInit();
                    btnCollect.Text = "Collect";
                    return;
                }
            }
            btnCollect.Text = "Pause";
            bool b1 = IICoperation.IICInit();
            MyDelay.Delay(10);
            bool b2 = IICoperation.StartNDTModule();
            MyDelay.Delay(10);
            if (!b1 || !b2)
            {
                return;
            }
            _thrdCollectData = new Thread(KeepCollectingData);
            _thrdCollectData.Start();
        }


        private void KeepCollectingData()
        {
            while (!_bCollectStop)
            {
                Thread.Sleep(10);
                byte[] iicwb = new byte[32];
                byte[] iicrb = new byte[32];
                uint wlen;
                uint rlen;

                iicwb[0] = 0xA0;
                iicwb[1] = 0x61;
                wlen = 2;
                rlen = 1;
                int maxcount = 100;
                int readNum;
                while (maxcount-- >= 0)
                {
                    IICoperation.IICWriteRead(0, wlen, MyConvertor.getaddress(iicwb), rlen,
                        MyConvertor.getaddress(iicrb));
                    readNum = iicrb[0];
                    if (readNum != 0)
                    {
                        break;
                    }
                }

                iicwb[0] = 0xA0;
                List<int> signal = new List<int>();
                StringBuilder sbSignal = new StringBuilder();
                StringBuilder sbSave = new StringBuilder();
                for (int i = 0; i < 9; i++)    // 9个sensor的signal
                {
                    iicwb[1] = (byte)(0x62 + i);
                    wlen = 2;
                    rlen = 2;
                    IICoperation.IICWriteRead(0, wlen, MyConvertor.getaddress(iicwb), rlen,
                        MyConvertor.getaddress(iicrb));
                    int value = MyConvertor.bytetoint((iicrb[1] << 8) | iicrb[0]);
                    if (i == 8)
                    {
                        value = 0;
                    }
                    signal.Add(value);
                    sbSignal.Append(value + "\t");
                    BeginInvoke(new EventHandler(delegate
                     {
                         sbSave.Append(value + "\t");
                     }));
                }
                sbSignal.Append("\n");

                if (signal.Max() > 0)
                {
                    if (_chboKey.ToList().Any(x => x.Checked))
                    {
                        int idkey = _chboKey.ToList().FindIndex(x => x.Checked);
                        _sbSave[idkey].Append(sbSignal);
                    }
                }
                BeginInvoke(new EventHandler(delegate
                {
                    sbSave.Append("\r\n");
                    //rtbLog.AppendText(sbSave.ToString());
                    ////                    //                    rtbLog.AppendText("\r\n");
                    ////                    //                    //                    rtbLog.Focus();
                    //rtbLog.SelectionLength = rtbLog.TextLength;
                    //rtbLog.ScrollToCaret();
                }));
            }
        }


        private void ShowLog(string s, Color color)
        {
            Invoke(new EventHandler(delegate
            {
                //                rtbLog.Focus();
                int textlen = rtbLog.TextLength;
                rtbLog.AppendText(">>> " + s + "\r\n");
                rtbLog.Select(textlen, rtbLog.TextLength);
                rtbLog.SelectionColor = color;
                rtbLog.Select(rtbLog.TextLength, rtbLog.TextLength);
                rtbLog.ScrollToCaret();
            }));
        }

        private void chbo1_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo1.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo1.Checked = b;
        }

        private void chbo2_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo2.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo2.Checked = b;
        }

        private void chbo3_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo3.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo3.Checked = b;
        }

        private void chbo4_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo4.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo4.Checked = b;
        }

        private void chbo5_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo5.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo5.Checked = b;
        }

        private void chbo6_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo6.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo6.Checked = b;
        }

        private void chbo7_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo7.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo7.Checked = b;
        }

        private void chbo0_MouseClick(object sender, MouseEventArgs e)
        {
            bool b = chbo0.Checked;
            _chboKey.ToList().ForEach(x => x.Checked = false);
            chbo0.Checked = b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _sbSave.Length; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(_sbSave[i].ToString());
                using (FileStream fs = new FileStream(".\\data\\key" + i + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        private void rtbLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                MessageBox.Show("a");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_thrdReadData != null)
            {
                if (_thrdReadData.IsAlive)
                {
                    //                    ShowLog("Aborting thread...", Color.Green);
                    _thrdReadData.Abort();
                    IICoperation.IICDeInit();
                    btnStart.Text = "Start";
                    return;
                }
            }
            btnStart.Text = "Pause";
            bool b1 = IICoperation.IICInit();
            MyDelay.Delay(10);
            bool b2 = IICoperation.StartNDTModule();
            MyDelay.Delay(10);
            if (!b1 || !b2)
            {
                return;
            }
            LoadKeyValue();
            _thrdReadData = new Thread(KeepReadingData);
            _thrdReadData.Start();
        }

        private void LoadKeyValue()
        {
            CallPython.RunPythonScript(".\\set_piano_key.py");
            try
            {
                string[] strKeyValues = File.ReadAllLines(".\\settings\\value.config");
                for (int i = 1; i < _keyValue.Length; i++)
                {
                    string[] strValues = strKeyValues[0]
                        .Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    _keyValue[i] = Convert.ToByte(strValues[i - 1], 16);
                }
                for (int i = _keyValue.Length + 1; i < 2 * _keyValue.Length; i++)
                {
                    string[] strValues = strKeyValues[0]
                        .Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    //rtbRes.AppendText(strValues.Length + "\t" + (i - _keyValue.Length) + "\t" + (i - 1 + _keyValue.Length) + "\t" + i + "\r\n");
                    _keyValueLower[i - _keyValue.Length] = Convert.ToByte(strValues[i -2], 16);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void KeepReadingData()
        {
            while (!_bReadStop)
            {
                Thread.Sleep(10);
                byte[] iicwb = new byte[32];
                byte[] iicrb = new byte[32];
                uint wlen;
                uint rlen;

                StringBuilder sb = new StringBuilder();

                iicwb[0] = 0xA0;
                iicwb[1] = 0x61;
                wlen = 2;
                rlen = 1;
                int maxcount = 100;
                int readNum;
                while (maxcount-- >= 0)
                {
                    IICoperation.IICWriteRead(0, wlen, MyConvertor.getaddress(iicwb), rlen,
                        MyConvertor.getaddress(iicrb));
                    readNum = iicrb[0];
                    if (readNum != 0)
                    {
                        break;
                    }
                }

                iicwb[0] = 0xA0;
                List<double> signal = new List<double>();
                for (int i = 0; i < 9; i++)    // 9个sensor的signal
                {
                    iicwb[1] = (byte)(0x62 + i);
                    wlen = 2;
                    rlen = 2;
                    IICoperation.IICWriteRead(0, wlen, MyConvertor.getaddress(iicwb), rlen,
                        MyConvertor.getaddress(iicrb));
                    int value = MyConvertor.bytetoint((iicrb[1] << 8) | iicrb[0]);
                    if (i == 8)
                    {
                        //                        value = 0;
                    }
                    sb.Append(value + "\t");
                    signal.Add(value);
                    BeginInvoke(new EventHandler(delegate
                    {
                        //                        rtbRes.AppendText(value + "\t");
                    }));
                }


                if (signal.Max() > 18)
                {
                    double[,] dSignal = new double[1, 9];
                    for (int i = 0; i < dSignal.GetLength(1); i++)
                    {
                        dSignal[0, i] = signal[i] / signal.Max();
                    }
                    Matrix matSignal = new Matrix(dSignal);
                    double[] retSig = new double[signal.Count];
                    Matrix matA1 = Matrix.tanh(matSignal * _matW1 + _matB1);
                    Matrix matA2 = Matrix.exp(matA1 * _matW2 + _matB2);
                    retSig = matA2.SpecRow(0);
                    for (int i = 0; i < retSig.Length; i++)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            //rtbRes.AppendText(_matW1[0,i] + "\t");
                        }));
                    }
                    var maxindList = retSig.ToList().Select((m, index) => new[] { m, index }).OrderByDescending(n => n[0])
                        .Take(1).ToList();
                    int key = (int)maxindList[0][1];
                    _curKey = key;
                    int a = _curKey - _preKey;
                    int b = _preKey - _prepreKey;
                    int c = _prepreKey - _curKey;
                    if (a * b * c != 0)
                    {
                        _curFinalKey = 0;
                    }
                    else
                    {
                        if (a == 0 || b == 0)
                        {
                            _curFinalKey = _preKey;
                        }
                        else
                        {
                            _curFinalKey = _curKey;
                        }
                    }
                    if (_curFinalKey == 0)
                    {
                        MySendKey.keyUp(_keyValueLower[_lastFinalKey]);
                        MySendKey.keyUp(_keyValue[_lastFinalKey]);
                    }
                    else
                    {
                        if (_lastFinalKey != _curFinalKey)
                        {
                            MySendKey.keyUp(_keyValue[_lastFinalKey]);
                            MySendKey.keyDown(_keyValue[_curFinalKey]);
                            //if (signal.Max() <= 100)
                            //{
                            //    MySendKey.keyUp(_keyValueLower[_lastFinalKey]);
                            //    MySendKey.keyUp(_keyValue[_lastFinalKey]);
                            //    MySendKey.keyDown(_keyValueLower[_curFinalKey]);
                            //}
                            //else
                            //{
                            //    MySendKey.keyUp(_keyValueLower[_lastFinalKey]);
                            //    MySendKey.keyUp(_keyValue[_lastFinalKey]);
                            //    MySendKey.keyDown(_keyValue[_curFinalKey]);
                            //}
                        }
                    }
                }
                else
                {
                    _curKey = 0;
                    _curFinalKey = 0;
                    //MySendKey.keyUp(_keyValueLower[_lastFinalKey]);
                    MySendKey.keyUp(_keyValue[_lastFinalKey]);
                }
                _prepreKey = _preKey;
                _preKey = _curKey;
                _lastFinalKey = _curFinalKey;
                //                rtbRes.AppendText(_curKey + "\t" + _preKey + "\t" + _prepreKey + "\t");
                //                rtbRes.AppendText(_curFinalKey + "\t" + _lastFinalKey + "\t");
                BeginInvoke(new EventHandler(delegate
                {
                    //                    rtbRes.AppendText("\r\n");
                    sb.Append("\r\n");
                    //rtbRes.AppendText(sb.ToString());
                    ////                    //                    rtbRes.Focus();
                    //rtbRes.SelectionLength = rtbLog.TextLength;
                    //rtbRes.ScrollToCaret();
                }));
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            CallPython.RunPythonScript(".\\preprocess.py");
            CallPython.RunPythonScript(".\\ndt_net.py");
            ReadLearnedParams();
        }
    }
}
