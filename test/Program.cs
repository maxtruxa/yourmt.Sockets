using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using yourmt.Sockets;

namespace test
{
    class Program
    {
        static void Main(String[] args)
        {
            while(true)
            {
                try
                {
                    Console.Write("Download file: ");
                    String www = Console.ReadLine();
                    www = www.Trim();
                    if(www.StartsWith("http://"))
                        www = www.Substring(7, www.Length - 7);

                    Int32 hostdelim = www.IndexOf('/');
                    String host = www.Substring(0, (hostdelim == -1) ? (www.Length) : (hostdelim));
                    String uri;
                    if(hostdelim == -1)
                        uri = "/";
                    else
                        uri = www.Substring(hostdelim, www.Length - hostdelim);

                    String http = "GET " + uri + " HTTP/1.0\r\n" +
                                  "Host: " + host + "\r\n" +
                                  "\r\n";

                    using(Socket cli = new Socket(AddressFamily.Inet, SocketType.Stream, ProtocolType.Tcp))
                    {
                        cli.Connect(host, 80);

                        cli.Send(http);

                        Byte[] buffer = new Byte[4096];

                        using(FileStream writer = File.OpenWrite("test.html"))
                        {
                            while(true)
                            {
                                Int32 len = cli.Receive(buffer);
                                if(!cli.IsConnected)
                                    break;

                                //Console.Write();
                                writer.Write(buffer, 0, len);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
