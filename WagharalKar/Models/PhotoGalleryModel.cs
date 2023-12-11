﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Razor;
using Wagharalkar.Data;

namespace WagharalKar.Models
{
    public class PhotoGalleryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

        public String SavePhoto(HttpPostedFileBase fb, PhotoGalleryModel model)
        {
            string msg = "Save Successfully";
            WagharalkarEntities db = new WagharalkarEntities();

            
            if (model.Id == 0)
            {
                var savephoto = new tblPhotoGallery()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Image1 = model.Image1,
                    Image2 = model.Image2,
                    Type = model.Type,
                    CreateDate = model.CreateDate,
                    UpdateDate = model.UpdateDate,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy
                };
                db.tblPhotoGalleries.Add(savephoto);
                db.SaveChanges();
            }
            else
            {
                var savephoto = db.tblPhotoGalleries.Where(p => p.Id == model.Id).FirstOrDefault();
                if(savephoto!=null)
                        {
                             savephoto.Id=model.Id;
                    savephoto.Title = model.Title;
                    savephoto.Image1 = model.Image1;
                    savephoto.Image2 = model.Image2;
                    savephoto.Type = model.Type;
                    savephoto.CreateDate = model.CreateDate;
                    savephoto.UpdateDate = model.UpdateDate;
                    savephoto.CreatedBy = model.CreatedBy;
                    savephoto.UpdatedBy = model.UpdatedBy;
                };
                db.SaveChanges();
                msg = "Update Successfully";
            }

            return msg;

        }
        public List<PhotoGalleryModel> getPhotolist()
        {
            WagharalkarEntities db = new WagharalkarEntities();
            List<PhotoGalleryModel> lstphoto = new List<PhotoGalleryModel>();
            var addphotolist = db.tblPhotoGalleries.ToList();
            if (addphotolist != null)
            {
                foreach (var photo in addphotolist)
                {
                    lstphoto.Add(new PhotoGalleryModel()
                    {
                        Id = photo.Id,
                        Title = photo.Title,
                        Image1 = photo.Image1,
                        Image2 = photo.Image2,
                        Type = photo.Type,
                        CreateDate = photo.CreateDate,
                        UpdateDate = photo.UpdateDate,
                        CreatedBy = photo.CreatedBy,
                        UpdatedBy = photo.UpdatedBy
                    });
                }


            }
            return lstphoto;

        }

        public string DeletePhotoGallery(int Id)
        {
            string msg = "Delete Record";
            WagharalkarEntities db = new WagharalkarEntities();
            var photogalleryData = db.tblPhotoGalleries.Where(p => p.Id == Id).FirstOrDefault();
            if (photogalleryData != null)
            {
                db.tblPhotoGalleries.Remove(photogalleryData);
                db.SaveChanges();
            }
            return msg;
        }
        public PhotoGalleryModel EditPhotoGallery(int Id)
        {
            PhotoGalleryModel model = new PhotoGalleryModel();
            WagharalkarEntities db = new WagharalkarEntities();
            var editData = db.tblPhotoGalleries.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.Title = editData.Title;
                model.Image1 = editData.Image1;
                model.Image2 = editData.Image2;
                model.Type = editData.Type;
                model.CreateDate = editData.CreateDate;
                model.UpdateDate = editData.UpdateDate;
                model.CreatedBy = editData.CreatedBy;
                model.UpdatedBy = editData.UpdatedBy;
            }
            return model;
        }

    }



}
