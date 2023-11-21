using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Addresh_Book5th.Areas.MST_Student.Models;
using Addresh_Book5th.Areas.LOC_City.Models;
using Addresh_Book5th.Areas.MST_Branch.Models;
using Addresh_Book5th.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Addresh_Book5th.Areas.MST_Student.Controllers
{
    [Area("MST_Student")]
    [Route("MST_Student/{Controller}/{action}")]
    public class MST_StudentController : Controller
    {
        MST_StudentDAL dalMST_Studnet = new MST_StudentDAL();

        #region Configuration
        public IConfiguration Configuration;

        public MST_StudentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region SelectAll

        public IActionResult Index(string? StudentName, string? BranchName, string? CityName, bool filter = false)
        {
            string myconnstr = this.Configuration.GetConnectionString("MyConnectingString");
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(myconnstr);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (Convert.ToBoolean(filter))
            {
                cmd.CommandText = "PR_Student_Filter";
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                cmd.Parameters.AddWithValue("@BranchName", BranchName);
                cmd.Parameters.AddWithValue("@CityName", CityName);
            }
            else
            {
                cmd.CommandText = "PR_MST_Student_SelectAll";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            sqlConnection.Close();
            return View("MST_Student_List", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StudentID)
        {
            if (Convert.ToBoolean(dalMST_Studnet.PR_MST_Student_DeleteByPK(StudentID)))
            {
                TempData["MST_Student_Delete_Message"] = "Record Deleted Successfully!!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert
        public IActionResult Save(MST_StudentModel modelMST_Studnet)
        {

            if (modelMST_Studnet.File != null)
            {
                string FilePath = "wwwroot\\Images";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelMST_Studnet.File.FileName);
                modelMST_Studnet.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelMST_Studnet.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelMST_Studnet.File.CopyTo(stream);
                }
            }


            if (modelMST_Studnet.StudentID == null)
            {
                DataTable dt = dalMST_Studnet.PR_MST_Student_Insert(
                    modelMST_Studnet.StudentName, modelMST_Studnet.PhotoPath, modelMST_Studnet.BranchID, modelMST_Studnet.CityID
                    , modelMST_Studnet.Email, modelMST_Studnet.MobileNoStudent, modelMST_Studnet.MobileNoFather, modelMST_Studnet.Address
                    , modelMST_Studnet.BirthDate, modelMST_Studnet.Age, modelMST_Studnet.IsActive, modelMST_Studnet.Gender, modelMST_Studnet.Password);
                TempData["MST_Student_Insert_Message"] = "Record Inserted Successfully!!";
            }
            else
            {
                DataTable dt = dalMST_Studnet.PR_MST_Student_UpdateByPK(modelMST_Studnet.StudentID, modelMST_Studnet.StudentName, modelMST_Studnet.PhotoPath, modelMST_Studnet.BranchID, modelMST_Studnet.CityID
                    , modelMST_Studnet.Email, modelMST_Studnet.MobileNoStudent, modelMST_Studnet.MobileNoFather, modelMST_Studnet.Address
                    , modelMST_Studnet.BirthDate, modelMST_Studnet.Age, modelMST_Studnet.IsActive, modelMST_Studnet.Gender, modelMST_Studnet.Password);
                TempData["MST_Student_Insert_Message"] = "Record Update Successfully!!";

            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? StudentID)
        {
            #region City Dropdown
            string myconnStr1 = this.Configuration.GetConnectionString("MyConnectingString");
            SqlConnection connection1 = new SqlConnection(myconnStr1);
            DataTable dt1 = new DataTable();
            connection1.Open();
            SqlCommand cmd1 = connection1.CreateCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "PR_LOC_City_Dropdown";
            SqlDataReader reader1 = cmd1.ExecuteReader();
            dt1.Load(reader1);

            List<LOC_City_Dropdown> list = new List<LOC_City_Dropdown>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_City_Dropdown lstList = new LOC_City_Dropdown();
                lstList.CityID = Convert.ToInt32(dr["CityID"]);
                lstList.CityName = dr["CityName"].ToString();
                list.Add(lstList);
            }
            ViewBag.CityList = list;
            #endregion

            #region Branch Dropdown
            string myconnStr2 = this.Configuration.GetConnectionString("MyConnectingString");
            SqlConnection connection2 = new SqlConnection(myconnStr2);
            DataTable dt2 = new DataTable();
            connection2.Open();

            SqlCommand cmd2 = connection2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "PR_MST_Branch_Dropdown";
            SqlDataReader reader2 = cmd2.ExecuteReader();
            dt2.Load(reader2);

            List<MST_Branch_Dropdown> list1 = new List<MST_Branch_Dropdown>();
            foreach (DataRow dr in dt2.Rows)
            {
                MST_Branch_Dropdown dlist = new MST_Branch_Dropdown();
                dlist.BranchID = Convert.ToInt32(dr["BranchID"]);
                dlist.BranchName = dr["BranchName"].ToString();
                list1.Add(dlist);
            }
            ViewBag.BranchList = list1;
            #endregion

            #region SelectByPK
            if (StudentID != null)
            {
                DataTable dt = dalMST_Studnet.PR_MST_Student_SelectByPK(StudentID);

                MST_StudentModel modelMST_Student = new MST_StudentModel();
                foreach (DataRow row in dt.Rows)
                {
                    modelMST_Student.StudentID = Convert.ToInt32(row["StudentID"]);
                    modelMST_Student.CityID = Convert.ToInt32(row["CityID"]);
                    modelMST_Student.BranchID = Convert.ToInt32(row["BranchID"]);
                    modelMST_Student.StudentName = row["StudentName"].ToString();
                    modelMST_Student.PhotoPath = row["PhotoPath"].ToString();
                    modelMST_Student.MobileNoStudent = row["MobileNoStudent"].ToString();
                    modelMST_Student.MobileNoFather = row["MobileNoFather"].ToString();
                    modelMST_Student.Email = row["Email"].ToString();
                    modelMST_Student.Address = row["Address"].ToString();
                    modelMST_Student.BirthDate = Convert.ToDateTime(row["BirthDate"]);
                    modelMST_Student.Age = Convert.ToInt32(row["Age"]);
                    modelMST_Student.IsActive = row["IsActive"].ToString();
                    modelMST_Student.Gender = row["Gender"].ToString();
                    modelMST_Student.Password = row["Password"].ToString();
                }
                return View("MST_StudentAddEdit", modelMST_Student);
            }
            return View("MST_StudentAddEdit");
            #endregion
        }
        #endregion

        #region Cancle
        public IActionResult Cancle()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region ViewProfile
        public IActionResult ViewProfile(int StudentID)
        {
            string myconnstr = this.Configuration.GetConnectionString("MyConnectingString");
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(myconnstr);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Student_SelectByPK";
            cmd.Parameters.AddWithValue("@StudentID", StudentID);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            sqlConnection.Close();
            return View("View_Profile", dt);
        }
        #endregion

    }
}
