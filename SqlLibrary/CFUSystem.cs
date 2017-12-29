using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    public class CFUSystem
    {
        public static bool QueryUserName(string userName)
        {
            SqlDataAdapter sqlDataAdapter = TableUsersManage.QueryUserName(userName);
            DataSet dataSet = new DataSet();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataSet);              //将结果放入数据适配器，返回元祖个数
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Login(string username, string password)
        {
            SqlDataAdapter sqlDataAdapter = TableUsersManage.MatchUserAndPassword(username, password);
            DataSet dataSet = new DataSet();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataSet);              //将结果放入数据适配器，返回元祖个数
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddLoginLog(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName)
        {
            int sucNum = TableUsersManage.AddUserLoginLog(userName, dateTime, mac, lanIp, hostName, sysUserName);
            if(sucNum > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool ModifyLastLoginLog(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName)
        {
            int sucNum = TableUsersManage.ModifyUserLastLoginLog(userName, dateTime, mac, lanIp, hostName, sysUserName);
            if (sucNum > 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static DataSet QueryCustomerInfoBySellerName(string userName)
        {
            SqlDataAdapter sqlDataAdapter = TableCustomerManage.QueryCustomerInfoBySeller(userName);
            DataSet dataSet = new DataSet();
            int n = sqlDataAdapter.Fill(dataSet, "TB_CustomerInfo");
            Console.WriteLine("n:"+n);
            return dataSet;
        }
    }
}
