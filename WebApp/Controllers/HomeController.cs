using AzureCDP.IServices;
using AzureCDP.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public void UploadFile()
        {           
            String StorageConnection = ConfigurationManager.ConnectionStrings["StorageConnection"].ToString();
            HttpPostedFileBase file = Request.Files[0];
            byte[] fileArray = new byte[file.ContentLength];
            file.InputStream.Read(fileArray, 0, fileArray.Length);
            UploadAndAddToQueue.UploadAndQueue(file.FileName, StorageConnection, fileArray);       
        }

        public ActionResult UploadTemplate(FormCollection formCollection)
        {
            this.UploadFile();
            return this.RedirectToAction("Index", "Home");
        }
    }
}