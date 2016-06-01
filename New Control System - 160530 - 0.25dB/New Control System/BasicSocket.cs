using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace NetSocket
{
    public  class TimeOutSocket
    {
        private  bool IsConnectionSuccessful = false;
        private  Exception socketexception;
        private  ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        public  TcpClient tcpclient;

        public string Saved_IP = "";

        public   Boolean Connect(IPEndPoint remoteEndPoint, int timeoutMSec)
        {
            try
            {
                TimeoutObject.Reset();
                socketexception = null;


                string serverip = Convert.ToString(remoteEndPoint.Address);
                int serverport = remoteEndPoint.Port;
                tcpclient = new TcpClient();

                tcpclient.BeginConnect(serverip, serverport,
                    new AsyncCallback(CallBackMethod), tcpclient);

                if (TimeoutObject.WaitOne(timeoutMSec, false))
                {
                    if (IsConnectionSuccessful)
                    {
                        Saved_IP = serverip;
                        return true;
                    }
                    else
                    {
                        return false;
                        throw socketexception;

                    }
                }
                else
                {
                    tcpclient.Close();
                    System.GC.Collect();
                    throw new TimeoutException("TimeOut Exception");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }



        private  void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                IsConnectionSuccessful = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    IsConnectionSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                IsConnectionSuccessful = false;
                socketexception = ex;
            }
            finally
            {
                TimeoutObject.Set();
            }
        }
    }

}
