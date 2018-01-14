using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    public class TableUsersManage
    {
        public static int AddUserAndReturnIdentity(string username, string password, string privilege, string nickname, string registime)
        {
            string sqlCmd = "insert into TB_Users (Name, Password, Privilege, Nickname, RegisTime) values ('" + username + "','" + password + "','" + privilege + "','" + nickname + "','" + registime + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int DeleteUserByUserName(string username)
        {
            string sqlCmd = "delete from TB_Users where Name = '" + username + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static DataTable QueryAllUsers()
        {
            string sqlCmd = "select * from TB_Users";                                            //编写SQL命令
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }
        public static DataTable QueryUserName(string userName)
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
            DataTable dataTable = new DataTable();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数

            return dataTable;
        }

        public static DataTable MatchUserAndPassword(string username, string password)
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

            DataTable dataTable = new DataTable();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数

            return dataTable;
        }

        public static int ModifyPassword(string userName, string nPassword)
        {
            string sqlCmd = "update TB_Users set Password = '" + nPassword + "' where Name = '" + userName + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int ModifyUserByUserName(string username, string password, string privilege, string nickname)
        {
            string sqlCmd = "update TB_Users set Password = '" + password + "', Privilege = '" + privilege + "', Nickname = '" + nickname + "' where Name = '" + username + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int AddUserLoginLogAndReturnIdentity(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName, int uid)
        {
            string sqlCmd = "insert into TB_LoginLogs (Name, Login, LoginLanIp, LoginHostName, LoginMac, LoginUserName, Uid) values ('" + userName + "','" + dateTime + "','" + lanIp + "','" + hostName + "','" + mac + "','" + sysUserName + "','" + uid + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int QueryAllLoginLogsNumber()
        {
            string sqlCmd = "select count (*) from TB_LoginLogs";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryAllLoginLogs()
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select * from TB_LoginLogs";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();
            DataTable dataTable = new DataTable();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数

            return dataTable;
        }

        public static DataTable QueryAllLoginLogsByPage(int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from TB_LoginLogs where Id not in (select top " + pages + " Id from TB_LoginLogs order by Id desc) order by Id desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static int QueryLoginLogsNumberByUserName(string userName)
        {
            string sqlCmd = "select count (*) from TB_LoginLogs where Name = '" + userName + "'";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryLoginLogsByUserNameAndPage(string userName, int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from TB_LoginLogs where Id not in (select top " + pages + " Id from TB_LoginLogs where Name = '" + userName + "' order by Id desc) and Name = '" + userName + "' order by Id desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static DataTable QueryLoginLogsByUserName(string userName)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select * from TB_LoginLogs where Name = '" + userName + "'";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();
            DataTable dataTable = new DataTable();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数

            return dataTable;
        }

        public static int ModifyUserLogoutById(string logout, int id)
        {
            string sqlCmd = "update TB_LoginLogs set Logout = '" + logout + "' where Id = '" + id + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int ModifyUserLastLoginLogByUserName(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName)
        {
            string sqlCmd = "update TB_Users set LastLogin = '" + dateTime + "', LastLoginLanIp = '" + lanIp + "', LastLoginMac = '" + mac + "', LastLoginHostName = '" + hostName + "', LastLoginUserName = '" + sysUserName + "' where Name = '" + userName +"'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
    }
}
