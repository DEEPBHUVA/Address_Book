using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Addresh_Book5th.Areas.LOC_Country.Models;
using Addresh_Book5th.DAL;
using System.Configuration;

namespace Addresh_Book5th.Areas.LOC_Country.Controllers
{
    [Area("LOC_Country")]
    [Route("LOC_Country/{Controller}/{action}")]
    public class LOC_CountryController : Controller
    { 
        LOC_Country_DAL dalLOC_Country = new LOC_Country_DAL();

        #region Configuration
        public IConfiguration Configuration;
        public LOC_CountryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region SelectAll
        //public IActionResult Index()
        //{
        //    DataTable dt = dalLOC_Country.PR_LOC_Country_SelectAll();
        //    return View("LOC_Country_List", dt);
        //}

        public IActionResult Index(string? CountryName, string? CountryCode, bool filter = false)
        {
            string MyCONNstr = this.Configuration.GetConnectionString("MyConnectingString"); 
            DataTable dtable = new DataTable();
            SqlConnection SQLConn = new SqlConnection(MyCONNstr); 
            SQLConn.Open();
            SqlCommand cmd = SQLConn.CreateCommand(); 
            cmd.CommandType = CommandType.StoredProcedure;
            if (Convert.ToBoolean(filter))
            {
                cmd.CommandText = "PR_Country_Filter"; 
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", CountryCode);
            }
            else
            {
                cmd.CommandText = "PR_Country_SelectAll";
            }
            SqlDataReader objStr = cmd.ExecuteReader();
            dtable.Load(objStr);
            return View("LOC_Country_List", dtable);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
            {
            if(Convert.ToBoolean(dalLOC_Country.PR_LOC_Country_Delete(CountryID)))
            {
                return RedirectToAction("Index"); 
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CountryID)
        {
            if(CountryID != null) {
                DataTable dt = dalLOC_Country.PR_LOC_Country_SelectByPK(CountryID);

                LOC_CountryModel model_LOC_Country = new LOC_CountryModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model_LOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                        model_LOC_Country.CountryName = dr["CountryName"].ToString();
                        model_LOC_Country.CountryCode = dr["CountryCode"].ToString();
                   
                    }
                    return View("LOC_Country_AddEdit", model_LOC_Country);
                }
            return View("LOC_Country_AddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {  
            if(modelLOC_Country.CountryID == null)
            {
                DataTable dt = dalLOC_Country.PR_LOC_Country_Insert(modelLOC_Country.CountryName, modelLOC_Country.CountryCode);
                TempData["LOC_Country_Insert_Message"] = "Record Inserted Successfully!!";
            }
            else
            {
                DataTable dt = dalLOC_Country.PR_LOC_Country_UpdateByPK((int) modelLOC_Country.CountryID,modelLOC_Country.CountryName, modelLOC_Country.CountryCode);
                TempData["LOC_Country_Insert_Message"] = "Record Update Successfully!!";
                
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Cancle
        public IActionResult Cancle()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region CountrySearch
        public IActionResult LOC_CountrySearch(string? searchKeyword)
        {
            string connectionString = this.Configuration.GetConnectionString("MyConnectingString");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_Search";
            command.Parameters.AddWithValue("@SearchKeyword", searchKeyword);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            conn.Close();
            return View("LOC_Country_List", table);
        }
        #endregion
    }
}
