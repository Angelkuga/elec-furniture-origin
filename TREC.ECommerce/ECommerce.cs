using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TREC.ECommerce
{
    public class ECommerce
    {
        public static DataTable GetTable(string sql)
        {
            try
            {
                return TREC.Data.DbHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
            }
            catch (Exception err)
            {
                return new DataTable();
            }
        }
        public static DataSet GetDataSet(string sql)
        {
            try
            {
                return TREC.Data.DbHelper.ExecuteDataset(CommandType.Text, sql);
            }
            catch (Exception err)
            {
                return new DataSet();
            }
        }
    }
}
