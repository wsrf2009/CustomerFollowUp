using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    public class TableCustomerManage
    {
        #region 客户信息
        public static int AddCustomerReturnIdentity(string archivingDate, string email, string belongsTo)
        {
            string sqlCmd = "insert into TB_CustomerInfo (" +
                "ArchivingTime, Email, BelongsTo) values ('" +
                archivingDate + "', '" + email + "','" + belongsTo + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int DeleteCustomerById(int id)
        {
            string sqlCmd = "delete from TB_CustomerInfo where Id = '" + id + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static int QueryAllCustomerNumber()
        {
            string sqlCmd = "select count (*) from TB_CustomerInfo";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryCustomerByPage(int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from TB_CustomerInfo where Id not in (select top " + pages + " Id from TB_CustomerInfo order by LastFollowUpTime desc) order by LastFollowUpTime desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static DataSet QueryCustomerInfoBySeller(string userName)
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

            DataSet dataSet = new DataSet();
            int n = sqlDataAdapter.Fill(dataSet, "TB_CustomerInfo");

            return dataSet;
        }

        public static int QueryCustomerNumberByUserName(string userName)
        {
            string sqlCmd = "select count (*) from TB_CustomerInfo where BelongsTo = '" + userName + "'";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static DataTable QueryCustomerByUserNameAndPage(string userName, int page, int pageSize)
        {
            if (page < 1) page = 1;
            int pages = pageSize * (page - 1);

            string sqlCmd = "select top " + pageSize + " * from TB_CustomerInfo where Id not in (select top " + pages + " Id from TB_CustomerInfo where BelongsTo = '" + userName + "' order by LastFollowUpTime desc) and BelongsTo = '" + userName + "' order by LastFollowUpTime desc";
            return DatabaseHelper.ExecuteSqlCommand(sqlCmd);
        }

        public static int ModifyCustomerInfoById(int id,
            string sort,
            string contacts, string email,
            string company, string website,
            string country, string address,
            string scope, string type, string demand,
            string telephone, string fax, string mobile, string msn, string skype, string linkin, string whatsapp, string twiter, string facebook,
            string comefrom,
            string usedBrands, string decisionMaker, string reactionAcuity, string religion, string charaterTraits,
            string amountStratification, string normalCommunication, string normalPayment, string customerSize,
            string deliveryTimeSensitivity, string loyalty, string productFactors,
            string remarks,
            string  modify)
        {
            string sqlCmd = "update TB_CustomerInfo set " +
                "Sort = '" + sort + "', " +
                "Contacts = '" + contacts + "', Email = '" + email + "', " +
                "CompanyName = '" + company + "', Website = '" + website + "', " +
                "Country = '" + country + "', Address = '" + address + "', " +
                "BusinessScope = '" + scope + "', Type = '" + type + "', Demand = '" + demand + "', " +
                "Telephone = '" + telephone + "', FAX = '" + fax + "', Mobile = '" + mobile + "', MSN = '" + msn + "', Skype = '" + skype + "', Linkin = '" + linkin + "', Whatsapp = '" + whatsapp + "', Twiter = '" + twiter + "', Facebook = '" + facebook + "', " +
                "ComeFrom = '" + comefrom + "', " +
                "UsedBrands = '" + usedBrands + "', DecisionMaker = '" + decisionMaker +"', " +
                "NewProductRecommendReactionAcuity = '" + reactionAcuity + "', " +
                "Religion = '" + religion + "', CharacterTraits = '" + charaterTraits + "', " +
                "AmountStratification = '" + amountStratification + "', " +
                "NormalCommunication = '" + normalCommunication + "', " +
                "NormalPayment = '" + normalPayment + "', CustomerSize = '" + customerSize + "', " +
                "DeliveryTimeSensitivity = '" + deliveryTimeSensitivity + "', Loyalty = '" + loyalty + "', " +
                "ProductFactors = '" + productFactors + "', " +
                "Remarks = '" + remarks + "', " +
                "Modify = '" + modify + "' where id = '" + id + "'";

            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
        #endregion

        #region 客户跟进记录
        public static int AddFollowUpLogReturnIdentity(string email, string company, int customerId,
            int number, string  dateTime, string state,
            string briefing, string content,
            string modify, string seller)
        {
            string sqlCmd = "insert into TB_CustomerFollowUpLogs (" +
                "Email, CompanyName, CustomerInfoId, " +
                "Number, Time, State, " +
                "Briefing, Content, " +
                "Modify, BelongsTo) Values ('" +
                email + "','" + company + "','" + customerId + "','" +
                number + "','" + dateTime + "','" + state + "','" +
                briefing + "','" + content + "','" +
                modify + "','" + seller + "'); select @@Identity";
            object obj = DatabaseHelper.ExecuteScalar(sqlCmd);
            return Convert.ToInt32(obj);
        }

        public static int DeleteFollowUpLogById(int id)
        {
            string sqlCmd = "delete from TB_CustomerFollowUpLogs where Id = '" + id + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }

        public static SqlDataAdapter QueryFollowUpLogsByEmail(string email)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         //创建SQL命令执行对象
            string s1 = "select * from TB_CustomerFollowUpLogs where Email = '" + email + "'";                                            //编写SQL命令
            sqlCommand.CommandText = s1;                           //执行SQL命令
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand                       //让适配器执行SELECT命令
            };       //实例化数据适配器
            sqlConnection.Close();

            return sqlDataAdapter;
        }

        public static DataSet QueryFollowUpLogsByCustomerId(int customerId)
        {
            SqlConnection sqlConnection = DatabaseHelper.CreateDatabaseHandler();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string s1 = "select * from TB_CustomerFollowUpLogs where CustomerInfoId = '" + customerId + "'";
            sqlCommand.CommandText = s1;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = sqlCommand
            };
            sqlConnection.Close();

            DataSet dataSet = new DataSet();
            int n = sqlDataAdapter.Fill(dataSet, "TB_CustomerFollowUpLogs");

            return dataSet;
        }

        public static int ModifyFollowUpLogById(int id,
            string email, string company, int customerId,
            int number, string state,
            string briefing, string content,
            string modify, string seller)
        {
            string sqlCmd = "update TB_CustomerFollowUpLogs set " +
                "Email = '" + email + "', CompanyName = '" + company + "', CustomerInfoId = '" + customerId + "', " +
                "Number = '" + number + "', State = '" + state + "', " +
                "Briefing = '" + briefing + "', Content = '" + content + "', " +
                "Modify = '" + modify + "', BelongsTo = '" + seller + "' where id = '" + id + "'";
            return DatabaseHelper.ExecuteNonQuery(sqlCmd);
        }
        #endregion
    }
}
