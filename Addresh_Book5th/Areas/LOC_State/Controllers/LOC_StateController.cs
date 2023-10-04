using Addresh_Book5th.Areas.LOC_Country.Models;
using Addresh_Book5th.Areas.LOC_State.Models;
using Addresh_Book5th.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace Addresh_Book5th.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("LOC_State/{Controller}/{action}")]
    public class LOC_StateController : Controller
    {
        LOC_State_DALBase dalLOC_State = new LOC_State_DALBase();

        #region Configuration
        public IConfiguration Configuration;

        public LOC_StateController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region SelectAll
        public IActionResult Index(string? CountryName, string? StateName, string? StateCode, bool filter = false)
        {
            string myconnstr = this.Configuration.GetConnectionString("MyConnectingString");
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(myconnstr);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (Convert.ToBoolean(filter))
            {
                cmd.CommandText = "PR_State_Filter";
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                cmd.Parameters.AddWithValue("@StateName", StateName);
                cmd.Parameters.AddWithValue("@StateCode", StateCode);
            }
            else
            {
                cmd.CommandText = "PR_State_SelectAll";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            sqlConnection.Close();
            return View("LOC_State_List", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            if (Convert.ToBoolean(dalLOC_State.PR_LOC_State_DeleteByPk(StateID)))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {

            if (!TryValidateModel(modelLOC_State))
            {
                return View("LOC_StateAddEdit");
            }
           
            if(modelLOC_State.StateID == null)
            {
                DataTable dt = dalLOC_State.PR_LOC_State_Insert(modelLOC_State.StateName, modelLOC_State.StateCode, modelLOC_State.CountryID);
                TempData["LOC_State_Message"] = "Record Inserted Successfully!!";
            }
            else
            {
                DataTable dt = dalLOC_State.PR_LOC_State_UpdateByPK((int) modelLOC_State.StateID ,modelLOC_State.StateName, modelLOC_State.StateCode, modelLOC_State.CountryID);
                TempData["LOC_State_Message"] = "Record Update Successfully!!";
                
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? StateID)
        {
            #region Dropdown
            string myConnectingString1 = Configuration.GetConnectionString("MyConnectingString");
            SqlConnection conn1 = new SqlConnection(myConnectingString1);
            DataTable dt1 = new DataTable();
            conn1.Open();
            SqlCommand sqlCommand1 = conn1.CreateCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "PR_LOC_Country_Dropdown";
            SqlDataReader objred1 = sqlCommand1.ExecuteReader();
            dt1.Load(objred1);

            List<LOC_Country_DropdownModel> list = new List<LOC_Country_DropdownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropdownModel dlist = new LOC_Country_DropdownModel();
                dlist.CountryID = Convert.ToInt32(dr["CountryID"]);
                dlist.CountryName = dr["CountryName"].ToString();
                list.Add(dlist);
            }
            ViewBag.CountryList = list;
            #endregion

            #region SelectByPK
            if (StateID != null)
            {
                DataTable dt = dalLOC_State.PR_LOC_State_SelectByPK(StateID);

                LOC_StateModel modelLOC_State = new LOC_StateModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_State.StateName = dr["StateName"].ToString();
                    modelLOC_State.StateCode = dr["StateCode"].ToString();
                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);

                }
                return View("LOC_StateAddEdit", modelLOC_State);

            }
            return View("LOC_StateAddEdit");
            #endregion 
        }
        #endregion

        #region Cancle
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

    }
}