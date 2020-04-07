using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecuteClient();
        }

        static void ExecuteClient()
        {
            try
            {
                string localTestIP = "192.168.0.36";
                IPAddress ipAddr = IPAddress.Parse(localTestIP);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 8888);

                Socket sender = new Socket(ipAddr.AddressFamily,
                            SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(localEndPoint);
                    Console.WriteLine("Socket connected to -> {0} ", sender.RemoteEndPoint.ToString());

                    byte[] messageSent = new byte[256];
                    
                    int byteSent = sender.Send(messageSent);

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0} ", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0} ", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected Exception : {0} ", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
