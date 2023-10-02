using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Addresh_Book5th.DAL
{
    public class MST_Branch_DALBase : DAL_Helper
    {
        #region PR_MST_Branch_SelectAll
        public DataTable PR_MST_Branch_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Branch_SelectAll");
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

        #region PR_MST_Branch_DeleteByPK
        public bool? PR_MST_Branch_DeleteByPK(int? BranchID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Branch_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_MST_Branch_SelectByPK
        public DataTable PR_MST_Branch_SelectByPK(int? BranchID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Branch_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);

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

        #region PR_MSR_Branch_Insert
        public DataTable PR_MSR_Branch_Insert(string BranchName, string BranchCode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MSR_Branch_Insert");
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.VarChar, BranchName);
                sqlDB.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, BranchCode);

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

        #region PR_MST_Branch_UpdateByPK
        public DataTable PR_MST_Branch_UpdateByPK(int? BranchID, string BranchName, string BranchCode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Branch_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.Int, BranchName);
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.VarChar, BranchName);
                sqlDB.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, BranchCode);

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
