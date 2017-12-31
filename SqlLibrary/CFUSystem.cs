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

        public static bool AddCustomer(string archivingDate,
            string contacts, string email,
            string company, string website,
            string country, string address,
            string scope, string type, string demand,
            string telephone, string fax, string mobile, string msn, string skype, string linkin, string whatsapp, string twiter, string facebook,
            string comefrom, string belongsto,
            string remarks,
            string modify)
        {
            int suc = TableCustomerManage.AddCustomer(archivingDate, 
                contacts, email,
                company, website,
                country, address, 
                scope, type, demand,
                telephone, fax, mobile, msn, skype, linkin, whatsapp, twiter, facebook,
                comefrom, belongsto, 
                remarks, modify);
            if (suc > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool AddFollowUpLog(string email, string company,
            int number, string dateTime, string state,
            string briefing, string content,
            string modify)
        {
            int suc = TableCustomerManage.AddFollowUpLog(email, company,
                number, dateTime, state,
                briefing, content,
                modify);
            if (suc > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
