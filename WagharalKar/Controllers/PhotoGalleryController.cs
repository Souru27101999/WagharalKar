using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WagharalKar.Models;

namespace WagharalKar.Controllers
{
    public class PhotoGalleryController : Controller
    {
        // GET: PhotoGallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SavePhoto(PhotoGalleryModel model)
       
        {
            try
            {

                return Json(new { Message = new PhotoGalleryModel().SavePhoto(model) }, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getPhotolist()
        {
            try
            {
                return Json(new { model = new PhotoGalleryModel().getPhotolist() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeletePhotoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new PhotoGalleryModel().DeletePhotoGallery(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult EditPhotoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new PhotoGalleryModel().EditPhotoGallery(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}