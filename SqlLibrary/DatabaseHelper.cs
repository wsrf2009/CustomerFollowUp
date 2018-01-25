using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlLibrary
{
    public class DatabaseHelper
    {
        public static SqlConnection CreateDatabaseHandler()
        {
            //SqlConnection sqlConnection = 
            //    new SqlConnection("server=localhost;database=DB_CustomerFollowUp;uid=sa;pwd=xuanxuan123");
            string sql = "Data Source=192.168.0.100;Initial Catalog=cfudb;Persist Security Info=True;User ID=sa;Password=1QAZ2wsx";
            SqlConnection sqlConnection = new SqlConnection(sql);
            return sqlConnection;
        }

        ///  执行指定的SQL命令语句(insert,delete,update等),并返回命令所影响的行数
        public static int ExecuteNonQuery(string sqlStr)
        {

            int succNum = -1;
            //try
            //{
                Console.WriteLine("sqlStr:" + sqlStr);

                SqlConnection sqlConnection = CreateDatabaseHandler(); //创建数据库连接(字符串中是我个人的数据库信息)
                sqlConnection.Open();      //打开数据库连接
                SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);  //执行SQL命令
                succNum = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return succNum;

        }

        public static object ExecuteScalar(string sqlStr)
        {
            object identity = -1;
            //try
            //{
                Console.WriteLine("sqlStr:" + sqlStr);

                SqlConnection sqlConnection = CreateDatabaseHandler(); //创建数据库连接(字符串中是我个人的数据库信息)
                sqlConnection.Open();      //打开数据库连接
                SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);  //执行SQL命令
                identity = sqlCommand.ExecuteScalar();

                sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return identity;
        }

        public static DataTable ExecuteSqlCommand(string sqlCmd)
        {
            DataTable dataTable = null;
            //try
            //{
                SqlConnection sqlConnection = CreateDatabaseHandler();
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
                sqlCommand.CommandText = sqlCmd;                           //执行SQL命令
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
                {
                    SelectCommand = sqlCommand                       //让适配器执行SELECT命令
                };       //实例化数据适配器
                sqlConnection.Close();
                dataTable = new DataTable();                     //实例化结果数据集
                int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return dataTable;
        }
    }
}
