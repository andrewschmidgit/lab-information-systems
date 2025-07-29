using System;

namespace LIS.LIS01A2.Interfaces
{
	public interface ILis01A2Connection
	{
		void ClearBuffers();
		void Connect();
		void DisConnect();
		void WriteData(string value);
		event EventHandler<LISConnectionReceivedDataEventArgs> OnReceiveString;
	}
}
