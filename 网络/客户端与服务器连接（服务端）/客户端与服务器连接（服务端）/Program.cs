using System;
using System.Net;
using System.Net.Sockets;


namespace 客户端与服务器连接_服务端_
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Socket listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //bind
            IPAddress ipadr = IPAddress.Parse("127.0.0.1");
            IPEndPoint IPEnd = new IPEndPoint(ipadr, 8888);
            listenfd.Bind(IPEnd);
            //监听
            listenfd.Listen(0);
            Console.WriteLine("服务器启动成功");
            while (true)
            {
                //Accept
                Socket connectfd = listenfd.Accept();
                Console.WriteLine("服务器accept");
                //接收
                byte[] readBuff = new byte[1024];
                int count = connectfd.Receive(readBuff);
                string readStr = System.Text.Encoding.Default.GetString(readBuff, 0, count);
                Console.WriteLine("服务器接收" + readStr);
                byte[] sendBytes = System.Text.Encoding.Default.GetBytes(readStr);
                connectfd.Send(sendBytes);
            }
        }
        
    }
}
