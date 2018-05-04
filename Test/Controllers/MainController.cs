using DataAccess;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class MainController : Controller
    {
        #region Initialization
        IRepository repository;
        public IRepository Repository
        {
            get
            {
                // Of course controller factory can be added and IoC could be used. If this task needs it I can add
                if (repository == null)
                {
                    repository = new TestRepository();
                    repository.Initialization(TestData.GetCategories());
                }

                return repository;
            }
        }
        #endregion

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategory(int categoryId)
        {
            Category category = Repository.GetCategory(categoryId);

            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoryIdsByLevel(int level)
        {
            List<int> categoryIds = Repository.GetCategoryIdsByLevel(level);
            categoryIds.Sort();

            return Json(categoryIds, JsonRequestBehavior.AllowGet);
        }        
    }
}