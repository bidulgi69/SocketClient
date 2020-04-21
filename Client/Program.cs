using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

                    //byte[] messageSent = Encoding.ASCII.GetBytes("J&HPRESS  JSKJ-200  ");
                    //int intVal = 27;

                    byte[] message = new byte[512];
                    byte[] headers = Encoding.ASCII.GetBytes("J&HPRESS  JSJK-200  ");
                    int[] nums = { 27, 30, 13, 3 };
                    Buffer.BlockCopy(headers, 0, message, 0, headers.Length);
                    Buffer.BlockCopy(nums, 0, message, 20, nums.Length);

                    sender.Send(message);

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