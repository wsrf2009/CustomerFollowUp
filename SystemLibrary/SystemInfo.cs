using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace SystemLibrary
{
    public class SystemInfo
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        public static string GetMac()
        {
            StringBuilder macAddress = new StringBuilder();

            try
            {
                string remoteIP = string.Empty;
                Int32 remote = inet_addr(remoteIP);

                Int64 macInfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macInfo, ref length);

                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();

                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "-");
                    }
                    x -= 2;
                }

                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }
    
        public static string GetLanIp()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static string GetWanIp()
        {
            string wanIp = string.Empty;
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
                wr.Timeout = 3000;
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.UTF8);
                string all = sr.ReadToEnd(); //读取网站的数据
                Console.WriteLine("all:"+all);
                int start = all.IndexOf("您的IP地址是：[") + 9;
                int end = all.IndexOf("]", start);
                wanIp = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return wanIp;
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetUserName()
        {
            return Environment.UserName;
        }
    }
}
