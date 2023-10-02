using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Addresh_Book5th.DAL
{
    public class LOC_State_DALBase : DAL_Helper
    {
        #region PR_LOC_State_SelectAll()
        public DataTable PR_LOC_State_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_State_SelectAll");
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_LOC_State_DeleteByPk
        public bool? PR_LOC_State_DeleteByPk(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_State_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_LOC_State_SelectByPK
        public DataTable PR_LOC_State_SelectByPK(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_State_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
        }
        #endregion

        #region PR_LOC_State_Insert
        public DataTable PR_LOC_State_Insert(string StateName, string StateCode,int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_State_Insert");
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.VarChar, CountryID);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_LOC_State_UpdateByPK
        public DataTable PR_LOC_State_UpdateByPK(int StateID,string StateName, string StateCode, int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_State_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.VarChar, StateID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.VarChar, StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.VarChar, CountryID);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
