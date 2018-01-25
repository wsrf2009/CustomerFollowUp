using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlLibrary
{
    public class TableUsersManage
    {
        private const string TABLE_USERS = "users";
        private const string TABLE_LOGINLOGS = "loginlogs";

        #region 用户
        public static int AddUserAndReturnIdentity(string username, string password, string privilege, string nickname, string registime)
        {
            string sqlCmd = "insert into "+ TABLE_USERS + " (Name, Password, Privilege, Nickname, RegisTime) values ('" + username + "','" + password + "','" + privilege + "','" + nickname + "','" + registime + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int DeleteUserByUserName(string username)
        {
            string sqlCmd = "delete from "+ TABLE_USERS + " where Name = '" + username + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static DataTable QueryAllUsers()
        {
            string sqlCmd = "select * from " + TABLE_USERS;                                            //编写SQL命令
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static DataTable QueryUserByUserId(int uid)
        {
            string sqlCmd = "select * from " + TABLE_USERS + " where Id = " + uid;
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static DataTable QueryUserName(string userName)
        {
            string sqlCmd = "select * from "+ TABLE_USERS + " where Name = '" + userName + "'";                                            //编写SQL命令
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static int ModifyPassword(string userName, string nPassword)
        {
            string sqlCmd = "update "+ TABLE_USERS + " set Password = '" + nPassword + "' where Name = '" + userName + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int ModifyUserByUserName(string username, string password, string privilege, string nickname)
        {
            string sqlCmd = "update "+ TABLE_USERS + " set Password = '" + password + "', Privilege = '" + privilege + "', Nickname = '" + nickname + "' where Name = '" + username + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int ModifyNicknameByUserId(int uid, string nickname)
        {
            string sqlCmd = "update " + TABLE_USERS + " set Nickname = '" + nickname + "' where Id = " + uid;
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
        #endregion

        #region 用户登录日志
        public static int AddUserLoginLogAndReturnIdentity(string userName, string dateTime, string mac, string lanIp, string hostName, string sysUserName, int uid)
        {
            string sqlCmd = "insert into "+ TABLE_LOGINLOGS + " (Name, Login, LoginLanIp, LoginHostName, LoginMac, LoginUserName, Uid) values ('" + userName + "','" + dateTime + "','" + lanIp + "','" + hostName + "','" + mac + "','" + sysUserName + "','" + uid + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int QueryAllLoginLogsNumber()
        {
            string sqlCmd = "select count (*) from " + TABLE_LOGINLOGS;
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryAllLoginLogsByPage(int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from "+ TABLE_LOGINLOGS + " where Id not in (select top " + pages + " Id from "+ TABLE_LOGINLOGS + " order by Id desc) order by Id desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static int QueryLoginLogsNumberByUserName(string userName)
        {
            string sqlCmd = "select count (*) from "+ TABLE_LOGINLOGS + " where Name = '" + userName + "'";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryLoginLogsByUserNameAndPage(string userName, int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from "+ TABLE_LOGINLOGS + " where Id not in (select top " + pages + " Id from "+ TABLE_LOGINLOGS + " where Name = '" + userName + "' order by Id desc) and Name = '" + userName + "' order by Id desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static int ModifyUserLogoutById(string logout, int id)
        {
            string sqlCmd = "update "+ TABLE_LOGINLOGS + " set Logout = '" + logout + "' where Id = '" + id + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
#endregion
    }
}
