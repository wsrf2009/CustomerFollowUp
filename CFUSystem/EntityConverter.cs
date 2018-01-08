using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CFUManageSystem
{
    public static class EntityConverter
    {
        /// <summary>
        /// 生成表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static Func<DataRow, T> ToExpression<T>(this DataRow dataRow) where T : class, new()
        {
            if (dataRow == null) throw new ArgumentNullException("dataRow", "当前对象为null 无法转换成实体");
            ParameterExpression paramter = Expression.Parameter(typeof(DataRow), "dr");
            List<MemberBinding> binds = new List<MemberBinding>();
            for (int i = 0; i < dataRow.ItemArray.Length; i++)
            {
                String colName = dataRow.Table.Columns[i].ColumnName;
                PropertyInfo pInfo = typeof(T).GetProperty(colName);
                if (pInfo == null) continue;
                MethodInfo mInfo = typeof(DataRowExtensions).GetMethod("Field", new Type[] { typeof(DataRow), typeof(String) }).MakeGenericMethod(pInfo.PropertyType);
                MethodCallExpression call = Expression.Call(mInfo, paramter, Expression.Constant(colName, typeof(String)));
                MemberAssignment bind = Expression.Bind(pInfo, call);
                binds.Add(bind);
            }
            MemberInitExpression init = Expression.MemberInit(Expression.New(typeof(T)), binds.ToArray());
            return Expression.Lambda<Func<DataRow, T>>(init, paramter).Compile();
        }
    }
}
