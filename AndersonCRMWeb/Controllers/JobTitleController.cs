﻿using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class JobTitleController : BaseController
    {
        private IFJobTitle _iFJobTitle;
        public JobTitleController(IFJobTitle iFJobTitle)
        {
            _iFJobTitle = iFJobTitle;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new JobTitle());
        }

        [HttpPost]
        public ActionResult Create(JobTitle jobTitle)
        {
            var createdJobTitle = _iFJobTitle.Create(UserId, jobTitle);
            return RedirectToAction("Index");
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFJobTitle.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFJobTitle.Read(id));
        }

        [HttpPost]
        public ActionResult Update(JobTitle jobTitle)
        {
            var createdJobTitle = _iFJobTitle.Update(UserId, jobTitle);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFJobTitle.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}