using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Addresh_Book5th.Areas.MST_Branch.Models;
using Addresh_Book5th.DAL;

namespace Addresh_Book5th.Areas.MST_Branch.Controllers
{
    [Area("MST_Branch")]
    [Route("MST_Branch/{Controller}/{action}")]
    public class MST_BranchController : Controller
    {
        MST_BranchDAL dalMST_Branch = new MST_BranchDAL();

        #region Configuration
        public IConfiguration Configuration;

        public MST_BranchController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalMST_Branch.PR_MST_Branch_SelectAll();
            return View("MST_Branch_List", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int BranchID)
        {
            if (Convert.ToBoolean(dalMST_Branch.PR_MST_Branch_DeleteByPK(BranchID)))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert
        public IActionResult Save(MST_BranchModel modelMST_Branch)
        {
            if (!TryValidateModel(modelMST_Branch))
            {
                return View("MST_BranchAddEdit");
            }

            if (modelMST_Branch.BranchID == null)
            {
                DataTable dt = dalMST_Branch.PR_MSR_Branch_Insert(modelMST_Branch.BranchName, modelMST_Branch.BranchCode);
                TempData["MST_Branch_Insert_Message"] = "Record Inserted Successfully!!";
            }
            else
            {
                DataTable dt = dalMST_Branch.PR_MST_Branch_UpdateByPK(modelMST_Branch.BranchID, modelMST_Branch.BranchName, modelMST_Branch.BranchCode);
                TempData["MST_Branch_Insert_Message"] = "Record Update Successfully!!";

            }

            return RedirectToAction("Index");  
        }
        #endregion

        #region Add
        public IActionResult Add(int? BranchID)
        {
            if (BranchID != null)
            {
                DataTable dt = dalMST_Branch.PR_MST_Branch_SelectByPK(BranchID);

                MST_BranchModel modelMST_Branch = new MST_BranchModel();

                foreach (DataRow row in dt.Rows)
                {
                    modelMST_Branch.BranchID = Convert.ToInt32(row["BranchID"]);
                    modelMST_Branch.BranchName = row["BranchName"].ToString();
                    modelMST_Branch.BranchCode = row["BranchCode"].ToString();
                }
                return View("MST_BranchAddEdit", modelMST_Branch);
            }
            return View("MST_BranchAddEdit");
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
