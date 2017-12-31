using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    class TableCustomerManage
    {
        public static SqlDataAdapter QueryCustomerInfoBySeller(string userName)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select * from TB_CustomerInfo where BelongsTo = '" + userName + "'";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();

            return sqlDataAdapter;
        }

        public static int AddCustomer(string archivingDate, 
            string contacts, string email, 
            string company, string website,
            string country, string address,
            string scope, string type, string demand,
            string telephone, string fax, string mobile, string msn, string skype, string linkin, string whatsapp, string twiter, string facebook,
            string comefrom, string belongsto,
            string remarks,
            string modify)
        {
            string sqlCmd = "insert into TB_CustomerInfo (" +
                "ArchivingTime, " +
                "Contacts, Email, " +
                "CompanyName, Website, " +
                "Country, Address, " +
                "BusinessScope, Type, Demand, " +
                "Telephone, FAX, Mobile, MSN, Skype, Linkin, Whatsapp, Twiter, Facebook, " +
                "ComeFrom, BelongsTo, " +
                "Remarks, " +
                "Modify) values ('" +
                archivingDate + "','" + 
                contacts + "','" + email + "','" + 
                company + "','" + website + "','" + 
                country + "','" + address + "','" +
                scope + "','" + type + "','" + demand + "','" +
                telephone + "','" + fax + "','" + mobile + "','" + msn + "','" + skype + "','" + linkin + "','" + whatsapp + "','" + twiter + "','" + facebook + "','" +
                comefrom + "','" + belongsto + "','" + 
                remarks + "','" + 
                modify + "')";
            return DatabaseHelper.ExecuteCommand(sqlCmd);
        }

        public static int AddFollowUpLog(string email, string company,
            int number, string dateTime, string state,
            string briefing, string content,
            string modify)
        {
            string sqlCmd = "insert into TB_CustomerFollowUpLogs (" +
                "Email, CompanyName, " +
                "Number, Time, State, " +
                "Briefing, Content, " +
                "Modify) Values ('" +
                email + "','" + company + "','" +
                number + "','" + dateTime + "','" + state + "','" +
                briefing + "','" + content + "','" +
                modify + "')";
            return DatabaseHelper.ExecuteCommand(sqlCmd);
        }
    }
}
