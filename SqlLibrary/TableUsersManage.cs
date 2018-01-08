using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    class TableUsersManage
    {
        public static SqlDataAdapter QueryUserName(string userName)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select * from TB_Users where Name = '" + userName + "'";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();

            return sqlDataAdapter;
        }

        public static SqlDataAdapter MatchUserAndPassword(string username, string password)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select Name, Password from TB_Users where Name='" + username + "' and Password='" + password + "'";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();

            return sqlDataAdapter;
        }

        public static int AddUserLoginLog(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName)
        {
            string sqlCmd = "insert into TB_LoginLogs (Name, Login, LoginLanIp, LoginHostName, LoginMac, LoginUserName) values ('" + userName + "','" + dateTime + "','" + lanIp + "','" + hostName + "','" + mac + "','" + sysUserName + "')";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int ModifyUserLastLoginLog(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName)
        {
            string sqlCmd = "update TB_Users set LastLogin = '" + dateTime + "', LastLoginLanIp = '" + lanIp + "', LastLoginMac = '" + mac + "', LastLoginHostName = '" + hostName + "', LastLoginUserName = '" + sysUserName + "' where Name = '" + userName +"'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
    }
}
