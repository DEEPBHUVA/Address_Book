using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Addresh_Book5th.DAL
{
    public class MST_StudentDALBase : DAL_Helper
    {
        #region PR_MST_Student_SelectAll
        public DataTable PR_MST_Student_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectAll");
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

        #region PR_MST_Student_DeleteByPK
        public bool? PR_MST_Student_DeleteByPK(int? StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);
                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_MST_Student_SelectByPK
        public DataTable PR_MST_Student_SelectByPK(int? StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);

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

        #region PR_MST_Student_Insert
        public DataTable PR_MST_Student_Insert(string StudentName, string PhotoPath, int BranchID, 
            int CityID, string Email, string MobileNoStudent, string MobileNoFather, string Address, DateTime BirthDate,
            int Age, string IsActive, string Gender, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Insert");
                sqlDB.AddInParameter(dbCMD, "StudentName", SqlDbType.VarChar, StudentName);
                sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, MobileNoStudent);
                sqlDB.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, MobileNoFather);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDB.AddInParameter(dbCMD, "Age", SqlDbType.Int, Age);
                sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.VarChar, IsActive);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, Gender);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

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

        #region PR_MST_Student_UpdateByPK
        public DataTable PR_MST_Student_UpdateByPK(int? StudentID,string StudentName, string PhotoPath, int BranchID,
            int CityID, string Email, string MobileNoStudent, string MobileNoFather, string Address, DateTime BirthDate,
            int Age, string IsActive, string Gender, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, StudentID);
                sqlDB.AddInParameter(dbCMD, "StudentName", SqlDbType.VarChar, StudentName);
                sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.VarChar, PhotoPath);
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, BranchID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, MobileNoStudent);
                sqlDB.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, MobileNoFather);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, BirthDate);
                sqlDB.AddInParameter(dbCMD, "Age", SqlDbType.Int, Age);
                sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.VarChar, IsActive);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, Gender);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

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
