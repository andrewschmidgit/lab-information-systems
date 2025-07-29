using System;

namespace LIS.LIS01A2
{
    public class LISConnectionReceivedDataEventArgs : EventArgs
    {
        public string ReceivedData { get; set; }

        public LISConnectionReceivedDataEventArgs(string aDataLine)
        {
            ReceivedData = aDataLine;
        }
    }
}