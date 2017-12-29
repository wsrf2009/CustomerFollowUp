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
        public static int ExecuteCommand(string sqlStr)
        {
            int succNum = -1;

            Console.WriteLine("sqlStr:"+sqlStr);

            //try
            //{
                SqlConnection sqlConnection = CreateDatabaseHandler(); //创建数据库连接(字符串中是我个人的数据库信息)
                sqlConnection.Open();      //打开数据库连接
                SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);  //执行SQL命令
                succNum = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Console.WriteLine("succNum:"+succNum);

            return succNum;
        }

        // 查询(select)指定的数据（单个数据,假设为string类型）,并返回
        public static string QueryData(string sqlStr)
        {
            SqlConnection sqlConnection1 = new SqlConnection("server=dell-PC;database=11071312HotelSys;uid=sa;pwd=xiaoyi9421");//创建数据库连接
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlStr, sqlConnection1);//利用已创建好的sqlConnection1,创建数据适配器sqlDataAdapter1
            DataSet dataSet1 = new DataSet();  //创建数据集对象
            sqlDataAdapter1.Fill(dataSet1);    //执行查询,查询的结果存放在数据集里
            return dataSet1.Tables[0].Rows[0]["列名"].ToString(); //把查询结果的第一行指定列下的数据以string类型返回
        }
    }
}
