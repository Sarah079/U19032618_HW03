using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U19032618_HW03.Models; //refernce model
using System.IO;

namespace U19032618_HW03.Controllers
{
    public class HomeController : Controller
    {
        //universal file data
        //List<FileModel> filedata = new List<FileModel>(); (didn't work)

        [HttpGet] //get selected radio button
        public ActionResult HomePage()
        {
            ViewBag.Message = "Your Home Page";

            return View();
        }

        [HttpPost] //post selected radio button
        public ActionResult HomePage(HttpPostedFileBase thisfilename, FormCollection theseradiobtns) //post the info from the view
        {
            ViewBag.Message = "Your Home Page";

            string radiobtnval = Convert.ToString(theseradiobtns["optradio"]); //get radio option value

            if (radiobtnval == "Document")
            {
                thisfilename.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), thisfilename.FileName));
            }
            else if (radiobtnval == "Image")
            {
                thisfilename.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), thisfilename.FileName));

            }
            else if (radiobtnval == "Video")
            {
                thisfilename.SaveAs(Path.Combine(HttpContext.Server.MapPath("~//Media/Videos"), thisfilename.FileName));

            }

            return View();
        }

        public ActionResult Aboutme()
        {
            ViewBag.Message = "Something about Sarah";
            return View();
        }

        public ActionResult FilesPage()
        {
            ViewBag.Message = "...'Media/Documents' folder";

            List<FileModel> filedata = new List<FileModel>();
            //apply all files
            string[] getdocs = Directory.GetFiles(@"~\Media\Documents"); //List<FileModel> filedata = getdata(); reference getdata function
            string[] getimgs = Directory.GetFiles(@"U19032618_HW03/Media/Images");
            string[] getvids = Directory.GetFiles(@"U19032618_HW03/Media/Videos");
            foreach (var file in getdocs)
            {
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file); //auto function
                filedata.Add(fileModel);
            }
            foreach (var file in getimgs)
            {
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file);
                filedata.Add(fileModel);
            }
            foreach (var file in getvids)
            {
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file);
                filedata.Add(fileModel);
            }

            return View(filedata);
        }
        public ActionResult DeletFile(string FileName)
        {
            List<FileModel> filedata = new List<FileModel>();
            System.IO.DirectoryInfo location;
            location = new DirectoryInfo("~/Media/Documents" + FileName);
            location.Delete();
            return RedirectToAction("Home");
        }
        public ActionResult DownloadFile(string FileName)
        {
            string ddoc = Server.MapPath("Media/Documents") + FileName;//tried todeletefile.FileName just got errors
            byte[] docbytes = System.IO.File.ReadAllBytes(ddoc);
            return File(docbytes, "application/octet-stream", FileName);
        }

        public ActionResult ImagesPage()
        {
            List<FileModel> filedata = new List<FileModel>();
            ViewBag.Message = "...'Media/Images' folder";
            var getdata = Directory.GetFiles("Media/Images");

            foreach (var file in getdata)
            {
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file);
            }

            return View(filedata);
        }
        public ActionResult DeleteImage(string FileName)
        {
            List<FileModel> filedata = new List<FileModel>();
            System.IO.DirectoryInfo location;
            location = new DirectoryInfo("~/Media/Images" + FileName);
            location.Delete();
            return RedirectToAction("Home");
        }
        public ActionResult DownloadImage(string FileName)
        {
            string dimg = Server.MapPath("Media/Images") + FileName;//tried todeletefile.FileName just got errors
            byte[] imgbytes = System.IO.File.ReadAllBytes(dimg);
            return File(imgbytes, "application/octet-stream", FileName);
        }

        public ActionResult VideosPage()
        {
            ViewBag.Message = "...'Media/Videos' folder";

            List<FileModel> filedata = new List<FileModel>();
            var getdata = Directory.GetFiles("Media/Videos");

            foreach (var file in getdata)
            {
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file);
            }

            return View(filedata);
        }
        public ActionResult DeleteVideo(string FileName)
        {
            List<FileModel> filedata = new List<FileModel>();
            System.IO.DirectoryInfo location;
            location = new DirectoryInfo("~/Media/Videos" + FileName);
            location.Delete();
            return RedirectToAction("Home");
        }
        public FileResult DownloadVideo(string FileName)
        {
            string dvid = Server.MapPath("Media/Videos") + FileName;
            byte[] vidbytes = System.IO.File.ReadAllBytes(dvid);

            return File(vidbytes, "application/octet-stream", FileName);
        }


    }
}