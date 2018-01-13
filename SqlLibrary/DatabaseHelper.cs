using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    public class DatabaseHelper
    {
        public static SqlConnection CreateDatabaseHandler()
        {
            SqlConnection sqlConnection = 
                new SqlConnection("server=localhost;database=DB_CustomerFollowUp;uid=sa;pwd=xuanxuan123");
            return sqlConnection;
        }

        ///  执行指定的SQL命令语句(insert,delete,update等),并返回命令所影响的行数
        public static int ExecuteNonQuery(string sqlStr)
        {
            int succNum = -1;

            Console.WriteLine("sqlStr:" + sqlStr);

            SqlConnection sqlConnection = CreateDatabaseHandler(); //创建数据库连接(字符串中是我个人的数据库信息)
            sqlConnection.Open();      //打开数据库连接
            SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);  //执行SQL命令
            succNum = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return succNum;
        }

        public static object ExecuteScalar(string sqlStr)
        {
            object identity = -1;

            Console.WriteLine("sqlStr:" + sqlStr);

            SqlConnection sqlConnection = CreateDatabaseHandler(); //创建数据库连接(字符串中是我个人的数据库信息)
            sqlConnection.Open();      //打开数据库连接
            SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);  //执行SQL命令
            identity = sqlCommand.ExecuteScalar();

            sqlConnection.Close();

            return identity;
        }

        public static DataTable ExecuteSqlCommand(string sqlCmd)
        {
            SqlConnection sqlConnection = CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            sqlCommand.CommandText = sqlCmd;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();
            DataTable dataTable = new DataTable();                     //实例化结果数据集
            int n = sqlDataAdapter.Fill(dataTable);              //将结果放入数据适配器，返回元祖个数

            return dataTable;
        }

        // 查询(select)指定的数据（单个数据,假设为string类型）,并返回
        public static DataSet QueryData(string sqlStr)
        {
            SqlConnection sqlConnection = CreateDatabaseHandler();
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStr, sqlConnection);//利用已创建好的sqlConnection1,创建数据适配器sqlDataAdapter1
            DataSet dataSet = new DataSet();  //创建数据集对象
            sqlDataAdapter.Fill(dataSet);    //执行查询,查询的结果存放在数据集里

            sqlConnection.Close();

            return dataSet;
            //return dataSet.Tables[0].Rows[0]["列名"].ToString(); //把查询结果的第一行指定列下的数据以string类型返回
        }
    }
}
