using Addresh_Book5th.Areas.LOC_City.Models;
using Addresh_Book5th.Areas.LOC_Country.Models;
using Addresh_Book5th.Areas.LOC_State.Models;
using Addresh_Book5th.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Addresh_Book5th.Areas.LOC_City.Controllers
{
    [Area("LOC_City")]
    [Route("LOC_City/{Controller}/{action}")]
    public class LOC_CityController : Controller
    {
        LOC_City_DAL dalLOC_City = new LOC_City_DAL();

        #region Configuration
        public IConfiguration Configuration;

        public  LOC_CityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region SelectAll
        public IActionResult Index(string? CountryName = null, string? StateName = null, string? CityName = null)
        {
            string myconnstr = this.Configuration.GetConnectionString("MyConnectingString");
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(myconnstr);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_SelectAll";
            cmd.Parameters.AddWithValue("CountryName", CountryName);
            cmd.Parameters.AddWithValue("StateName", StateName);
            cmd.Parameters.AddWithValue("CityName", CityName);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            sqlConnection.Close();
            return View("LOC_City_List", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CityID)
        {
            if (Convert.ToBoolean(dalLOC_City.PR_City_DeleteByPK(CityID)))
            {
                TempData["LOC_City_Delete_Message"] = "Record Deleted Successfully!!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            
            if (modelLOC_City.CityID == null)
            {
                DataTable dt = dalLOC_City.PR_City_Insert(modelLOC_City.CityName, modelLOC_City.CityCode, modelLOC_City.CountryID, modelLOC_City.StateID);
                TempData["LOC_City_Insert_Message"] = "Record Inserted Successfully!!";
            }
            else
            {
                DataTable dt = dalLOC_City.PR_City_UpdateByPK((int) modelLOC_City.CityID,modelLOC_City.CityName, modelLOC_City.CityCode, modelLOC_City.CountryID, modelLOC_City.StateID);
                TempData["LOC_City_Insert_Message"] = "Record Update Successfully!!";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CityID)
        {
            #region Country Dropdown
            string myconnStr2 = this.Configuration.GetConnectionString("MyConnectingString");
            SqlConnection connection2 = new SqlConnection(myconnStr2);
            DataTable dt2 = new DataTable();
            connection2.Open();

            SqlCommand cmd2 = connection2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "PR_LOC_Country_Dropdown";
            SqlDataReader reader2 = cmd2.ExecuteReader();
            dt2.Load(reader2);

            List<LOC_Country_DropdownModel> list1 = new List<LOC_Country_DropdownModel>();
            foreach (DataRow dr in dt2.Rows)
            {
                LOC_Country_DropdownModel dlist = new LOC_Country_DropdownModel();
                dlist.CountryID = Convert.ToInt32(dr["CountryID"]);
                dlist.CountryName = dr["CountryName"].ToString();
                list1.Add(dlist);
            }
            ViewBag.CountryList = list1;
            #endregion

            List<LOC_State_Dropdown> list_state = new List<LOC_State_Dropdown>();
            ViewBag.StateList = list_state;

            #region SelectByPK
            if (CityID != null)
            {
                DataTable dt = dalLOC_City.PR_City_SelectByPK(CityID);

                LOC_CityModel modelLOC_City = new LOC_CityModel();

                foreach (DataRow row in dt.Rows)
                {
                    modelLOC_City.CityID = Convert.ToInt32(row["CityID"]);
                    modelLOC_City.StateID = Convert.ToInt32(row["StateID"]);
                    modelLOC_City.CountryID = Convert.ToInt32(row["CountryID"]);
                    modelLOC_City.CityName = row["CityName"].ToString();
                    modelLOC_City.CityCode = row["CityCode"].ToString();
                }
                return View("LOC_City_AddEdit", modelLOC_City);
            }
            return View("LOC_City_AddEdit");
            #endregion
        }
        #endregion

        #region Cancle
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Cascade Dropdown
        public IActionResult StateDropDownByCountryID(int CountryID) {
            string myconnStr1 = this.Configuration.GetConnectionString("MyConnectingString");
            SqlConnection connection1 = new SqlConnection(myconnStr1);
            DataTable dt1 = new DataTable();
            connection1.Open();
            SqlCommand cmd1 = connection1.CreateCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "PR_LOC_State_DropdownByCountryID";
            cmd1.Parameters.AddWithValue("@CountryID", CountryID);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            dt1.Load(reader1);

            List<LOC_State_Dropdown> list = new List<LOC_State_Dropdown>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_State_Dropdown lstList = new LOC_State_Dropdown();
                lstList.StateID = Convert.ToInt32(dr["StateID"]);
                lstList.StateName = dr["StateName"].ToString();
                list.Add(lstList);
            }
            var vModel = list;
            return Json(vModel);

        }
        #endregion
    }
}
